using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class RaceFactory
    {
        #region Singleton

        private static RaceFactory _instance = null;

        private RaceFactory() { }

        public static RaceFactory getRaceFactory()
        {
            if (_instance == null)
                _instance = new RaceFactory();
            return _instance;
        }
        #endregion
        public Race getRace(String race)
        {
            switch (race)
            {
                case "human":
                    return this.getHuman();
                case "elf":
                    return this.getElf();
                case "orc":
                    return this.getOrc();
                default:
                    return this.getHuman();
            }
        }

        private Race getHuman()
        {
            return new RaceImpl("human");
        }
        private Race getOrc()
        {
            return new RaceImpl("orc");
        }
        private Race getElf()
        {
            return new RaceImpl("elf");
        }
    }
}
