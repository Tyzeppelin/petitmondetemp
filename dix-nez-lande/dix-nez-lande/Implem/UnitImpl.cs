﻿using System;
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

        public Position position
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
            throw new NotImplementedException();
        }
    }
}