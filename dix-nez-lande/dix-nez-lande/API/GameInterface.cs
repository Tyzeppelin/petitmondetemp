using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface GameInterface
    {
        MapInterface map
        {
            get;
            set;
        }

        PlayerInterface[] players
        {
            get;
            set;
        }
    }
}
