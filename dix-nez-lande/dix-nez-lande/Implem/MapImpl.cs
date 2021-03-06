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

        private MapImpl() {
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
            int nbTiles = size * size;
            int[] tab = a.FillMap(size);

            //Utilisation de ce tableau pour générer le
            //tableau de Tiles
            tiles = new Tile[nbTiles];
            TileFactory tf = TileFactoryImpl.getTileFactory();
            for (int i = 0; i < nbTiles; i++){
                tiles[i] = tf.getTile(tab[i]);
            }

            int j,k;
            units = new Dictionary<Position, List<Unit>>();
            for (k = 0; k < size; k++)
                for (j = 0; j < size; j++)
                    units.Add(PositionImpl.getPosition(k, j), new List<Unit>());

            _instance = this;
            
        }

        public void placeArmy(Player p, int numPlayer)
        {
            Race r = p.race;
            Random rand = new Random(p.GetHashCode());
            int pos = 0, posX=0, posY=0, chgmentLigne=0; 
            if (numPlayer == 1)
            {
                posX = rand.Next(0, size);
                pos = posX + (size * posY);
                if (p.race.name != "human")
                {
                    Console.WriteLine("Attention, race non humaine pour le joueur 1");
                    Console.WriteLine("Position : "+pos);
                    Console.WriteLine("Tile type : " + tiles[pos].getName());
                    while (tiles[pos].getName() == "water")
                    {
                        Console.WriteLine("Position trouvée est sur l'eau pour joueur 1, on relance la recherche");
                        posX = rand.Next(0, size);
                        pos = posX + (size * posY);
                        Console.WriteLine("Tile type : " + tiles[pos].getName());
                        if (chgmentLigne > 20) posY++;
                        chgmentLigne++;
                    }
                }
            }
            else
            {
                posY = size - 1;
                posX = rand.Next(0, size);
                pos = posX + (size * posY);
                if (p.race.name != "human")
                {
                    Console.WriteLine("Attention, race non humaine pour le joueur 2");
                    Console.WriteLine("Position : " + pos);
                    Console.WriteLine("Tile type : " + tiles[pos].getName());
                    while (tiles[pos].getName() == "water")
                    {
                        Console.WriteLine("Position trouvée est sur l'eau pour joueur 2, on relance la recherche");
                        posX = rand.Next(0, size);
                        pos = posX + (size * posY);
                        Console.WriteLine("Tile type : " + tiles[pos].getName());
                        if (chgmentLigne > 20) posY++;
                        chgmentLigne--;
                    }
                }
            }
            
            Position position = PositionImpl.getPosition(posX, posY);
            foreach(Unit unit in p.units ) {
                unit.pos = position;
                List<Unit> u = new List<Unit>();
                units.TryGetValue(position, out u);
                u.Add(unit);
                units.Remove(position);
                units.Add(position, u);
            }
        }

        private bool positionValide(int pos, Race r)
        {
            if (r.name != "human") {
                return (tiles[pos].getName() != "water");
            }
            return true;
        }

        public void moveTo(Unit u, Position to)
        {

            if (!canMove(to.x, to.y, u.race) || !accessible(to, u) || u.aBouge) { }
            else
            {
                Console.WriteLine("L'unite " + u.name + " bouge de (" + u.pos.x + "," + u.pos.y + ") en (" + to.x + "," + to.y + ")");
                Position from = u.pos;

                //Récupération de l'ancienne liste
                //supression de l'unité
                List<Unit> uList;
                units.TryGetValue(from, out uList);
                uList.Remove(u);
                units.Remove(from);
                units.Add(from, uList);

                //Récupération de la nouvelle liste
                //et ajout de l'unité
                units.TryGetValue(to, out uList);
                uList.Add(u);
                units.Remove(to);
                units.Add(to, uList);
                u.move(to);
            }
        }

        public bool attack(Unit attacker, Position p)
        {
            if (!canMove(p.x, p.y, attacker.race) || !accessible(p, attacker) || attacker.aBouge) { return false; }
            else {
                //On récupère la liste des défenseurs
                //présents sur la brique attaquée
                List<Unit> list = new List<Unit>();
                this.units.TryGetValue(p, out list);
                if (list.Count == 0) { return false; }

                //On récupère le "meilleur" defenseur
                Unit defenser = list[0];
                foreach (Unit u in list)
                {
                    if (defenser.hp < u.hp)
                    {
                        defenser = u;
                    }
                }

                //L'attaquant tape une fois
                //Puis le defenseur tape s'il n'est pas mort
                Console.WriteLine("L'unite " + attacker.name + " attaque " + defenser.name + ".");
                defenser.hp -= attacker.atk - defenser.def;
                if (defenser.isAlive())
                {
                    Console.WriteLine("L'unite " + defenser.name + " riposte.");
                    attacker.hp -= defenser.atk - attacker.def;
                    attacker.aBouge = true;
                    if (!attacker.isAlive())
                    {
                        list.Remove(attacker);
                        this.units.Remove(p);
                        this.units.Add(p, list);
                    }
                    return false;
                    Console.WriteLine(attacker.name + " : " + attacker.hp + " points de vie");
                    Console.WriteLine(attacker.name + " : " + defenser.hp + " points de vie");
                }
                else
                {
                    list.Remove(defenser);
                    this.units.Remove(p);
                    this.units.Add(p, list);
                    return list.Count == 0;
                    Console.WriteLine(attacker.name + " : " + attacker.hp + " points de vie");
                    Console.WriteLine(attacker.name + " : " + defenser.hp + " points de vie");
                }
            }
        }

        public bool canMove(int x, int y, Race r)
        {
            return tiles[size * y + x].isAcceptable(r);
        }

        public bool accessible(Position p, Unit u)
        {
            bool a = Math.Abs(u.pos.x - p.x) + Math.Abs(u.pos.y - p.y) <= u.mov;
            Console.WriteLine("La position ("+ p.x + "," + p.y +") est accessible ? "+a);
            return a;
        }

        public int getPoints(Player p)
        {
            int cpt = 0;
            List<Position> lp = p.points;
            foreach(Position pos in lp)
            {
                string tile = tiles[pos.x + size * pos.y].getName();
                switch (p.race.name)
                {
                    case "human":
                        if (tile == "plain") cpt += 2;
                        else if (tile == "water") { }
                        else cpt ++;
                        break;
                    case "elf":
                        if (tile == "forest") cpt += 3;
                        else if (tile == "plain") cpt++;
                            break;
                    case "orc":
                        if (tile == "mountain") cpt += 2;
                        else if (tile == "plain" || tile == "forest") cpt++;
                        break;
                    default:
                        break;

                }
            }
            return cpt;
        }
    }
}
