#include "CustomAllocator.h"
#include "Windows.h"

CustomAllocator::CustomAllocator()
{
	used_blocks_ = new std::list<mem_block*>();
	free_blocks_ = new std::list<mem_block*>();
}

void* CustomAllocator::mem_alloc(const size_t size)
{
	auto block = find_first_block(size);

	if (block == nullptr)
	{
		block = alloc_heap_mem_block(size);
	}

	split_block(block, size);
	
	return block->ptr;
}

void* CustomAllocator::mem_realloc(void* addr, size_t size)
{
	mem_free(addr);
	return mem_alloc(size);
}

void CustomAllocator::mem_free(void* addr)
{
	const auto ptr = reinterpret_cast<uint8_t*>(addr);

	for (auto block : *used_blocks_)
	{
		if (block->ptr != ptr) continue;

		used_blocks_->remove(block);
		free_blocks_->push_back(block);
		join_block(block);
		return;
	}
}

CustomAllocator::mem_block* CustomAllocator::find_first_block(const size_t size)
{
	for (auto block : *free_blocks_)
	{
		if (block->size < size) continue;
		return block;
	}

	return nullptr;
}

CustomAllocator::mem_block* CustomAllocator::alloc_heap_mem_block(size_t size)
{
	const auto mem = HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, size);
	
	const auto block = new mem_block();
	block->next = nullptr;
	block->prev = nullptr;
	block->ptr = static_cast<uint8_t*>(mem);
	block->size = size;
	
	free_blocks_->push_back(block);
	
	return block;
}

void CustomAllocator::split_block(mem_block *block, const size_t size)
{
	free_blocks_->remove(block);
	used_blocks_->push_back(block);
	
	if (block->size == size) return;

	const auto size_diff = block->size - size;

	const auto splitted_block = new mem_block();
	splitted_block->ptr = block->ptr + size;
	splitted_block->size = size_diff;
	splitted_block->prev = block;
	splitted_block->next = block->next;
	
	block->next = splitted_block;
	block->size = size;

	free_blocks_->push_back(splitted_block);
}

void CustomAllocator::join_block(mem_block *block)
{
	if (contains_block(free_blocks_, block->prev))
	{
		block = join_blocks(block->prev, block);
	}

	if (contains_block(free_blocks_, block->next))
	{
		block = join_blocks(block->next, block);
	}
}

CustomAllocator::mem_block* CustomAllocator::join_blocks(mem_block* left, mem_block* right)
{
	left->size += right->size;
	left->next = right->next;
	return left;
}

bool CustomAllocator::contains_block(const std::list<mem_block*>* list, mem_block* block)
{
	for (auto list_block : *list)
	{
		if (block == nullptr) continue;
		if (list_block->ptr == block->ptr) return true;
	}

	return false;
}
