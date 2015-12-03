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
        public Map map
        {
            get { return map; }
            set { map = value; }
        }

        public List<Player> players
        {
            get { return players; }
            set { players = value; }
        }

        public int nbTurn
        {
            get { return nbTurn; }
            set { nbTurn = value; }
        }

         public Player current
        {
            get { return current; }
            set { current = value; }
        }

        public History saveStates
        {
            get { return saveStates; }
            set { saveStates = value; }
        }

        public GameImpl() { }


        public void start()
        {
            current = players[0];
            current.beginTurn();
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
            current.beginTurn();
        }

        public Player whoWin()
        {
            return players[0];
        }

        public void undo()
        {
        }
    }
}
