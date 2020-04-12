#pragma once

#include <map>

#include "MemPage.h"

class CustomAllocator
{

public:
	explicit CustomAllocator(size_t page_size);
	void* mem_alloc(size_t size);
	void* mem_realloc(void* addr, size_t size);
	void mem_free(void* addr);

private:
	size_t page_size_;
	
	std::list<size_t>* page_mems_;
	std::multimap<size_t, MemPage*>* mem_pages_;
	std::list<MemPage*>* big_mem_pages_;

	uint8_t* alloc_heap_mem(size_t size);
	size_t align_page_size(size_t size);
	void fill_page_mems(std::list<size_t>* page_mems);
	void make_pages(uint8_t* mem, size_t mem_size);
};

