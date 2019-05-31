using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.IO;

namespace Programmer.Game.AppData.Database
{
    class DataBase
    {
        public delegate bool Select(object[] colonner);
        string Location;
        string Name { get; }
        const string DATABASE = "Database.txt";
        string[,] replace = { { "'", "'a" }, { "\n", "'n" } };
        public DataBase(string DatabaseLocation)
        {
            if (DatabaseLocation.Contains('\\'))
            {
                Name = DatabaseLocation.Substring(DatabaseLocation.LastIndexOf('\\') + 1);
                Location = DatabaseLocation.Remove(DatabaseLocation.LastIndexOf('\\') + 1);
            }
            else
            {
                Name = DatabaseLocation;
            }
            if (Name.Contains('.'))
            {
                Name = Name.Remove(Name.IndexOf("."));
            }

            //crere database vis den ikke eksistere
            if (!Directory.Exists(Location + Name) || !File.Exists(Location + Name + DATABASE))
            {
                Directory.CreateDirectory(Location + Name);
                File.CreateText(Location + Name + DATABASE).Close();
            }
        }
        public void CreadTabel(string name, Type[] variabler, string[] Names, bool id, bool[] Nullable, string[] TableforForenkeys = null)
        {
            //Om der skal oprettet en automatisk id
            if (id)
            {
                List<Type> list = new List<Type>();
                list.Add(Type.GetType("System.UInt32"));
                list.AddRange(variabler);
                variabler = list.ToArray();
                List<string> NyName = new List<string>();
                NyName.Add("IDName");
                NyName.AddRange(Names);
                Names = NyName.ToArray();
            }
            int FarenkyStart = Names.Length;
            //getting the forenkys for the other tabels
            //if(TableforForenkeys != null)
            //{
            //    List<Type> forenkeysType = new List<Type>();
            //    forenkeysType.AddRange(variabler);
            //    List<string> FarenkeysName = new List<string>();
            //    forenkeysType.AddRange(variabler);
            //    foreach (string s in TableforForenkeys)
            //    {
            //        if(GetColumsName(s)[0] == "IDName")
            //        {
            //            forenkeysType.Add(Type.GetType("System.Int32"));
            //            FarenkeysName.Add(s + "Farenkey");
            //        }
            //    }
            //    variabler = forenkeysType.ToArray();
            //    Names = FarenkeysName.ToArray();
            //}
            //fjerner ting franavnet vis det ved en fejl
            name = name.Replace("\\", "");
            if (name.Contains('.'))
            {
                name = name.Remove(name.IndexOf('.') - 1);
            }
            string file = "\\" + name + ".txt";
            //tjekker om tablellen existere og vis den existere får man valget alle
            if (File.Exists(Location + Name + file))
            {
                string message = "This table dos alredy exist do you want to override it?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    string[] database = File.ReadAllLines(Location + Name + DATABASE);
                    using (StreamWriter writ = new StreamWriter(Location + Name + DATABASE))
                    {
                        foreach (string s in database)
                        {
                            if (s.Equals(Name))
                            {
                                writ.WriteLine(s);
                            }
                        }
                    }
                    File.Delete(Location + Name + file);
                }
                else
                {
                    return;
                }
            }
            //Opretter Tabellen
            using (StreamWriter textWriter = new StreamWriter(Location + Name + DATABASE))
            {
                textWriter.WriteLine(name);
            }
            using (StreamWriter Writer = File.CreateText(Location + Name + file))
            {
                Writer.WriteLine("IDvalue = " + id + (id ? " 0" : ""));
                foreach (Type type in variabler)
                {
                    Writer.Write(type.Name + " ");
                }
                Writer.WriteLine();
                foreach (string clounomName in Names)
                {
                    Writer.Write(clounomName + " ");
                }
                Writer.WriteLine();
                if (TableforForenkeys != null)
                {
                    Writer.WriteLine();
                }
                Writer.WriteLine($"<{name}>");
                Writer.Write($"<\\{name}>");
            }
        }
        public void AddColums(Type[] variabler, string[] Names, string table)
        {
            if (variabler.Length == Names.Length)
            {
                string[] fil = File.ReadAllLines(Location + Name + "\\" + table + ".txt");
                object[,] Table = ReadAll(table);
                for (int x = 0; x < Table.GetLength(0); x++)
                {
                    fil[x] = "";
                    for (int y = 0; y < Table.GetLength(1); y++)
                    {
                        fil[x] += WriteCell(Table[x, y]);
                    }
                    for (int y = 0; y < Names.Length; y++)
                    {
                        if (variabler[y].Name == "Char" || variabler[y].Name == "String")
                        {
                            fil[y] += WriteCell("'\0' ");
                        }
                        else if (variabler[y].Name == "String")
                        {
                            fil[y] += WriteCell(DateTime.Now);
                        }
                        else
                        {
                            fil[y] += WriteCell(0);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("En af dem er ikke lige lange");
            }
        }
        public string[] GetTablesList()
        {
            return File.ReadAllLines(Location + Name + DATABASE);
        }
        public string[] GetColumsName(string table)
        {
            string colonums = File.ReadAllLines(Location + Name + "\\" + table + ".txt")[2];
            return colonums.Split(' ');
        }
        public Type[] GetColumType(string table)
        {
            string[] colonums = File.ReadAllLines(Location + Name + "\\" + table + ".txt")[1].Split(' ');
            Type[] colonumsType = new Type[colonums.Length - 1];
            for (int i = 0; i < colonumsType.Length; i++)
            {
                colonumsType[i] = Type.GetType("System." + colonums[i]);
            }
            return colonumsType;
        }
        // AddToTable
        public int AddToTabel(string tabel, object[] variabler)
        {
            string file = "\\" + tabel + ".txt";
            UInt32 ID = 0;
            if (File.Exists(Location + Name + file))
            {
                List<string> fil = File.ReadAllLines(Location + Name + file).ToList();
                if (fil[0].Contains("True"))
                {
                    ID = UInt32.Parse(fil[0].Substring(fil[0].LastIndexOf(' ')));
                    List<object> list = new List<object>();
                    list.Add(ID);
                    list.AddRange(variabler);
                    variabler = list.ToArray();
                    fil[0] = fil[0].Replace(ID + "", (ID + 1) + "");
                }
                string typer = fil[1];
                foreach (object variable in variabler)
                {
                    Type t = Type.GetType("System." + typer.Remove(typer.IndexOf(' ')));
                    if (variable.GetType() == Type.GetType("System." + typer.Remove(typer.IndexOf(' '))))
                    {
                        typer = typer.Substring(typer.IndexOf(' ') + 1);
                    }
                }
                string inset = "";
                //write Cels
                foreach (object variable in variabler)
                {
                    inset += WriteCell(variable);
                }
                fil.Insert(fil.Count - 1, inset);
                File.WriteAllLines(Location + Name + file, fil);
            }
            else
            {
                return -1;
            }
            return (int)ID;
        }
        public int AddToTabel(string tabel, object[] variabler, string[] columnsName)
        {
            string file = "\\" + tabel + ".txt";
            UInt32 ID = 0;
            if (File.Exists(Location + Name + file))
            {
                // loading file
                List<string> fil = File.ReadAllLines(Location + Name + file).ToList();
                if (fil[0].Contains("True"))
                {
                    ID = UInt32.Parse(fil[0].Substring(fil[0].LastIndexOf(' ')));
                    variabler = new object[] { ID }.Union(variabler).ToArray();
                    columnsName = new string[] { "IDName" }.Union(columnsName).ToArray();
                    fil[0] = fil[0].Replace(ID + "", (ID + 1) + "");
                }
                //fiding corespading colums
                int[] columsIndex = ColumIndex(columnsName, fil[2]);
                string[] types = GetInfo(fil[1]);
                string[] row = new string[types.Length];
                for (int i = 0; i < row.Length; i++)
                {
                    if (types[i] == "String")
                    {
                        row[i] = "'' ";
                    }
                    else if (types[i] == "Char")
                    {
                        row[i] = "'' ";
                    }
                    else if (types[i] == "DateTime")
                    {
                        row[i] = DateTime.MinValue.ToString("s") + " ";
                    }
                    else
                    {
                        row[i] = "0 ";
                    }
                }
                //finder id
                for (int i = 0; i < columsIndex.Length; i++)
                {
                    if (types[columsIndex[i]] == variabler[i].GetType().Name)
                    {
                        row[columsIndex[i]] = WriteCell(variabler[i]);
                    }
                }
                ;
                fil.Insert(fil.IndexOf("<\\Test>") - 1, string.Join("", row));
                return (int)ID;
            }
            return -1;
        }
        // Updatere variabler
        /// <summary>
        /// Update the wariabels where the Name Id;
        /// </summary>
        /// <param name="colonums"></param>
        /// <param name="variabler"></param>
        /// <param name="id"></param>
        /// <param name="tabel"></param>
        public void UpdateVariable(string[] colonums, object[] variabler, UInt32 id, string tabel)
        {
            string file = "\\" + tabel + ".txt";
            string[] fil = File.ReadAllLines(Location + Name + file);
            bool ContainsID = fil[0].Contains("True");
            int columonsCount = fil[2].Count(f => f == ' ');
            string columName = " " + fil[2];
            int[] columNummer = new int[colonums.Length];
            // typer
            string[] typer = new string[columonsCount];
            string type = fil[1];
            for (int i = 0; i < columonsCount; i++)
            {
                typer[i] = type.Remove(type.IndexOf(' '));
                type = type.Substring(type.IndexOf(' ') + 1);
            }
            //Omformer colonums to verdi
            for (int i = 0; i < columNummer.Length; i++)
            {
                columNummer[i] = columName.Remove(columName.IndexOf(" " + colonums[i] + " ")).Count(f => f == ' ');
            }
            for (int i = 0; i < columNummer.Length; i++)
            {
                if (Type.GetType("System." + typer[columNummer[i]]) != variabler[i].GetType())
                {
                    throw new TypeAccessException("Variablerne Stemmer ikke over ens tabellen " + typer[columNummer[i]] + " svare ikke til " + variabler[i].GetType());
                }
            }
            int start = 0;
            while (!fil[start++].Equals("<" + tabel + ">")) ;
            for (int i = start; fil[i] != "<\\" + tabel + ">"; i++)
            {
                if (fil[i].Remove(fil[i].IndexOf(' ')).Equals(id + ""))
                {
                    string[] cels = new string[columonsCount];
                    string row = fil[i];
                    for (int cel = 0; cel < columonsCount; cel++)
                    {
                        if (typer[cel].Equals("String") || typer[cel].Equals("Char"))
                        {
                            row = row.Substring(1);
                            cels[cel] = UndoReplace(row.Remove(row.IndexOf("' ")));
                            row = row.Substring(row.IndexOf("' ") + 2);
                        }
                        else
                        {
                            cels[cel] = row.Remove(row.IndexOf(' '));
                            row = row.Substring(row.IndexOf(' ') + 1);
                        }
                    }
                    //Chasing the cells
                    for (int chaceCel = 0; chaceCel < columNummer.Length; chaceCel++)
                    {
                        string s = variabler[chaceCel].ToString();
                        cels[columNummer[chaceCel]] = s;
                    }
                    //write Rows
                    string newRow = "";
                    for (int cel = 0; cel < cels.Length; cel++)
                    {
                        newRow += WriteCell(cels[cel], typer[cel]);
                    }
                    fil[i] = newRow;
                    File.Delete(Location + Name + file);
                    File.WriteAllLines(Location + Name + file, fil);
                    break;
                }
            }
        }
        public void UpdateVariable(Select seach, string[] seachColonums, string[] updateColonums, object[] variabler, string tabel)
        {
            string file = "\\" + tabel + ".txt";
            object[,] tablen = ReadAll(tabel);
            string[] fil = File.ReadAllLines(Location + Name + file);
            //typer
            string[] typer = new string[tablen.GetLength(1)];
            string type = fil[1];
            for (int i = 0; i < typer.Length; i++)
            {
                typer[i] = type.Remove(type.IndexOf(' '));
                type = type.Substring(type.IndexOf(' ') + 1);
            }
            //finder select colums
            int[] selectColonums = new int[seachColonums.Length];
            string columName = fil[2];
            for (int i = 0; i < seachColonums.Length; i++)
            {
                selectColonums[i] = columName.Remove(columName.IndexOf(seachColonums[i])).Count(f => f == ' ');
            }
            //finder updatede colums
            int[] updateColonumNr = new int[updateColonums.Length];
            string updateName = fil[2];
            for (int i = 0; i < updateColonums.Length; i++)
            {
                updateColonumNr[i] = columName.Remove(columName.IndexOf(updateColonums[i])).Count(f => f == ' ');
            }
#if DEBUG
            //tjeckker om det er rigtigt type
            for (int i = 0; i < updateColonums.Length; i++)
            {
                if (Type.GetType("System." + typer[updateColonumNr[i]]) != variabler[i].GetType())
                {
                    throw new TypeAccessException("Variablerne Stemmer ikke over ens tabellen " + typer[updateColonumNr[i]] + " svare ikke til " + variabler[i].GetType());
                }
            }
#endif
            //updatere celler
            for (int row = 0; row < tablen.GetLength(0); row++)
            {
                object[] seacher = new object[selectColonums.Length];
                for (int colum = 0; colum < selectColonums.Length; colum++)
                {
                    seacher[colum] = tablen[row, selectColonums[colum]];
                }
                if (seach(seacher))
                {
                    for (int colum = 0; colum < updateColonumNr.Length; colum++)
                    {
                        tablen[row, updateColonumNr[colum]] = variabler[colum];
                    }
                }
            }
            //rasten af oblysningner til at gemme med
            List<string> filWrither = new List<string>();
            foreach (string s in fil)
            {
                filWrither.Add(s);
                if (s.Equals("<" + tabel + ">"))
                {
                    break;
                }
            }
            //Write Cell
            for (int x = 0; x < tablen.GetLength(0); x++)
            {
                string row = "";
                for (int y = 0; y < tablen.GetLength(1); y++)
                {
                    row += WriteCell(tablen[x, y]);
                }
                filWrither.Add(row);
            }
            filWrither.Add("<\\" + tablen + ">");
            File.Delete(Location + Name + file);
            File.WriteAllLines(Location + Name + file, filWrither);
        }
        // Reader tables
        public object[,] ReadAll(string tabel)
        {
            string file = "\\" + tabel + ".txt";
            string[] linjer = File.ReadAllLines(Location + Name + file);
            int rakker = 0;
            while (!linjer[rakker++].Equals("<" + tabel + ">")) ;
            int colonner = linjer[2].Count(f => f == ' ');
            string[] typer = new string[colonner];
            string type = linjer[1];
            //typer gemt
            for (int i = 0; i < colonner; i++)
            {
                typer[i] = type.Remove(type.IndexOf(' '));
                type = type.Substring(type.IndexOf(' ') + 1);
            }
            object[,] tabellen = new object[linjer.Length - rakker - 1, colonner];
            //ReadTable
            for (int value = 0; rakker < linjer.Length - 1; rakker++, value++)
            {
                string linje = linjer[rakker];
                for (int celle = 0; celle < colonner; celle++)
                {
                    try
                    {
                        switch (typer[celle])
                        {
                            case "Boolean":
                                tabellen[value, celle] = Boolean.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Byte":
                                tabellen[value, celle] = Byte.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "SByte":
                                tabellen[value, celle] = SByte.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Int16":
                                tabellen[value, celle] = Int16.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "UInt16":
                                tabellen[value, celle] = UInt16.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Int32":
                                tabellen[value, celle] = Int32.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "UInt32":
                                tabellen[value, celle] = UInt32.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Int64":
                                tabellen[value, celle] = Int64.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "UInt64":
                                tabellen[value, celle] = UInt64.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "float":
                                tabellen[value, celle] = float.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Decimal":
                                tabellen[value, celle] = Decimal.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Double":
                                tabellen[value, celle] = Double.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "DateTime":
                                tabellen[value, celle] = DateTime.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "String":
                                tabellen[value, celle] = UndoReplace(linje.Substring(1).Remove(linje.IndexOf("' ") - 1));
                                linje = linje.Substring(linje.IndexOf("' ") + 2);
                                break;
                            case "Char":
                                tabellen[value, celle] = char.Parse(UndoReplace(linje.Substring(1).Remove(linje.IndexOf("' ") - 1)));
                                linje = linje.Substring(linje.IndexOf("' ") + 2);
                                break;
                            default:
                                Console.WriteLine("Kender ikke denne type\n" + type[celle]);
                                tabellen[value, celle] = null;
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        tabellen[value, celle] = null;
                    }
                }
            }
            return tabellen;
        }
        public object[] Read(string[] colonums, int id, string tabel)
        {
            object[] variable = new object[colonums.Length];
            string file = "\\" + tabel + ".txt";
            string[] fil = File.ReadAllLines(Location + Name + file);
            int colonner = fil[2].Count(f => f == ' ');
            int[] columNummer = new int[colonums.Length];
            string columName = fil[2];
            //Colums sece
            for (int i = 0; i < columNummer.Length; i++)
            {
                columNummer[i] = columName.Remove(columName.IndexOf(colonums[i])).Count(f => f == ' ');
            }
            //typer gemt
            string[] typer = new string[colonner];
            string type = fil[1];
            for (int i = 0; i < colonner; i++)
            {
                typer[i] = type.Remove(type.IndexOf(' '));
                type = type.Substring(type.IndexOf(' ') + 1);
            }
            int startRakke = 0;
            while (!fil[startRakke++].Equals("<" + tabel + ">")) ;
            int rakke = startRakke;
            while (!fil[rakke].Equals("<\\" + tabel + ">"))
            {
                if (fil[rakke].Remove(fil[rakke].IndexOf(' ')).Equals(id + ""))
                {
                    string linje = fil[rakke];
                    object[] celler = new object[colonner];
                    for (int celle = 0; celle < colonner; celle++)
                    {
                        string s;
                        switch (typer[celle])
                        {
                            case "Boolean":
                                celler[celle] = Boolean.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Byte":
                                celler[celle] = Byte.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "SByte":
                                celler[celle] = SByte.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Int16":
                                celler[celle] = Int16.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "UInt16":
                                celler[celle] = UInt16.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Int32":
                                celler[celle] = Int32.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "UInt32":
                                celler[celle] = UInt32.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Int64":
                                celler[celle] = Int64.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "UInt64":
                                celler[celle] = UInt64.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "float":
                                celler[celle] = float.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Decimal":
                                celler[celle] = Decimal.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "Double":
                                celler[celle] = Double.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "DateTime":
                                celler[celle] = DateTime.Parse(linje.Remove(linje.IndexOf(' ')));
                                linje = linje.Substring(linje.IndexOf(' ') + 1);
                                break;
                            case "String":
                                celler[celle] = UndoReplace(linje.Substring(1).Remove(linje.IndexOf("' "))); ;
                                linje = linje.Substring(linje.IndexOf("' ") + 2);
                                break;
                            case "Char":
                                celler[celle] = char.Parse(UndoReplace(linje.Substring(1).Remove(linje.IndexOf("' "))));
                                linje = linje.Substring(linje.IndexOf("' ") + 2);
                                break;
                            default:
                                Console.WriteLine("Kender ikke denne type\n" + type[celle]);
                                break;
                        }
                    }
                    for (int i = 0; i < columNummer.Length; i++)
                    {
                        variable[i] = celler[columNummer[i]];
                    }
                    break;
                }
                rakke++;
            }
            return variable;
        }
        public object[,] Read(Select seach, string[] seachColonums, string[] returnColonums, string tabel)
        {
            List<object[]> found = new List<object[]>();
            string file = "\\" + tabel + ".txt";
            string[] fil = File.ReadAllLines(Location + Name + file);
            //finder retunr colums
            int[] colonumsReturn = new int[returnColonums.Length];
            string columName = fil[2];
            for (int i = 0; i < returnColonums.Length; i++)
            {
                colonumsReturn[i] = columName.Remove(columName.IndexOf(returnColonums[i])).Count(f => f == ' ');
            }
            //finder select colums
            int[] selectColonums = new int[seachColonums.Length];
            columName = fil[2];
            for (int i = 0; i < seachColonums.Length; i++)
            {
                selectColonums[i] = columName.Remove(columName.IndexOf(seachColonums[i])).Count(f => f == ' ');
            }
            object[,] table = ReadAll(tabel);
            for (int row = 0; row < table.GetLength(0); row++)
            {
                object[] seachRow = new object[selectColonums.Length];
                for (int seac = 0; seac < selectColonums.Length; seac++)
                {
                    seachRow[seac] = table[row, selectColonums[seac]];
                }
                if (seach(seachRow))
                {
                    object[] re = new object[colonumsReturn.Length];
                    for (int seac = 0; seac < colonumsReturn.Length; seac++)
                    {
                        re[seac] = table[row, colonumsReturn[seac]];
                    }
                    found.Add(re);
                }
            }
            if (found.Count > 0)
            {
                object[,] tabelReturn = new object[found.Count, found[0].Length];
                for (int x = 0; x < found.Count; x++)
                {
                    for (int y = 0; y < found[x].Length; y++)
                    {
                        tabelReturn[x, y] = found[x][y];
                    }
                }
                return tabelReturn;
            }
            else
            {
                return null;
            }
        }
        // Update
        public void Delead(UInt32 id, string tabel)
        {
            string file = "\\" + tabel + ".txt";
            List<string> fil = File.ReadAllLines(Location + Name + file).ToList();
            if (fil[0].Contains("True"))
            {
                int rakkeSeach = 0;
                while (!fil[rakkeSeach++].Equals("<" + tabel + ">")) ;
                for (; !fil[rakkeSeach].Equals("<\\" + tabel + ">"); rakkeSeach++)
                {
                    if (fil[rakkeSeach].Remove(fil[rakkeSeach].IndexOf(' ')).Equals(id))
                    {
                        fil.RemoveAt(rakkeSeach);
                    }
                }
                File.Delete(Location + Name + file);
                File.WriteAllLines(Location + Name + file, fil);
            }
        }
        public void Delead(Select seach, string[] seachColonums, string tabel)
        {
            string file = "\\" + tabel + ".txt";
            string[] fil = File.ReadAllLines(Location + Name + file);
            object[,] table = ReadAll(tabel);
            int[] seachValues = new int[seachColonums.Length];
            string columns = fil[2];
            for (int i = 0; i < seachValues.Length; i++)
            {
                seachValues[i] = columns.Remove(columns.IndexOf(seachColonums[i])).Count(f => f == ' ');
            }
            object[] seacher = new object[seachValues.Length];
            File.Delete(Location + Name + file);
            int lineWirte = 0;
            using (StreamWriter Writer = File.CreateText(Location + Name + file))
            {
                do
                {
                    Writer.WriteLine(fil[lineWirte]);
                } while (!fil[lineWirte].Equals("<" + table + ">"));
                lineWirte += table.GetLength(0);
                for (int row = 0; row < table.GetLength(0); row++)
                {
                    for (int seachindex = 0; seachindex < seachValues.Length; seachindex++)
                    {
                        seacher[seachindex] = table[row, seachValues[seachindex]];
                    }
                    if (!seach(seacher))
                    {
                        for (int colum = 0; colum < table.GetLength(1); colum++)
                        {
                            Writer.Write(WriteCell(table[row, colum]));
                        }
                        Writer.WriteLine();
                    }
                }
                int lineWirter2 = lineWirte;
                while (fil[lineWirter2++].Equals("<\\" + table + ">")) ;
                for (int i = lineWirter2; i < fil.Length; i++)
                {
                    Writer.WriteLine(fil[i]);
                }
            }
        }
        // private Metoder
        private void Replace(ref string text)
        {
            for (int i = 0; i < replace.GetLength(0); i++)
            {
                text = text.ToString().Replace(replace[i, 0], replace[i, 1]);
            }
        }
        private string Replace(string text)
        {
            for (int i = 0; i < replace.GetLength(0); i++)
            {
                text = text.ToString().Replace(replace[i, 0], replace[i, 1]);
            }
            return text;
        }
        private string UndoReplace(string text)
        {
            for (int i = 0; i < replace.GetLength(0); i++)
            {
                text = text.Replace(replace[i, 1], replace[i, 0]);
            }
            return text;
        }
        private string WriteCell(object Variable)
        {
            if (Variable.GetType().Name == "Char" || Variable.GetType().Name == "String")
            {
                return "'" + Replace(Variable.ToString()) + "' ";
            }
            else if (Variable.GetType().Name == "DateTime")
            {
                return Variable == null ? DateTime.MinValue.ToString("s") + " " : ((DateTimeKind)Variable).ToString("s") + " ";
            }
            else
            {
                return Variable + " ";
            }
        }
        private string WriteCell(string Variable, string type)
        {
            if (type == "Char" || type == "String")
            {
                return "'" + Replace(Variable.ToString()) + "' ";
            }
            else if (type == "DateTime")
            {
                if (DateTime.TryParse(Variable, out DateTime datetime))
                {
                    return datetime.ToString("s") + " ";
                }
                else
                {
                    return DateTime.MinValue.ToString("s") + " ";
                }
            }
            else
            {
                return Variable + " ";
            }
        }
        private string[] GetInfo(string lest)
        {
            string[] Values = lest.Split(' ');
            Array.Resize(ref Values, Values.Length - 1);

            return Values;
        }
        private int[] ColumIndex(string[] colum, string tableColum)
        {
            int[] ret = new int[colum.Length];
            for (int col = 0; col < colum.Length; col++)
            {
                Console.WriteLine(tableColum.Remove(tableColum.IndexOf(colum[col])));
                ret[col] = tableColum.Remove(tableColum.IndexOf(colum[col])).Count(f => f == ' ');
            }
            return ret;
        }
    }
}