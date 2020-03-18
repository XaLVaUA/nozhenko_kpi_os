#include <iostream>

#include "CustomAllocator.h"
#include "Blob.h"

int main()
{
	auto allocator = new CustomAllocator();

	auto mem1 = allocator->mem_alloc(sizeof(Blob));
	auto mem2 = allocator->mem_alloc(sizeof(Blob));

	auto blob1 = new (mem1) Blob(1);
	auto blob2 = new (mem2) Blob(2);

	std::cout << "blob1 on mem1: " << blob1->get_num() << std::endl;
	std::cout << "blob2 on mem2: " << blob2->get_num() << std::endl;

	auto mem3 = allocator->mem_realloc(mem1, sizeof(Blob));

	std::cout << "reallocating mem1 with sizeof Blob (expected to get mem3 with recently freed mem1 address) " << std::endl;
	
	auto blob3 = new (mem3) Blob(3);

	std::cout << "create blob3 on mem3 " << std::endl;

	std::cout << "blob1 that points to mem1 expected to be blob3 as mem3 expected to have address of mem1 " << std::endl;
	std::cout << "blob1 on mem1(mem3): " << blob1->get_num() << std::endl;
	
	return 0;
}