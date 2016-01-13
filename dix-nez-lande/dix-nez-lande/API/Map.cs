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
        Tile[] tiles { get; set; }
        Dictionary<Position, List<Unit>> units { get; set; }

        /**
        * Place une armée sur la carte
        */
        void placeArmy(Player p, int numPlayer);

        /**
       * Déplace une unité sur une Tile
       * @param u L'unité à déplacer
       * @param t La Tile d'arrivée de l'unité
       */
        void moveTo(Unit u, Position p);

        /**
        * Une unité attaque une autre unité sur une Tile
        * Le choix de l'unité à attaquer est défini dans
        * l'implémentation
        * @param attacker L'unité attaquante
        * @param t La Tile où l'unité attaque
        */
        void attack(Unit attacker , Position p, Map m);

        /**
        * Est-ce que la case situé en x,y est une destination
        * acceptable pour la race r
        */
        Boolean canMove(int x, int y, Race r);
    }
}