using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class GameStateFactory
    {
        #region Singleton

        private static GameStateFactory _instance = null;

        private GameStateFactory()
        {
        }

        public static GameStateFactory getStateFactory()
        {
            if (_instance == null)
                _instance = new GameStateFactory();
            return _instance;
        }
        #endregion

        public GameState createGameState() { return new GameStateImpl(); }
    }
}
