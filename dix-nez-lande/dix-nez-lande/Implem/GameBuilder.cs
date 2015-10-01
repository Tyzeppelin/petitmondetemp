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
            Game res = new GameImpl();

            MapFactory mF = MapFactory.getMapFactory();
            PlayerFactory pF = PlayerFactory.getMapFactory();
            RaceFactory rF = RaceFactory.getRaceFactory();
            UnitFactory uF = UnitFactory.getUnitFactory();

            res.map = mF.createMap(sizeMap);

            Race p1Race = rF.getRace(player1Race);
            List<Unit> p1Army = uF.createArmy(p1Race, sizeMap);
            Player player1 = pF.createPlayer(p1Race, player1Name, p1Army);
            res.players.Add(player1);

            Race p2Race = rF.getRace(player2Race);
            List<Unit> p2Army = uF.createArmy(p2Race, sizeMap);
            Player player2 = pF.createPlayer(p2Race, player2Name, p2Army);
            res.players.Add(player2);

            return res;
        }

    }

}
