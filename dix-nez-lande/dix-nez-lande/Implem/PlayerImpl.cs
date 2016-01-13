using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    /**
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public class PlayerImpl : Player
    {
        private string _name;
        public string name
        { get { return _name; }
          set { _name = value; }
        }

        private Race _race;
        public Race race
        {
            get { return _race; }
            set { _race = value; }
        }

        private List<Unit> _units;
        public List<Unit> units
        {
            get { return _units; }
            set { _units = value; }
        }

        private int _points;
        public int points
        {
            get { return _points; }
            set { _points = value; }
        }

        public PlayerImpl(Race race, String name, List<Unit> units)
        {
            this.race = race;
            this.name = name;
            this.units = units;
        }

        public Unit getUnit(int no)
        {
            return units[no];
        }

        public Unit getUnit(int Col, int Row)
        {
            Position pos = PositionImpl.getPosition(Col, Row);
            int n = units.Count;
            for (int i = 0; i < n; i++)
            {
                if (units[i].pos == pos) return units[i];
            }   
            return units[0];
        }

        public void setUnit(Unit u)
        {
            units.Add(u);
        }
    }
}
