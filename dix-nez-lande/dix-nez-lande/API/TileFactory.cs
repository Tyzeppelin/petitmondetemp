using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /// <remarks>Flyweight factory</remarks>
    public interface TileFactory
    {
        Dictionary<String, Tile> instances { get; set; }

        Tile getTile(String type);
    }
}