using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class UnitFactory
    {
        #region Singleton

        private static UnitFactory _instance = null;

        private UnitFactory()
        {
        }

        public static UnitFactory getUnitFactory()
        {
            if (_instance == null)
                _instance = new UnitFactory();
            return _instance;
        }
        #endregion

        public List<Unit> createArmy(Race race, int sizeMap)
        {
            int nb;
            switch (sizeMap)
            {
                case Map.LitMap:
                    nb = Unit.LitArmy;
                    break;
                case Map.MidMap:
                    nb = Unit.MidArmy;
                    break;
                case Map.BigMap:
                    nb = Unit.BigArmy;
                    break;
                default:
                    nb=4;
                    break;
            }
            List<Unit> list = new List<Unit>();
            for (int i = 0; i < nb; i++)
            {
                //voir nomdefantasy.com pour plus de pimp
                list.Add(new UnitImpl(race, "Unit " + i));
            }
            return list;
        }
    }
}