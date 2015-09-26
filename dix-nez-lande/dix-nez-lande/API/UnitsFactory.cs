using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class UnitsFactory
    {
        #region Singleton

        private static UnitsFactory _instance = null;
        private List<UnitInterface> unitsP1;
        private List<UnitInterface> unitsP2;

        private UnitsFactory() {
            unitsP1 = new List<UnitInterface>();
            unitsP2 = new List<UnitInterface>();
        }

        public static UnitsFactory getUnitFactory() {
        if(_instance == null)
            _instance = new UnitsFactory();
        return _instance;
        }
        #endregion

        void createUnits(Race r, Player p, int nb) {
            List<UnitInterface> list = new List<UnitInterface>();
            for (int i = 0; i< nb; i++)
            {
                list.Add(new Unit(r, "Unite"+i));
            }
            if (p.getName() == "p1")
            {
                unitsP1 = list;
            } else
            {
                unitsP2 = list;
            }
        }
    }
}