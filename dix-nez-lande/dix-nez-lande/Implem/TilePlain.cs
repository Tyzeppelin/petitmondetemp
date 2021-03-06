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
    public class TilePlain : Tile
    {
        public String getName()
        {
            return "plain";
        }
        public int getPoints(Race r)
        {
            return (r.name == "human") ? 2 : 1;
        }
        public Boolean isAcceptable(Race r)
        {
            return true;
        }
    }
}
