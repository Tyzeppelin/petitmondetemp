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
        private PositionImpl(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Position getPosition(int x, int y)
        {
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
