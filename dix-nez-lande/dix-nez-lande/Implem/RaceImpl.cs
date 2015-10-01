using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dix_nez_lande.Implem
{
    class RaceImpl : Race
    {
        public string name
        {
            get { return name; }
            set { name = value; }
        }

        public RaceImpl(String race)
        {
            this.name = race;
        }

        

    }
}
