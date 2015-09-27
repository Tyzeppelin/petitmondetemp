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

        public GameBuilder player1(String race, String name)
        {
            this.player1Race = race;
            this.player1Name = name;
            return this;
        }

        public GameBuilder player2(String race, String name)
        {
            this.player2Race = race;
            this.player2Name = name;
            return this;
        }

        public Game build()
        {
            Game res = new GameImpl();
            res.map = MapFactory.createMap(sizeMap);
            res.players.Add(PlayerFactory.createPlayer(player1Race, player1Name));
            res.players.Add(PlayerFactory.createPlayer(player2Race, player2Name));
            return res;
        }

    }

}
