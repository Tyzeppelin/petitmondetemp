using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class GameBuilder
    {

        private int sizeMap;
        private Race player1Race;
        private String player1Name;
        private Race player2Race;
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

        public GameBuilder player1(String race, String name)
        {
            RaceFactory rF = RaceFactory.getRaceFactory();
            this.player1Race = rF.getRace(race);
            this.player1Name = name;
            return this;
        }

        public GameBuilder player2(String race, String name)
        {
            RaceFactory rF = RaceFactory.getRaceFactory();
            this.player2Race = rF.getRace(race);
            this.player2Name = name;
            return this;
        }

        public Game build()
        {
            Game res = new GameImpl();

            MapFactory mF = MapFactory.getMapFactory();
            UnitFactory uF = UnitFactory.getUnitFactory();
            PlayerFactory pF = PlayerFactory.getMapFactory();
            

            res.map = mF.createMap(sizeMap);
            Player player1 = pF.createPlayer(player1Race, player1Name);
            player1.units = uF.createArmy(player1Race, sizeMap);
            res.players.Add(player1);
            Player player2 = pF.createPlayer(player2Race, player2Name);
            player2.units = uF.createArmy(player2Race, sizeMap);
            res.players.Add(player2);
            return res;
        }

    }

}
