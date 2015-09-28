using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class PositionImpl : Position
    {
        #region Singleton

        private static PositionImpl _instance = null;

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

        public Dictionary<Tile, List<Unit>> ouKilEst
        {
            get { return ouKilEst;  }

            set { throw new NotImplementedException(); }
        }

        void Position.moveTo(Unit u, Tile nouvelle)
        {
            Tile ancienne = u.tile;
            List<Unit> list;

            //Récupération de l'ancienne liste
            //supression de l'unité
            ouKilEst.TryGetValue(ancienne,out list);
            list.Remove(u);
            ouKilEst.Add(ancienne, list);

            //Récupération de la nouvelle liste
            //et ajout de l'unité
            ouKilEst.TryGetValue(nouvelle, out list);
            list.Add(u);
            ouKilEst.Add(nouvelle, list);
        }
        
    }
}
