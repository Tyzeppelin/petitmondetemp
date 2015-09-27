using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class RaceFactory
    {
        private RaceFactory() { }

        public static Race getHuman()
        {
            return new RaceImpl("human");
        }
        public static Race getOrc()
        {
            return new RaceImpl("orc");
        }
        public static Race getElve()
        {
            return new RaceImpl("elve");
        }
    }
}
