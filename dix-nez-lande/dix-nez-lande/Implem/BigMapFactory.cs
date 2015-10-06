using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class BigMapFactory : MapStrategy
    {
        #region Singleton

        private static BigMapFactory _instance = null;

        private BigMapFactory() { }

        public static BigMapFactory getMapStrategy()
        {
            if (_instance == null)
                _instance = new BigMapFactory();
            return _instance;
        }
        #endregion

        public Map createMap()
        {
            Map m = new MapImpl();
            m.size = GameBuilder.BigMap;
            return m;
        }

        public int getSizeArmy()
        {
            return GameBuilder.BigArmy;
        }
    }
}
