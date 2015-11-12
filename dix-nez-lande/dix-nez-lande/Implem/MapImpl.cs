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
    class MapImpl : Map
    {

         #region Singleton

        private static Map _instance = null;

        public MapImpl() {
            _instance = this;
        }

        public static Map getMap()
        {
            return _instance;
        }
        #endregion
        

        public int size
        {
            get { return size; }
            set { size = value; }
        }

        List<Tile> Map.tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public Dictionary<Position, List<Unit>> units
        {
            get { return units; }
            set { units = value; }
        }

        public void moveTo(Unit u, Position to)
        {
            Position from = u.pos;

            //Récupération de l'ancienne liste
            //supression de l'unité
            List<Unit> uList;
            units.TryGetValue(from, out uList);
            uList.Remove(u);
            units.Add(from, uList);

            //Récupération de la nouvelle liste
            //et ajout de l'unité
            units.TryGetValue(to, out uList);
            uList.Add(u);
            units.Add(to, uList);
        }

        public void attack(Unit attacker, Position p)
        {
            //On récupère la liste des défenseurs
            //présents sur la brique attaquée
            List<Unit> list;
            units.TryGetValue(p, out list);

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
            defenser.hp -= attacker.atk - defenser.def;
            if (defenser.isAlive())
            {
                attacker.hp -= defenser.atk - attacker.def;
            }
        }
    }
}
