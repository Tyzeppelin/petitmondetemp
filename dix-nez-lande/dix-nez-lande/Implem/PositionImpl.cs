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
    public class PositionImpl : Position
    {
        private static List<Position> _instances = new List<Position>();
        private PositionImpl(int x, int y)
        {
            this._x = x;
            this._y = y;
            _instances.Add(this);
        }

        public static Position getPosition(int x, int y)
        {
            foreach(Position p in _instances)
            {
                if (p.x == x && p.y == y)
                {
                    return p;
                }
            }
            return new PositionImpl(x, y);

        }

        private int _x;
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
