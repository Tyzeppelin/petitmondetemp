using dix_nez_lande.Implem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class UnitImpl : Unit
    {
        public UnitImpl() { }

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
            /*Position pos = PositionImpl.getPosition();
            pos.moveTo(this, t);
            tile = t;*/
            // TODO : refaire ca
        }
    }
}