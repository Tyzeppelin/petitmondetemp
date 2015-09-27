using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class Player : PlayerInterface
    {
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

        public RaceInterface race
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

        public List<UnitInterface> units
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

        public string getName()
        {
            throw new NotImplementedException();
        }

        public RaceInterface getRace()
        {
            throw new NotImplementedException();
        }

        public void setUnits(List<UnitInterface> list)
        {
            throw new NotImplementedException();
        }

        public Player(RaceInterface r, string s)
        {
            race = r;
            name = s;
        }
    }
}