using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace dix_nez_lande.Implem
{
    /**
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public class MapImpl : Map
    {

         #region Singleton

        private static Map _instance = null;

        public MapImpl() {
        }

        public static Map getMap()
        {
            if (_instance==null)
                _instance = new MapImpl();
            return _instance;
        }
        #endregion

        private int _size;
        public int size
        {
            get { return _size; }
            set { _size = value; }
        }

        private Tile[] _tiles;
        public Tile[] tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        private Dictionary<Position, List<Unit>> _units;
        public Dictionary<Position, List<Unit>> units
        {
            get { return _units; }
            set { _units = value; }
        }

        public MapImpl(int s)
        {
            //Utilisation de la dll cpp pour remplir
            //un tableau d'entier
            Algo a = new Algo();
            size = s;
            int nbTiles = size*size;
            int[] tab = a.FillMap(nbTiles);

            //Utilisation de ce tableau pour générer le
            //tableau de Tiles
            tiles = new Tile[nbTiles];
            TileFactory tf = TileFactoryImpl.getTileFactory();
            for (int i = 0; i < nbTiles; i++){
                tiles[i] = tf.getTile(tab[i]);
            }
        }

        public void placeArmy(Player p, int numPlayer)
        {
            Race r = p.race;
            Random rand = new Random();
            int pos = 0;
            if (numPlayer == 1)
            {
                while (!positionValide(pos, r))
                {
                    //On cherche une valeur aléatoire dans
                    //la moitié haute de la carte
                    pos = rand.Next(0, (size* size)/2);
                }
            }
            else
            {
                pos =(size*size)/2;
                while (!positionValide(pos, r))
                {
                    //On cherche une valeur aléatoire dans
                    //la moitié basse de la carte
                    pos = rand.Next((size*size)/2, size*size);
                }
            }
            int posX = pos % size;
            int posY = pos / size;
            Position position = PositionImpl.getPosition(posX, posY);
            foreach(Unit unit in p.units ) {
                unit.pos = position;
            }
        }

        private bool positionValide(int pos, Race r)
        {
            if (r.name != "human") {
                return (tiles[pos].GetType() != typeof(TileWater));
            }
            return true;
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

        public Boolean canMove(int x, int y, Race r)
        {
            return tiles[size * x + y].isAcceptable(r);
        }
    }
}
