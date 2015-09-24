using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Player
    {
        string name
        {
            get;
            set;
        }

        Race race
        {
            get;
            set;
        }

        List<Unit> units
        {
            get;
            set;
        }
    }
}