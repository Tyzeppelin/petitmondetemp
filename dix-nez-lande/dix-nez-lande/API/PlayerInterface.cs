using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public interface PlayerInterface
    {
        string name
        {
            get;
            set;
        }

        RaceInterface race
        {
            get;
            set;
        }

        List<UnitInterface> units
        {
            get;
            set;
        }
        string getName();
        void setUnits(List<UnitInterface> list);

        RaceInterface getRace();
    }
}