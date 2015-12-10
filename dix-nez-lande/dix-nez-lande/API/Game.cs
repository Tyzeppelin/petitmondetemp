using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Interface du jeu
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface Game
    {
        Map map { get; set; }
        List<Player> players { get; set; }
        int nbTurn { get; set; }
        Player current { get; set; }
        History saveStates { get; set; }

        /**
        * Start the game
        */
        void start();

        /**
         * Début du tour du joueur courant
         */
        void beginTurn();

        /**
        * Switch the player at this end of a turn
        */
        void switchPlayer();
        
        /**
        * End the game
        */
        void endGame();

        /**
        * Return the player who won
        */
        Player whoWin();

        /**
        * Fin du tour pour le joueur courant
        */
        void endTurn();

        /**
         * Le joueur courant abandonne la partie
         */
        void rageQuit();

        /**
        * Undo all the axtions done by the 
        * current player for this turn
        */
        void undo();

        /**
        * Get all the positions available
        */
        List<Position> suggest();
    }
}