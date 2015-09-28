using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class PlayerFactory
    {
        #region Singleton

        private static PlayerFactory _instance = null;

        private PlayerFactory() { }

        public static PlayerFactory getMapFactory()
        {
            if (_instance == null)
                _instance = new PlayerFactory();
            return _instance;
        }
        #endregion

        public Player createPlayer(Race race, String name)
        {
            return new PlayerImpl(race, name);

        }
    }
}
