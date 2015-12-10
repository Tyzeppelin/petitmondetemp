using System;
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
    public class RaceImpl : Race
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public RaceImpl(String race)
        {
            this.name = race;
        }
    }
}
