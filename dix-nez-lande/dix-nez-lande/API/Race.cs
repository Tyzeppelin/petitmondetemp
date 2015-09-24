using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Race
    {
        string name
        {
            get;
            set;
        }
    }

    public interface Tile
    {
    }

    public interface GameDum
    {
        MapDum map
        {
            get;
            set;
        }

        List<Player> players
        {
            get;
            set;
        }
    }

    public interface MapDum
    {
        int size
        {
            get;
            set;
        }

        List<Tile> tiles
        {
            get;
            set;
        }
    }
    public interface Player
    {
        string name
        {
            get;
            set;
        }

        Race race
        {
            get;
            set;
        }

        List<Unit> units
        {
            get;
            set;
        }
    }

    public interface Unit
    {
        String name
        {
            get;
            set;
        }

        int hp
        {
            get;
            set;
        }

        Race race
        {
            get;
            set;
        }

        int mov
        {
            get;
            set;
        }

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

        bool isAlive();

        void attack();

        void defend();

        void move();
    }
}
