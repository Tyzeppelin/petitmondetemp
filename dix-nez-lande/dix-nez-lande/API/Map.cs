using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Map
    {
        List<Tile> tiles { get; set; }
    }
}