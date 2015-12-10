using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dix_nez_lande.Implem;
using System.Diagnostics;
using dix_nez_lande;

namespace desTests {
    [TestClass]
    public class Gametest {
        [TestMethod]
        public void TestFact() {

            RaceFactory rf = RaceFactory.getRaceFactory();
            Assert.IsNotNull(rf);
            Race jordy = rf.getRace("human");
            Race willy = rf.getRace("orc");

            PlayerFactory pf = PlayerFactory.getPlayerFactory();
            Player p1 = pf.createPlayer(jordy, "francois", null);
            Assert.AreEqual(p1.name, "francois");
            Player p2 = pf.createPlayer(willy, "aurelien", null);
            Assert.AreEqual(p2.name, "aurelien");

            Assert.AreEqual(p1.race.name, jordy.name);
            Assert.AreEqual(p2.race.name, willy.name);

            History h = HistoryFactory.getHistoryFactory().createHistory();
            Assert.IsNotNull(h);

            GameStateFactory gsf = GameStateFactory.getStateFactory();
            GameState gs = gsf.createGameState();
            h.set(gs);
            h.save();

            Assert.AreEqual(h.pop(), gs);

        }

        [TestMethod]
        public void TestAlgo() {
            Algo algo = new Algo();
            int[] tab = algo.FillMap(4);
            List<int> mm = new List<int>(tab);
            Assert.AreEqual(mm.Count, 16);
        }

       [TestMethod]
        public void TestBuilder() {
            GameBuilder g = GameBuilder.create();
            g = g.board(GameBuilder.LitMap).player1("francois", "human").player2("aurelien", "orc");
            Game tg = g.build();
            Assert.IsNotNull(tg);

            Assert.AreEqual(tg.current.name, "francois");
            Assert.AreEqual(tg.map.tiles.Length, GameBuilder.LitMap* GameBuilder.LitMap);
            Assert.AreEqual(tg.players[0].points, 0);
            Assert.AreEqual(tg.saveStates.states.Count, 0);
        }

        [TestMethod]
        public void TestBehaviour() {
            GameBuilder g = GameBuilder.create();
            g = g.board(GameBuilder.LitMap).player1("francois", "human").player2("aurelien", "orc");
            Game tg = g.build();
            Assert.IsNotNull(tg);

            tg.players[0].points = 12;

            Assert.AreEqual(tg.whoWin(), tg.players[0]);

            tg.start();
            Assert.IsTrue(tg.current == tg.players[0] || tg.current == tg.players[1]);
            
            tg.beginTurn();
            tg.nbTurn = 2;
            tg.endTurn();
            Assert.AreEqual(tg.nbTurn, 1);

            Player old_cur = tg.current;
            tg.switchPlayer();
            Assert.AreNotEqual(tg.current, old_cur);
        }
    }
}
