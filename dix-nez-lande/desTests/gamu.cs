using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dix_nez_lande.Implem.;

namespace desTests { }

{
    [TestClass]
    public class Gametest
    {
        [TestMethod]
        public void TestBuilder(int SizeMap)
        {
            GameBuilder g;
            g.create().board(GameBuilder.LitMap).player1("francois", "humain").player2("aurelien", "orc");

            //tests g quand j'aurai l'autocompletion



        }
    }
}
