using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    /**
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    class MapImpl : Map
    {
        public MapImpl() { }

        public int size
        {
            get { return size; }
            set { size = value; }
        }

        public List<Tile> tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }
    }
}
