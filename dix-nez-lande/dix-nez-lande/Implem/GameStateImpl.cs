using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    public class GameStateImpl : GameState
    {
        private Player _player1;
        public Player player1
        { get { return _player1; }
          set { _player1 = value; }
        }

        private Player _player2;
        public Player player2
        {
            get { return _player2; }
            set { _player2 = value; }
        }

        private int _nbTurn;
        public int nbTurn
        {
            get { return _nbTurn; }
            set { _nbTurn = value; }
        }

        private Dictionary<Position, List<Unit>> _units;
        public Dictionary<Position, List<Unit>> units
        {
            get { return _units; }
            set { _units = value; }
        }

        public GameStateImpl() { }
    }
}
