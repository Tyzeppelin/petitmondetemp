using dix_nez_lande.Implem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class UnitImpl : Unit
    {
        public UnitImpl(Race r, string s)
        {
            name = s;
            mov = 2;
            switch (race.name)
            {
                case "human":
                    hp = 15;
                    atk = 6;
                    def = 3;
                    dis = 1;
                    break;
                case "elf":
                    hp = 12;
                    atk = 4;
                    def = 3;
                    dis = 2;
                    break;
                case "orc":
                    hp = 17;
                    atk = 5;
                    def = 2;
                    dis = 1;
                    break;
                default:
                    hp = 15;
                    atk = 6;
                    def = 3;
                    dis = 1;
                    break;
            }
            
        }

        public int atk
        {
            get { return atk; }
            set { atk = value; }
        }

        public int def
        {
            get { return def; }
            set { def = value; }
        }

        public int dis
        {
            get { return dis; }
            set { dis = value; }
        }

        public int hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public int mov
        {
            get { return mov; }
            set { mov = value; }
        }

        public string name
        {
            get { return name; }
            set { name = value; }
        }

        public Race race
        {
            get { return race; }
            set { throw new NotImplementedException(); }
        }

        public Tile tile
        {
            get { return tile; }
            set { throw new NotImplementedException(); }
        }

        public void attack(Tile t)
        {
            throw new NotImplementedException();
        }

        public bool isAlive()
        {
            return hp == 0;
        }

        public void move(Tile t)
        {
            Position pos = PositionImpl.getPosition();
            pos.moveTo(this, t);
            tile = t;
        }
    }
}