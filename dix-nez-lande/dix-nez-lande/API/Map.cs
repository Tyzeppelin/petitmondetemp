using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Map
    {
        public static const int BigMap = 16;
        public static const int MidMap = 10;
        public static const int LitMap = 6;
        int size { get; set; }
        List<Tile> tiles { get; set; }
    }
}