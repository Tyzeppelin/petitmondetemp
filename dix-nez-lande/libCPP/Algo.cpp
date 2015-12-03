#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 

using namespace std;

void Algo::fillMap(TileType map[], int size)
{
	srand(time(NULL));
	int tabSize = size * size;
	int nbTiles = tabSize / 4;
	int nbTilesPerType[4] = { nbTiles, nbTiles, nbTiles, nbTiles };
	bool affect;
	for (int i = 0; i < tabSize; i++){
		affect = false;
		int tile = rand() % 4;
		while (!affect){
			if (nbTilesPerType[tile] != 0){
				map[i] = (TileType)(tile);
				affect = true;
			}
		}
	}
}