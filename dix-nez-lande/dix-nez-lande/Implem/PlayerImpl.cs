using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class PlayerImpl : Player
    {
        public string name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Race race
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public List<Unit> units
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        public PlayerImpl(Race race, String name)
        {
            this.race = race;
            this.name = name;
            this.units = new List<Unit>();
        }
    }
}
