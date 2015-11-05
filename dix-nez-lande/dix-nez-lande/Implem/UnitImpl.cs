using dix_nez_lande.Implem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    class UnitImpl : Unit
    {
        public UnitImpl() { hp = 0; }

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
        public Position pos
        {
            get { return pos; }
            set { pos = value; }
        }



        public void attack(Position p)
        {
            MapImpl.getMap().attack(this, p);
        }

        public bool isAlive()
        {
            return hp <= 0;
        }

        public void move(Position p)
        {
            MapImpl.getMap().moveTo(this, p);
            pos = p;
        }
    }
}