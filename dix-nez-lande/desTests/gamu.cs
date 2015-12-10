using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dix_nez_lande.Implem;
using dix_nez_lande;

namespace desTests

{
    [TestClass]
    public class Gametest
    {
        [TestMethod]
        public void TestBuilder()
        {
            // INIT
            GameBuilder g = GameBuilder.create();
            g = g.board(GameBuilder.LitMap).player1("francois", "human").player2("aurelien", "orc");
            Game tg = g.build();
            
            Player p1 = tg.players[0];
            Player p2 = tg.players[1];

            //qui de mieux ue jordy et willy pour représenter les hommes et les orcs
            Race jordy = RaceFactory.getRaceFactory().getRace("human");
            Race willy = RaceFactory.getRaceFactory().getRace("orc");

            // !! WARNING : FUN OVERFLOW !!

            Assert.AreEqual(tg.map.size, GameBuilder.LitMap);

            Assert.AreEqual(p1.name, "francois");
            Assert.AreEqual(p2.name, "aurelien");

            Assert.AreEqual(p1.race.name, jordy.name);
            Assert.AreEqual(p2.race.name, willy.name);
            
        }
    }
}
