using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Unit
    {
        int atk
        {
            get;
            set;
        }

        int def
        {
            get;
            set;
        }

        int hp
        {
            get;
            set;
        }

        int mov
        {
            get;
            set;
        }

        String name
        {
            get;
            set;
        }
        Race race { get; set; }
        Position positionUnit { get; set; }

        void attack(Position p);

        bool isAlive();

        void move();
    }
}