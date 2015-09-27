using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
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

        public GameImpl() { }
    }
}
