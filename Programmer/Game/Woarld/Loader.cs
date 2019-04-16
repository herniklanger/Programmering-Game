using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmer.Game.Objekter;

namespace Programmer.Game.Woarld
{
    class Loader
    {
        private static Loader instans =null;
        private string game;
        private Loader(string saift)
        {
            game = saift;
        }
        public static Loader Instans(string saif = "")
        {
            if(instans == null)
            {
                instans = new Loader(saif);
            }
            return instans;
        }
        public static Loader NewInstans(string saif)
        {
            instans = new Loader(saif);
            return instans;
        }
        public Ithem[] World()
        {

            return null;
        }

    }
}
