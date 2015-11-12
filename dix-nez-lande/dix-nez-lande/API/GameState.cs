using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface GameState
    {
        Player player1 { get; set; }
        Player player2 { get; set; }
        Dictionary<Position, List<Unit>> unitsPosition { get; set; }
    }
}