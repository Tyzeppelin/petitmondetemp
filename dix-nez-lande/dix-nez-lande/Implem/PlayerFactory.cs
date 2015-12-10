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
    public class PlayerFactory
    {
        #region Singleton

        private static PlayerFactory _instance = null;

        private PlayerFactory() { }

        public static PlayerFactory getPlayerFactory()
        {
            if (_instance == null)
                _instance = new PlayerFactory();
            return _instance;
        }
        #endregion

        public Player createPlayer(Race race, String name, List<Unit> units)
        {
            Player p =  new PlayerImpl(race, name, units);
            p.points = 0;
            return p;

        }
    }
}
