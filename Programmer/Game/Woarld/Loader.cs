using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
        public Ithem[] WorldLoad()
        {

            return null;
        }
        public Ithem[] LoadSaeft()
        {

            return null;
        }
        public void SaveWoarld(List<Ithem> save)
        {
            using (StreamWriter sw = File.CreateText(@"C:\Git\C#\Programmering-Game\Resorces\Woarld\World.txt"))
            {
                sw.WriteLine("<Woald>");
                for (int i = 0; save.Count > i; i++)
                {
                    if(save[i].GetKareakter() == null)
                    {
                        sw.WriteLine(save[i].Save());
                    }
                }
                sw.WriteLine("<\\Woald>");
            }
        }
    }
}
