using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Interface d'une Tile
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface Tile
    {
        int getPoints(Race r);
    }
}