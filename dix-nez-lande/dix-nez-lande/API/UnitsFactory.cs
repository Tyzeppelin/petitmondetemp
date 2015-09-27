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

        private UnitsFactory() {
        }

        public static UnitsFactory getUnitFactory() {
        if(_instance == null)
            _instance = new UnitsFactory();
        return _instance;
        }
        #endregion

        void createUnits(PlayerInterface p, int nb) {
            List<UnitInterface> list = new List<UnitInterface>();
            for (int i = 0; i< nb; i++)
            {
                list.Add(new Unit(p.getRace(), "Unite"+i));
            }
            p.setUnits(list);
        }
    }
}