using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class Unit : UnitInterface
    {
        public Unit(Race r, string s)
        {
            name = s;
            mov = 2;
            if (r.getName() == "humain")
            {
                hp = 15;
                atk = 6;
                def = 3;
                dis = 1;
            }
            else
            {
                if (r.getName() == "elfe")
                {
                    hp = 12;
                    atk = 4;
                    def = 3;
                    dis = 2;
                }
                else
                {
                    hp = 17;
                    atk = 5;
                    def = 2;
                    dis = 1;
                }
            }
        }

        public int atk
        {
            get
            {
                return atk;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int def
        {
            get
            {
                return def;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int dis
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int hp
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int mov
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Position positionUnit
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Race race
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void attack(Position p)
        {
            throw new NotImplementedException();
        }

        public bool isAlive()
        {
            return hp == 0;
        }

        public void move(Position p)
        {
            throw new NotImplementedException();
        }
    }
}