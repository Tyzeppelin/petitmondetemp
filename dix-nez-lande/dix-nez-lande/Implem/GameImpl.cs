using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    /**
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public class GameImpl : Game
    {
        private Map _map;
        public Map map
        {
            get { return _map; }
            set { _map = value; }
        }

        private List<Player> _players;
        public List<Player> players
        {
            get { return _players; }
            set { _players = value; }
        }

        private int _nbTurn;
        public int nbTurn
        {
            get { return _nbTurn; }
            set { _nbTurn = value; }
        }

        private Player _current;
         public Player current
        {
            get { return _current; }
            set { _current = value; }
        }

        private History _saveStates;
        public History saveStates
        {
            get { return _saveStates; }
            set { _saveStates = value; }
        }

        public GameImpl() { }


        public void start()
        {
            current = players[0];
            beginTurn();
        }

        public void beginTurn()
        {
            Console.WriteLine("Le joueur " + current.name + " commence son tour");
        }

        public void endTurn()
        {
            foreach (Unit units in current.units)
            {
                current.points += units.getPoints();
            }
            Console.WriteLine("Le joueur " + current.name + " a fini de jouer son tour");
            nbTurn--;
            if (nbTurn == 0)
            {
                endGame();
            }
            else
            {
                switchPlayer();
            }
        }

        public void switchPlayer()
        {
            if (current == players[0])
            {
                current = players[1];
            }
            else
            {
                current = players[0];
            }
            beginTurn();
        }

        public void endGame()
        {
            Console.WriteLine("Le joueur " + whoWin() + " a gagné !");
        }

        public void rageQuit()
        {
            Console.WriteLine("Le joueur " + current.name + " abandonne lâchement");
            current.points = -1;
            endGame();
        }

        public Player whoWin()
        {
<<<<<<< 449e880ac58f2eee86f4425e8e26e97bd9f576d4
            
            return players[0].points > players[1].points? players[0]:players[1];
=======
            return players[0].Points > players[1].Points? players[0]:players[1];
>>>>>>> update history
        }

        public void undo()
        {
            GameState gs = saveStates.pop();

            if (gs.player1.name == players[0].name) {
                players[0] = gs.player1;
                players[1] = gs.player2;
            }else
            {
                players[0] = gs.player2;
                players[1] = gs.player1;
            }
        }
    }
}
