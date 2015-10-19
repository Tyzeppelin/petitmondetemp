using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Interface d'un joueur
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface Player
    {
        String name { get; set; }
        Race race { get; set; }
        List<Unit> units { get; set; }

        /**
        * Permet de récupérer une unité du joueur
        * @param no Le numero de l'unité désirée
        * @return Unit L'unité appelée
        */
        Unit getUnit(int no);

        /**
        * Permet d'ajouter une unité au joueur
        * @param u L'unité à ajouter
        */
        void setUnit(Unit u);
    }
}