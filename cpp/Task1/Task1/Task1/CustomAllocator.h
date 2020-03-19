#pragma once

#include <iostream>
#include <list>

class CustomAllocator
{
	struct mem_block
	{
		uint8_t *ptr;
		size_t size;
		mem_block *next;
		mem_block *prev;
	};
	
public:
	explicit CustomAllocator();
	void* mem_alloc(size_t size);
	void* mem_realloc(void* addr, size_t size);
	void mem_free(void* addr);
	
private:
	std::list<mem_block*> *free_blocks_;
	std::list<mem_block*> *used_blocks_;
	mem_block* last_block_;

	size_t align_size(size_t size);
	mem_block* find_first_block(size_t size);
	mem_block* alloc_heap_mem_block(size_t size);
	void split_block(mem_block* block, size_t size);
	void join_block(mem_block* block);
	mem_block* join_blocks(mem_block* left, mem_block* right);
	bool contains_block(const std::list<mem_block*>* list, mem_block* block);
};

