#include "MemPage.h"

MemPage::MemPage(uint8_t *mem, size_t size)
{
	ptr_ = mem;
	size_ = size;
	next_page_ = nullptr;
	status_ = page_status::Free;
	
	used_blocks_ = new std::list<mem_block*>();
	free_blocks_ = new std::list<mem_block*>();
	
	last_block_ = new mem_block();
	last_block_->ptr = mem;
	last_block_->size = size;
	last_block_->next = nullptr;
	last_block_->prev = nullptr;

	free_blocks_->push_back(last_block_);
}

void* MemPage::mem_alloc(size_t size)
{
	size = align_block_size(size);

	auto block = find_first_block(size);

	if (block == nullptr)
	{
		return nullptr;
	}

	split_block(block, size);

	size_ -= size;

	if (size_ == 0)
	{
		status_ = page_status::Used;
	}
	else
	{
		status_ = page_status::Splitted;
	}
	
	return block->ptr;
}

void* MemPage::mem_realloc(void *addr, size_t size)
{
	mem_free(addr);
	return mem_alloc(size);
}

void MemPage::mem_free(void *addr)
{
	const auto ptr = reinterpret_cast<uint8_t*>(addr);

	for (auto block : *used_blocks_)
	{
		if (block->ptr != ptr) continue;

		size_ += block->size;
		
		used_blocks_->remove(block);
		const auto joined_block = join_block(block);
		free_blocks_->push_front(joined_block);

		return;
	}

	if (used_blocks_->empty())
	{
		status_ = page_status::Free;
	}
}

size_t MemPage::get_size()
{
	return size_;
}

MemPage* MemPage::get_next_page()
{
	return next_page_;
}

MemPage::page_status MemPage::get_status()
{
	return status_;
}

uint8_t * MemPage::get_ptr()
{
	return ptr_;
}

size_t MemPage::align_block_size(size_t size)
{
	return (size + sizeof(intptr_t) - 1) & ~(sizeof(intptr_t) - 1);
}

MemPage::mem_block* MemPage::find_first_block(const size_t size)
{
	for (auto block : *free_blocks_)
	{
		if (block->size < size) continue;
		return block;
	}

	return nullptr;
}

void MemPage::split_block(mem_block *block, size_t size)
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

void MemPage::join_blocks(mem_block *left, mem_block *right)
{
	left->size += right->size;
	left->next = right->next;
	free_blocks_->remove(right);
}

MemPage::mem_block * MemPage::join_block(mem_block *block)
{
	if (block->next != nullptr && (block + block->size == block->next) && contains_block(free_blocks_, block->next))
	{
		join_blocks(block->next, block);
	}

	if (block->prev != nullptr && (block->prev + block->prev->size == block) && contains_block(free_blocks_, block->prev))
	{
		join_blocks(block->prev, block);
		return block->prev;
	}

	return block;
}

bool MemPage::contains_block(const std::list<mem_block*>* list, mem_block* block)
{
	for (auto list_block : *list)
	{
		if (block == nullptr) continue;
		if (list_block->ptr == block->ptr) return true;
	}

	return false;
}
