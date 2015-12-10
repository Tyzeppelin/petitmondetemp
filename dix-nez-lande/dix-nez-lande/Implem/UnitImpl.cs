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
    public class UnitImpl : Unit
    {
        public UnitImpl() { hp = 0; }

        private int _atk;
        public int atk
        {
            get { return _atk; }
            set { _atk = value; }
        }

        private int _def;
        public int def
        {
            get { return _def; }
            set { _def = value; }
        }

        private int _dis;
        public int dis
        {
            get { return _dis; }
            set { _dis = value; }
        }

        private int _hp;
        public int hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        private int _mov;
        public int mov
        {
            get { return _mov; }
            set { _mov = value; }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Race _race;
        public Race race
        {
            get { return _race; }
            set { _race = value; }
        }

        private Position _pos;
        public Position pos
        {
            get { return _pos; }
            set { _pos = value; }
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