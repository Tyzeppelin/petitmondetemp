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

            set { ouKilEst = value; }
        }

        void Position.moveTo(Unit u, Tile nouvelle)
        {
            Tile ancienne = u.tile;

            //Récupération de l'ancienne liste
            //supression de l'unité
            List<Unit> list;
            ouKilEst.TryGetValue(ancienne,out list);
            list.Remove(u);
            ouKilEst.Add(ancienne, list);

            //Récupération de la nouvelle liste
            //et ajout de l'unité
            ouKilEst.TryGetValue(nouvelle, out list);
            list.Add(u);
            ouKilEst.Add(nouvelle, list);
        }

        void Position.attack(Unit u, Tile t)
        {
            //On récupère la liste des défenseurs
            //présents sur la brique attaquée
            List<Unit> list;
            ouKilEst.TryGetValue(t, out list);

            //On récupère le "meilleur" defenseur
            Unit defenser = new UnitImpl();
            int nbUnits = list.Count();
            for (int i = 0; i < nbUnits; i++)
            {
                if (defenser.hp < list.ElementAt(i).hp)
                {
                    defenser = list.ElementAt(i);
                }
            }

            //L'attaquant tape une fois
            //Puis le defenseur tape s'il n'est pas mort
            defenser.hp -= u.atk - defenser.def;
            if (defenser.isAlive())
            {
                u.hp -= defenser.atk - u.def;
            }
        }
        
    }
}
