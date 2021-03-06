﻿using System;
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
    public class GameBuilder
    {
        public const int BigMap = 16;
        public const int MidMap = 10;
        public const int LitMap = 6;

        public const int BigArmy = 8;
        public const int MidArmy = 6;
        public const int LitArmy = 4;

        public const int BigTurn = 30;
        public const int MidTurn = 20;
        public const int LitTurn = 5;


        private int sizeMap;
        private String player1Race;
        private String player1Name;
        private String player2Race;
        private String player2Name;

        private GameBuilder() { }

        public static GameBuilder create()
        {
            return new GameBuilder();
        }

        public GameBuilder board(int size)
        {
            this.sizeMap = size;
            return this;
        }

        public GameBuilder player1(String name, String race)
        {
            this.player1Name = name;
            this.player1Race = race;
            return this;
        }

        public GameBuilder player2(String name, String race)
        {
            this.player2Name = name;
            this.player2Race = race;
            return this;
        }

        public Game build()
        {
            Random rnd = new Random();
            Game game = new GameImpl();

            // Creation de la carte de la taille voulue
            // ainsi que le nombre de tours associés
            MapStrategy mS;
            switch (this.sizeMap) {
                case GameBuilder.LitMap:
                    mS = LitMapFactory.getMapStrategy();
                    game.nbTurn = LitTurn * 2;
                    break;
                case GameBuilder.MidMap:
                    mS = MidMapFactory.getMapStrategy();
                    game.nbTurn = MidTurn * 2;
                    break;
                case GameBuilder.BigMap:
                    mS = BigMapFactory.getMapStrategy();
                    game.nbTurn = BigTurn * 2;
                    break;
                default:
                    mS = LitMapFactory.getMapStrategy();
                    break;

            }


            PlayerFactory pF = PlayerFactory.getPlayerFactory();
            RaceFactory rF = RaceFactory.getRaceFactory();
            UnitFactory uF = UnitFactory.getUnitFactory();

            game.map = mS.createMap();

            Race p1Race = rF.getRace(player1Race);
            List<Unit> p1Army = uF.createArmy(p1Race, mS.getSizeArmy());
            Player player1 = pF.createPlayer(p1Race, player1Name, p1Army);
            game.map.placeArmy(player1, 1);

            Race p2Race = rF.getRace(player2Race);
            List<Unit> p2Army = uF.createArmy(p2Race, mS.getSizeArmy());
            Player player2 = pF.createPlayer(p2Race, player2Name, p2Army);
            game.map.placeArmy(player2, 2);

            List<Player> pl = new List<Player>();
            pl.Add(player1);
            pl.Add(player2);
            game.players = pl;

            game.current = game.players[rnd.Next(0,1)];

           // game.nbTurn = 0;

            History h = HistoryFactory.getHistoryFactory().createHistory();
            game.saveStates = h;

            GameState gs = GameStateFactory.getStateFactory().createGameState();
            gs.player1 = game.players[0];
            gs.player2 = game.players[1];
            gs.nbTurn = game.nbTurn;
            gs.units = game.map.units;
            game.saveStates.set(gs);
            game.saveStates.save();
            game.saveStates.set(GameStateFactory.getStateFactory().createGameState());

            return game;
        }
    }
}
