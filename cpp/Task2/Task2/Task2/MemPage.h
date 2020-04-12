#pragma once

#include <list>

class MemPage
{
	struct mem_block
	{
		uint8_t* ptr;
		size_t size;
		mem_block* next;
		mem_block* prev;
	};

	
	
public:
	enum class page_status { Free, Splitted, Used };
	
	MemPage(uint8_t *mem, size_t size);
	void* mem_alloc(size_t size);
	void* mem_realloc(void* addr, size_t size);
	void mem_free(void* addr);
	size_t get_size();
	MemPage* get_next_page();
	page_status get_status();
	uint8_t* get_ptr();
	
private:
	uint8_t* ptr_;
	size_t size_;
	MemPage* next_page_;
	page_status status_;
	
	std::list<mem_block*>* free_blocks_;
	std::list<mem_block*>* used_blocks_;
	mem_block* last_block_;
	
	size_t align_block_size(size_t size);
	mem_block* find_first_block(size_t size);
	void split_block(mem_block* block, size_t size);
	void join_blocks(mem_block* left, mem_block* right);
	mem_block* join_block(mem_block* block);
	bool contains_block(const std::list<mem_block*>* list, mem_block* block);
};
