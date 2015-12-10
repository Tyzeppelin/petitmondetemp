using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Factory de Tile
    * C'est une factory poids-mouche car
    * seuls 4 types de Tiles vont être utilisés
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface TileFactory
    {
        Dictionary<int, Tile> instances { get; set; }

        /**
        * Rend une Tile d'un type
        * @return La Tile voulue
        */
        Tile getTile(int type);
    }
}