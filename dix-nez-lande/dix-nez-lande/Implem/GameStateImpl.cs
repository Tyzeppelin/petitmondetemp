using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class GameStateImpl : GameState
    {
        public Player player1
        { get { return player1; }
          set { player1 = value; }
        }

        public Player player2
        {
            get { return player2; }
            set { player2 = value; }
        }

        public Dictionary<Position, List<Unit>> unitsPosition
        {
            get { return unitsPosition; }
            set { unitsPosition = value; }
        }

        public GameStateImpl() { }
    }
}
