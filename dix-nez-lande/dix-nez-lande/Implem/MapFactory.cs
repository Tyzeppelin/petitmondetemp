using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class MapFactory
    {
        #region Singleton

        private static MapFactory _instance = null;

        private MapFactory() { }

        public static MapFactory getMapFactory()
        {
            if (_instance == null)
                _instance = new MapFactory();
            return _instance;
        }
        #endregion

        public Map createMap(int size) {

            //List<Tile> board = new List<Tile>();

            return new MapImpl();
        }
    }
}
