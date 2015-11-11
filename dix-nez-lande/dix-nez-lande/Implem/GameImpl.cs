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
    class GameImpl : Game
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

        public GameImpl() { }
    }
}
