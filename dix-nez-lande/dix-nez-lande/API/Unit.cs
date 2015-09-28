using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Unit
    {
        int atk { get; set; }
        int def { get; set; }
        int mov { get; set; }
        int hp { get; set; }
        string name { get; set; }
        Race race { get; set; }
        Tile tile { get; set; }

        void attack(Tile t);
        void move(Tile t);
        bool isAlive();
    }
}