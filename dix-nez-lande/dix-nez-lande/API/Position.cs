using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Interface d'une position qui fait le lien
    * entre une Tile et les Units
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface Position
    {
        int x { get; set; }
        int y { get; set; }

        /**
        * Rend la tile à la position courante.
        */
        Tile getTile();
    }
}