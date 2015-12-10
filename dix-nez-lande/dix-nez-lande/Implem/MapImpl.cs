﻿using System;
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
            _instance = this;
        }

        public static Map getMap()
        {
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
