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
            return new PlayerImpl();
        }
    }
}
