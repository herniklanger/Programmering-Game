using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Programmer.Game.Objekter;
using System.Resources;

namespace Programmer.Game.AppData
{
    class FileHandler
    {
        int idCount;
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
        public List<Ithem> WorldLoad()
        {
            Stack<string> Element = new Stack<string>();
            List<Ithem> tihem = new List<Ithem>();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Git\C#\Programmering-Game\Resorces\Woarld\World.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Contains("<\\"+Element.Peek()+">"))
                {
                    Element.Pop();
                    
                }else if(lines[i].Contains("<\\"))
                {
                    throw new IOException("Fejl i databasen Elementer fungere ikke");
                }
                else if(lines[i].Contains("<"))
                {
                    Element.Push(lines[i].Replace("\t","").Replace("<",""));
                }else
                {
                    switch(Element.Peek())
                    {
                        case "Player":
                            List<int> houses = new List<int>();
                            List<int> workplace = new List<int>();
                            string player = lines[i++];
                            if (lines[i].Contains("<"))
                            {
                                Element.Push(lines[i].Replace("\t", "").Replace("<", ""));
                            }
                            while (Element.Peek()== "hus")
                            {
                                if (lines[i].Contains("<\\" + Element.Peek() + ">"))
                                {
                                    Element.Pop();

                                }
                                else if (lines[i].Contains("<\\"))
                                {
                                    throw new IOException("Fejl i databasen Elementer fungere ikke");
                                }
                                else if (lines[i].Contains("<"))
                                {
                                    Element.Push(lines[i].Replace("\t", "").Replace("<", ""));
                                }
                                else
                                {
                                    houses.Add(int.Parse(lines[i].Replace("\t", "")));
                                }
                                i++;
                            }
                            if (lines[i].Contains("<"))
                            {
                                Element.Push(lines[i].Replace("\t", "").Replace("<", ""));
                            }
                            i++;
                            while (!lines[i].Contains("<\\" + Element.Peek() + ">"))
                            {
                                if (lines[i].Contains("<\\" + Element.Peek() + ">"))
                                {
                                    Element.Pop();
                                }
                                else if (lines[i].Contains("<\\"))
                                {
                                    throw new IOException("Fejl i databasen Elementer fungere ikke");
                                }
                                else if (lines[i].Contains("<"))
                                {
                                    Element.Push(lines[i].Replace("\t", "").Replace("<", ""));
                                }
                                else
                                {
                                    workplace.Add(int.Parse(lines[i].Replace("\t", "")));
                                }
                                i++;
                            }
                            break;
                        case "Kareaktere":

                            break;
                        case "Store":
                            break;
                        case "Tree":
                            break;

                    }
                }
            }
            return tihem;
        }
        public Ithem[] LoadSaeft()
        {
            return null;
        }
        public int IDhandler(Ithem ithem)
        {
            IResourceWriter writer = new ResourceWriter("DataStoric");
            int i = int.Parse(DataStoric.ID);
            i++;
            writer.AddResource("ID",i.ToString());
            return i;
        }
        public void SaveWoarld(List<Ithem> save)
        {
            using (StreamWriter sw = File.CreateText(@"C:\Git\C#\Programmering-Game\Resorces\Woarld\World.txt"))
            {
                string Pree = "";
                sw.WriteLine(Pree + "<Woald>");
                Pree += "\t";
                sw.WriteLine(Pree + "<Kareaktere>");
                Pree += "\t";
                sw.WriteLine(Pree + "<Player>");
                Pree += "\t";
                foreach (Ithem select in save)
                {
                    if (select.GetType().Name == "Player")
                    {
                        sw.WriteLine(Pree + select.Save(Pree));
                    }
                }
                Pree = Pree.Remove(Pree.Length - 1);
                sw.WriteLine(Pree + "<\\Player>");
                foreach (Ithem select in save)
                {
                    if(select.GetKareakter() != null && select.GetType().Name != "Player")
                    {
                        sw.WriteLine(Pree + select.Save(Pree));
                    }
                }
                Pree = Pree.Remove(Pree.Length-1);
                sw.WriteLine(Pree + "<\\Kareaktere>");
                sw.WriteLine(Pree + "<Store>");
                Pree += "\t";
                foreach (Ithem select in save)
                {
                    if(select.GetType().Name == "Store")
                    {
                        sw.WriteLine(select.Save(Pree));
                    }
                }
                Pree = Pree.Remove(Pree.Length - 1);
                sw.WriteLine(Pree + "<\\Store>");
                sw.WriteLine(Pree + "<Tree>");
                Pree += "\t";
                foreach (Ithem select in save)
                {
                    if (select.GetType().Name == "Tree")
                    {
                        sw.WriteLine(select.Save(Pree));
                    }
                }
                Pree = Pree.Remove(Pree.Length - 1);
                sw.WriteLine(Pree + "\\Tree");
                Pree = Pree.Remove(Pree.Length - 1);
                sw.WriteLine(Pree + "<\\Woald>");
            }
        }
    }
}
