#include "CustomAllocator.h"

#include <iostream>


#include "Windows.h"

CustomAllocator::CustomAllocator(size_t page_size)
{
	page_size_ = page_size;

	page_mems_ = new std::list<size_t>();
	mem_pages_ = new std::multimap<size_t, MemPage*>();
	big_mem_pages_ = new std::list<MemPage*>();

	fill_page_mems(page_mems_);
	auto mem = alloc_heap_mem(10 * page_size);
	make_pages(mem, 10 * page_size);
}

void* CustomAllocator::mem_alloc(size_t size)
{
	if (size <= page_size_)
	{
		for (auto page_mem : *page_mems_)
		{
			if (page_mem < size) continue;

			auto eqr = mem_pages_->equal_range(page_mem);
			auto
				st = eqr.first,
				en = eqr.second;
			for (auto it = st; it != en; ++it) {
				auto page = it->second;
				if (page->get_size() < size) continue;

				auto mem = page->mem_alloc(size);

				return mem;
			}
		}

		for (auto page : *big_mem_pages_)
		{
			if (page->get_status() != MemPage::page_status::Free) continue;
			big_mem_pages_->remove(page);

			auto mem = page->mem_alloc(size);

			for (auto page_mem : *page_mems_)
			{
				if (page_mem < page->get_size()) continue;

				mem_pages_->insert(std::pair<size_t, MemPage*>(page_mem, page));
				break;
			}

			return mem;
		}
	}
	else
	{
		auto page_count = align_page_size(size) / page_size_;
		for (auto page : *big_mem_pages_)
		{
			if (page->get_status() != MemPage::page_status::Free) continue;
			{
				auto res = true;
				{

					auto pg = page->get_next_page();
					for (size_t i = 0; i < page_count - 1; ++i)
					{
						if (pg->get_status() != MemPage::page_status::Free)
						{
							res = false;
							break;
						}
					}
				}

				if (!res) continue;
			}
			
			auto mem = page->mem_alloc(page_size_);
			auto pg = page->get_next_page();
			big_mem_pages_->remove(page);
			for (auto page_mem : *page_mems_)
			{
				if (page_mem < page->get_size()) continue;

				mem_pages_->insert(std::pair<size_t, MemPage*>(page_mem, page));
				break;
			}
			for (size_t i = 0; i < page_count - 1; ++i)
			{
				pg->mem_alloc(page_size_);
				big_mem_pages_->remove(pg);
				for (auto page_mem : *page_mems_)
				{
					if (page_mem < pg->get_size()) continue;

					mem_pages_->insert(std::pair<size_t, MemPage*>(page_mem, pg));
					break;
				}
			}

			return mem;
		}
	}
	
	return nullptr;
}

void* CustomAllocator::mem_realloc(void* addr, size_t size)
{
	mem_free(addr);
	return mem_alloc(size);
}

void CustomAllocator::mem_free(void* addr)
{
	for (auto page_pair : *mem_pages_)
	{
		auto page = page_pair.second;
		if (addr >= page->get_ptr() && addr <= page->get_ptr())
		{
			page->mem_free(addr);
			if (page->get_status() == MemPage::page_status::Free)
			{
				for (auto it = mem_pages_->begin(); it != mem_pages_->end(); ++it)
				{
					if (it->second == page)
					{
						mem_pages_->erase(it);
						break;
					}
				}
				big_mem_pages_->push_back(page);
			}
			
			return;
		}
	}

	for (auto page : *big_mem_pages_)
	{
		if (addr >= page->get_ptr() && addr <= page->get_ptr())
		{
			page->mem_free(addr);
			return;
		}
	}
}

uint8_t* CustomAllocator::alloc_heap_mem(size_t size)
{
	const auto mem = HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, size);

	if (mem == nullptr)
	{
		return nullptr;
	}

	return static_cast<uint8_t*>(mem);
}

size_t CustomAllocator::align_page_size(size_t size)
{
	return (size + page_size_ - 1) & ~(page_size_ - 1);
}

void CustomAllocator::fill_page_mems(std::list<size_t>* page_mems)
{
	for (size_t mem_size = 1; mem_size <= page_size_; mem_size = mem_size << 1)
	{
		page_mems->push_back(mem_size);
	}
}

void CustomAllocator::make_pages(uint8_t *mem, size_t mem_size)
{
	auto page_count = align_page_size(mem_size) / page_size_;
	auto cur_mem = mem;
	for (size_t i = 0; i < page_count; ++i)
	{
		big_mem_pages_->push_back(new MemPage(cur_mem, page_size_));
		cur_mem += page_size_;
	}
}
