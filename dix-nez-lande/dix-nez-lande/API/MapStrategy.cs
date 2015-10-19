using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Stratégie pour créer la carte
    * et la liste des unités
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface MapStrategy
    {
        /**
        * Permet de créer une carte
        * @return Map la carte créée
        */
        Map createMap();

        /**
        * Permet de récupérer le nombre d'unités
        * en fonction de la taille de la carte
        * @return int Le nombre d'unités à créer
        */
        int getSizeArmy();
    }
}