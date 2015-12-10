#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 

using namespace std;

void Algo::fillMap(int map[], int size)
{
	srand(time(NULL));
	int MapSize = size * size;
	for (int x = 0; x < MapSize; x++)
	{
			map[x] = x % 4;
	}
}