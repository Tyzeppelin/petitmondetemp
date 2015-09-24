using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Game
    {
        MapDum map
        {
            get;
            set;
        }

        List<Player> players
        {
            get;
            set;
        }
    }
}
