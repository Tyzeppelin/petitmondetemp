﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface Player
    {
        String name { get; set; }
        Race race { get; set; }
        List<Unit> units { get; set; }

        Unit getUnit(int no);

        void setUnit(Unit u);
    }
}