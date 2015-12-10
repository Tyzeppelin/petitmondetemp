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
	int nbType[4] = { MapSize / 4, MapSize / 4, MapSize / 4, MapSize / 4 };
	for (int x = 0; x < MapSize; x++)
	{
		int tile = rand() % 4;
		while (nbType[tile] == 0) {
			tile = rand() % 4;
		}
		nbType[tile]--;
		map[x] = tile;
	}
}