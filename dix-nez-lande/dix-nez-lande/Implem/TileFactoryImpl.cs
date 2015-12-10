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
    public class TileFactoryImpl : TileFactory
    {
        #region Singleton

        private static TileFactory _instance = null;

        private TileFactoryImpl()
        {
            instances.Add(3, new TileWater());
            instances.Add(2, new TileForest());
            instances.Add(1, new TileMountain());
            instances.Add(0 , new TilePlain());
        }

        public static TileFactory getTileFactory()
        {
            if (_instance == null)
                _instance = new TileFactoryImpl();
            return _instance;
        }
        #endregion

        private Dictionary<int, Tile> _instances;
        public Dictionary<int, Tile> instances
        {
          get { return instances; }
          set { /*On ne change pas un singleton*/ } 
        }

        public Tile getTile(int type)
        {
            Tile hoothoot;
            instances.TryGetValue(type, out hoothoot);
            return hoothoot;
        }
    }
}
