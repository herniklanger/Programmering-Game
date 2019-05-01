using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Programmer.Game.Objekter;

namespace Programmer.Game.AppData
{
    class FileHandler
    {
        private static FileHandler instans =null;
        private string game;
        private FileHandler(string saift)
        {
            game = saift;
        }
        public static FileHandler Instans(string saif = "")
        {
            if(instans == null)
            {
                instans = new FileHandler(saif);
            }
            return instans;
        }
        public static FileHandler NewInstans(string saif)
        {
            instans = new FileHandler(saif);
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
                string Pree = "";
                sw.WriteLine("<Woald>");
                Pree += "\t";
                sw.WriteLine("<Kareaktere>");
                foreach (Ithem select in save)
                {
                    if(select.GetKareakter() != null)
                    {
                        sw.WriteLine("\t"+ select.Save());
                    }
                }
                Pree.Remove(Pree.Length-1);
                sw.WriteLine("<\\Kareaktere>");
                sw.WriteLine("<Store>");
                Pree += "\t";
                foreach (Ithem select in save)
                {
                    if(select.GetType().Name == "Store")
                    {
                        sw.WriteLine("\t" + select.Save());
                    }
                }
                sw.WriteLine("<\\Store>");
                sw.WriteLine("<\\Woald>");
            }
        }
    }
}
