using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class PlayerFactory
    {
        private PlayerFactory() { }

        public static Player createPlayer(String race, String name)
        {
            Race r;
            switch(race)
            {
                case "human":
                    r = RaceFactory.getHuman();
                    break;
                case "orc":
                    r = RaceFactory.getOrc();
                    break;
                case "elve":
                    r = RaceFactory.getElve();
                    break;
                default:
                    // by default you're a human
                    r = RaceFactory.getHuman();
                    break;
            }
            return new PlayerImpl(r, name);
        }
    }
}
