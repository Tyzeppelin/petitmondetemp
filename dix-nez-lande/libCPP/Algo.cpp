#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 

using namespace std;

void Algo::fillMap(int map[], int size)
{
	srand(time(NULL));
	cout << "Size : " << size << endl;
	int MapSize = size * size;
	cout << "MapSize : " << MapSize << endl;
	int water = MapSize / 4;
	cout << "Water : " << water;
	int mountain = MapSize / 4;
	cout << " Mountain : " << mountain;
	int plain = MapSize / 4;
	cout << " Plain : " << plain;
	int forest = MapSize / 4;
	cout << " Forest : " << forest << endl;
	int nbType[4] = { water, plain, forest, mountain };
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