using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmer.Game.AppData.Database;
using Programmer.Game.Objekter;

namespace Programmer.Game.AppData
{
    class DataBaseHandling
    {
        public static DataBaseHandling instanse = null;
        DataBase db;
        private DataBaseHandling()
        {
            db = new DataBase("C:\\Git\\C#\\Programmering-Game\\Programmer\\Resoirces\\Woarld\\GameWorld");
        }
        public static DataBaseHandling Iniselise()
        {
            if(instanse == null)
            {
                instanse = new DataBaseHandling();
            }
            return instanse;
        }
        public void Save(Ithem[] save)
        {
            string[] tabelsName = db.GetTablesList();
            foreach (Ithem obj in save)
            {
                object[] ithem = obj.Save();
                if ((int)ithem[0] == -1)
                {
                    List<object> lis = ithem.ToList();
                    lis.RemoveAt(0);
                    ithem = lis.ToArray();
                    if (tabelsName.Contains(save.GetType().Name))
                    {

                        Type[] type = new Type[ithem.Length];
                        List<string> columsNames = obj.ValuseName().ToList();
                        columsNames.RemoveAt(0);
                        for (int i = 0; i < type.Length; i++)
                        {
                            type[i] = ithem[i].GetType();
                        }
                        db.CreadTabel(obj.GetType().Name, type, columsNames.ToArray(), true, null);
                        tabelsName = db.GetTablesList();
                    }
                    db.AddToTabel(obj.GetType().Name, ithem);
                }else
                {
                    uint id = (uint)(int)ithem[0];
                    List<object> lis = ithem.ToList();
                    lis.RemoveAt(0);
                    ithem = lis.ToArray();

                    List<string> columsNames = obj.ValuseName().ToList();
                    columsNames.RemoveAt(0);

                    db.UpdateVariable(columsNames.ToArray(), ithem, id, obj.GetType().Name);
                }
            }
        }
        public List<Ithem> Load()
        {
            List<Ithem> ith = new List<Ithem>();
            string[] tabels = db.GetTablesList();
            foreach(string table in tabels)
            {
                object[,] ithems = db.ReadAll(table);
                for(int i = 0; i < ithems.GetLength(0);i++)
                {
                    switch(table)
                    {
                        case "Tree":
                            ith.Add(new Tree((int)(uint)ithems[i, 0], (string)ithems[i, 1], (int)ithems[i, 2], (int)ithems[i, 3], (int)ithems[i, 4]));
                            break;
                    }
                }
            }
            return ith;
        }
    }
}
