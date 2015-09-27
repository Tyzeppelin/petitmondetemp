using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class Map : MapInterface
    {
        public int size
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public TileInterface[][] tiles
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Map(int size)
        {
            tiles = new TileInterface[size][];
            for(int i = 0; i < size; i++)
            {
                tiles[i] = new TileInterface[size];
            }
        }
    }
}