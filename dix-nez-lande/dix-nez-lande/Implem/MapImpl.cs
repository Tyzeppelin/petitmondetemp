using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class MapImpl : Map
    {
        public MapImpl()
        {

        }
        public List<Tile> tiles
        {
            get
            {
                return tiles;
            }

            set
            {
                tiles = value;
            }
        }
    }
}
