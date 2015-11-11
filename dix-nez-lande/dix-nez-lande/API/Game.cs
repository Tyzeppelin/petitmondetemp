using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    /**
    * Interface du jeu
    * @author François Boschet
    * @author Aurélien Fontaine
    * @version 0.1 (still in alpha)
    */
    public interface Game
    {
        Map map { get; set; }
        List<Player> players { get; set; }
        int nbTurn { get; set; }
    }

    

}