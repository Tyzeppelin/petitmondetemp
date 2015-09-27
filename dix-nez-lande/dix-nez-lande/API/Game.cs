using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dix_nez_lande
{
    public class Game : GameInterface
    {
        public MapInterface map
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public PlayerInterface[] players
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Game(int size)
        {
            map = new Map(size);
            players = new PlayerInterface[2];
        }
    }
}