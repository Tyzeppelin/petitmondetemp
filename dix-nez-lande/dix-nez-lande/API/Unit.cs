using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Interface d'une unité
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface Unit
    {

        int atk { get; set; }
        int def { get; set; }
        int mov { get; set; }
        int hp { get; set; }
        int dis { get; set; }
        string name { get; set; }
        Race race { get; set; }
        Position pos { get; set; }

        /**
        * Permet l'attaque d'une Tile
        * @param t La Tile à attaquer
        */
        void attack(Position p);

        /**
        * Permet de déplement de l'unité sur une Tile
        * @param t La Tile où l'unité se déplace
        */
        void move(Position p);
        /**
        * Permet de savoir si une unité est en vie ou non
        * @return Vrai si l'unité est en vie
        */
        bool isAlive();
    }
}