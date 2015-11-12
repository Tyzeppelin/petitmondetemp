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
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public GameState stateToSave
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException();  }
        }

        public HistoryImpl() { }

        public GameState getLastState()
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void set(GameState g)
        {
            throw new NotImplementedException();
        }
    }
}
