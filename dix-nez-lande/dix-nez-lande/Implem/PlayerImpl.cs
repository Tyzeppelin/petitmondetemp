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
            get { return name; }
            set { name = value; }
        }

        public Race race
        {
            get { return race; }
            set { race = value; }
        }

        public List<Unit> units
        {
            get { return units; }

            set { units = value; }
        }

        public PlayerImpl(Race race, String name, List<Unit> units)
        {
            this.race = race;
            this.name = name;
            this.units = units;
        }

        public Unit  getUnit(int no)
        {
            return units[no];
        }

        public void setUnit(Unit u)
        {
            units.Add(u);
        }
    }
}
