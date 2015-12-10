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
        #region Singleton

        private static Position _instance = null;

        private PositionImpl()
        {
        }

        public static Position getPosition()
        {
            if (_instance == null)
                _instance = new PositionImpl();
            return _instance;
        }
        #endregion

        public int x
        {
            get { return x; }
            set { x = value; }
        }

        public int y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
