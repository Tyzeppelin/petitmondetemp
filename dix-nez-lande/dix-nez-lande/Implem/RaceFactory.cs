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
    public class RaceFactory
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
            Race r;
            switch (race) {
                case "human":
                    r = new RaceImpl("human");
                    break;
                case "elf":
                    r = this.getElf();
                    break;
                case "orc":
                    r = this.getOrc();
                    break;
                default:
                    r = this.getHuman();
                    break;
            }
            return r;
        }

        public Race getHuman()
        {
            return new RaceImpl("human");
        }
        public Race getOrc()
        {
            return new RaceImpl("orc");
        }
        public Race getElf()
        {
            Race r = new RaceImpl("elf");
            return r;
        }
    }
}
