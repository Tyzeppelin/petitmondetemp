using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class GameFactory
    {
        #region Singleton

        private static GameFactory _instance = null;

        private GameFactory()
        {
        }

        public static GameFactory getGameFactory()
        {
            if (_instance == null)
                _instance = new GameFactory();
            return _instance;
        }
        #endregion

        public void createMap(int size)
        {

        }
    }
}