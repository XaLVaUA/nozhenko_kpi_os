#include <iostream>

#include "CustomAllocator.h"
#include "Blob.h"

int main()
{
	auto allocator = new CustomAllocator(sizeof(Blob) * 2);

	auto mem1 = allocator->mem_alloc(sizeof(Blob));
	auto mem2 = allocator->mem_alloc(sizeof(Blob));

	auto blob1 = new (mem1) Blob(1);
	auto blob2 = new (mem2) Blob(2);

	std::cout << blob1->get_num() << std::endl;
	std::cout << blob2->get_num() << std::endl;

	auto mem3 = allocator->mem_realloc(mem1, sizeof(Blob));

	auto blob3 = new (mem3) Blob(3);

	std::cout << blob1->get_num() << std::endl;
	
	return 0;
}