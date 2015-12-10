using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dix_nez_lande.Implem;
using System.Diagnostics;
using dix_nez_lande;

namespace desTests

{
    [TestClass]
    public class Gametest
    {
        [TestMethod]
        public void TestFact()
        {

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
        public void TestAlgo()
        {
            Algo algo = new Algo();
            int[] tab = algo.FillMap(4);
        }

       [TestMethod]
        public void TestBuilder()
        {
            GameBuilder g = GameBuilder.create();
            g = g.board(GameBuilder.LitMap).player1("francois", "human").player2("aurelien", "orc");
            Game tg = g.build();

            Assert.IsNotNull(tg);
        }
    }
}
