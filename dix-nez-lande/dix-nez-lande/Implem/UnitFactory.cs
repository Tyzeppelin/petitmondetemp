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

        public List<Unit> createArmy(Race race, int nb)
        {
            List<Unit> list = new List<Unit>();
            for (int i = 0; i < nb; i++)
            {
                list.Add(new UnitImpl(race, "Unit " + i));
            }
            return list;
        }
    }
}