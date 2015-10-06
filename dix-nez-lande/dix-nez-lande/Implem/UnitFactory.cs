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

        private Unit createUnit(Race race, String s)
        {
            Unit u = new UnitImpl();
            u.name = s;
            u.mov = 2;
            switch (race.name)
            {
                case "human":
                    u.hp = 15;
                    u.atk = 6;
                    u.def = 3;
                    u.dis = 1;
                    break;
                case "elf":
                    u.hp = 12;
                    u.atk = 4;
                    u.def = 3;
                    u.dis = 2;
                    break;
                case "orc":
                    u.hp = 17;
                    u.atk = 5;
                    u.def = 2;
                    u.dis = 1;
                    break;
                default:
                    u.hp = 15;
                    u.atk = 6;
                    u.def = 3;
                    u.dis = 1;
                    break;
            }
            return u;
        }

        public List<Unit> createArmy(Race race, int sizeArmy)
        {
            
            List<Unit> list = new List<Unit>();
            for (int i = 0; i < sizeArmy; i++)
            {
                //voir nomdefantasy.com pour plus de pimp
                list.Add(createUnit(race, "Unit " + i));
            }
            return list;
        }
    }
}