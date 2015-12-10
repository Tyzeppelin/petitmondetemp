using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface History
    {
        GameState stateToSave { get; set; }
        List<GameState> states { get; set; }
        GameState getLastState();
        // Set the game to the state it were at GameState g.
        void set(GameState g);
        void save();
        GameState pop();
    }
}