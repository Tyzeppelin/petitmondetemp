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
    protected class TileFactoryImpl : TileFactory
    {
        #region Singleton

        private static TileFactory _instance = null;

        private TileFactoryImpl()
        {
            instances.Add("glouglou", new TileWater());
            instances.Add("chopchop", new TileForest());
            instances.Add("climbclimb", new TileMountain());
            instances.Add("petitemaison" , new TilePlain());
        }

        public static TileFactory getMapFactory()
        {
            if (_instance == null)
                _instance = new TileFactoryImpl();
            return _instance;
        }
        #endregion

        public Dictionary<string, Tile> instances
        { get { throw new NotImplementedException(); }
          set { throw new NotImplementedException(); } }

        public Tile getTile(string type)
        {
            Tile hoothoot;
            instances.TryGetValue(type, out hoothoot);
            return hoothoot;
        }
    }
}
