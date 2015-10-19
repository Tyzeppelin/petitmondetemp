using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Interface de la carte avec sa taille
    * et sa liste de tuiles
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface Map
    {
        int size { get; set; }
        List<Tile> tiles { get; set; }
    }
}