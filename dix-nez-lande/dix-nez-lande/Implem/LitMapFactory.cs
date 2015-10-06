using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class LitMapFactory : MapStrategy
    {
        #region Singleton

        private static LitMapFactory _instance = null;

        private LitMapFactory() { }

        public static LitMapFactory getMapStrategy()
        {
            if (_instance == null)
                _instance = new LitMapFactory();
            return _instance;
        }
        #endregion
        public Map createMap()
        {
            Map m =  new MapImpl();
            m.size = GameBuilder.LitMap;
            return m;
        }

        public int getSizeArmy()
        {
            return GameBuilder.LitArmy;
        }
    }
}
