using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Position
    {
        Dictionary<Tile, List<Unit>> ouKilEst { get; set; }

        void moveTo(Unit u, Tile t);
        void attack(Unit attacker , Tile t);
    }
}