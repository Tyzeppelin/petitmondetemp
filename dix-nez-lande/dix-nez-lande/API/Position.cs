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
        Dictionary<Tile, List<Unit>> ouKilEst { get; set; }

        /**
        * Déplace une unité sur une Tile
        * @param u L'unité à déplacer
        * @param t La Tile d'arrivée de l'unité
        */
        void moveTo(Unit u, Tile t);

        /**
        * Une unité attaque une autre unité sur une Tile
        * Le choix de l'unité à attaquer est défini dans
        * l'implémentation
        * @param attacker L'unité attaquante
        * @param t La Tile où l'unité attaque
        */
        void attack(Unit attacker , Tile t);
    }
}