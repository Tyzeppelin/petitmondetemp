using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class HistoryImpl : History
    {
        
        public List<GameState> states
        {
            get { return states; }
            set { states = value; }
        }

        public GameState stateToSave
        {
            get { return stateToSave; }
            set { stateToSave = value;  }
        }

        public HistoryImpl() { }

        public GameState getLastState()
        {
            return states[states.Count - 1];
        }

        public void save()
        {
            states.Add(stateToSave);
        }
        // Set the game to the state it were at GameState g.
        public void set(GameState g)
        {
            throw new NotImplementedException();
        }

        public GameState pop()
        {
            GameState g = states[states.Count - 1];
            states.RemoveAt(states.Count - 1);
            return g;
        }
    }
}
