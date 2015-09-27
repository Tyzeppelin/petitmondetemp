using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface UnitInterface
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
        RaceInterface race { get; set; }
        PositionInterface positionUnit { get; set; }
        int dis { get; set; }

        void attack(PositionInterface p);

        bool isAlive();

        void move(PositionInterface p);
    }
}