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
    public class TileMountain : Tile
    {
        public int getPoints(Race r)
        {
            if (r.name == "orc") return 2;
            else if (r.name == "human") return 1;
            else return 0;
        }
    }
}
