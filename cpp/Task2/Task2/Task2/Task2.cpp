#include <iostream>

#include "Blob.h"
#include "CustomAllocator.h"

int main()
{
	auto allocator = new CustomAllocator(4096);

	auto mem1 = allocator->mem_alloc(sizeof(Blob));
	auto mem2 = allocator->mem_alloc(sizeof(Blob));

	auto blob1 = new (mem1) Blob(1);
	auto blob2 = new (mem2) Blob(2);

	std::cout << "blob1 on mem1: " << blob1->get_num() << std::endl;
	std::cout << "blob2 on mem2: " << blob2->get_num() << std::endl;

	return 0;
}
