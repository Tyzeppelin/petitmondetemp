using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    public class HistoryImpl : History
    {
        private List<GameState> _states;
        public List<GameState> states
        {
            get { return _states; }
            set { _states = value; }
        }

        private GameState _stateToSave;
        public GameState stateToSave
        {
            get { return _stateToSave; }
            set { _stateToSave = value;  }
        }

        public HistoryImpl() { }

        public GameState getLastState()
        {
            return states[states.Count - 1];
        }

        public void save()
        {
            Console.WriteLine("-dave()");
            states.Add(stateToSave);
        }
        // Set the game to the state it were at GameState g.
        public void set(GameState g)
        {
            stateToSave = g;
        }

        public GameState pop()
        {
            if (states.Count != 0)
            {
                GameState g = states[states.Count - 1];
                states.RemoveAt(states.Count - 1);
                return g;
            }
            else
                return null;
        }
    }
}
