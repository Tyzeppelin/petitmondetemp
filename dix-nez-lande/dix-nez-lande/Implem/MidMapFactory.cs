using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    /**
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    protected class MidMapFactory : MapStrategy
    {
        #region Singleton

        private static MidMapFactory _instance = null;

        private MidMapFactory() { }

        public static MidMapFactory getMapStrategy()
        {
            if (_instance == null)
                _instance = new MidMapFactory();
            return _instance;
        }
        #endregion

        public Map createMap()
        {
            Map m = new MapImpl();
            m.size = GameBuilder.MidMap;
            return m;
        }

        public int getSizeArmy()
        {
            return GameBuilder.MidArmy;
        }
    }
}
