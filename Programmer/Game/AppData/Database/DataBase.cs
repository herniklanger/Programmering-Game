﻿using System;
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
        public DataBase(string DatabaseName)
        {
            Name = "\\" + DatabaseName;
            Location = Resource1.DataLocation;
            if (!Directory.Exists(Location + Name))
            {
                Directory.CreateDirectory(Location + Name);
            }
            File.CreateText(Location + Name + DATABASE).Close();
        }
        private void Replace(ref string text)
        {
            for (int i = 0; i < replace.GetLength(0); i++)
            {
                text = text.ToString().Replace(replace[i, 0], replace[i, 1]);
            }
        }
        private void UndoReplace(ref string text)
        {
            for (int i = 0; i < replace.GetLength(0); i++)
            {
                text = text.Replace(replace[i, 1], replace[i, 0]);
            }
        }
        public void CreadTabel(string name, Type[] variabler, string[] Names, bool id)
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
                Writer.WriteLine($"<{name}>");
                Writer.Write($"<\\{name}>");
            }
        }
        public bool AddToTabel(string tabel, object[] variabler)
        {
            string file = "\\" + tabel + ".txt";
            if (File.Exists(Location + Name + file))
            {
                List<string> fil = File.ReadAllLines(Location + Name + file).ToList();
                if (fil[0].Contains("True"))
                {
                    UInt32 ID = UInt32.Parse(fil[0].Substring(fil[0].LastIndexOf(' ')));
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
                foreach (object variable in variabler)
                {
                    if (variable.GetType() == Type.GetType("System.String") || variable.GetType() == Type.GetType("System.Char"))
                    {
                        string s = variable.ToString();
                        Replace(ref s);
                        inset += "'" + s + "' ";
                    }
                    else
                    {
                        inset += variable + " ";
                    }
                }
                fil.Insert(fil.Count - 1, inset);
                File.WriteAllLines(Location + Name + file, fil);
            }
            else
            {
                return false;
            }
            return true;
        }
        public void UpdateVariable(string[] colonums, object[] variabler, int id, string tabel)
        {
            string file = "\\" + tabel + ".txt";
            string[] fil = File.ReadAllLines(Location + Name + file);
            bool ContainsID = fil[0].Contains("True");
            int columonsCount = fil[2].Count(f => f == ' ');
            string columName = fil[2];
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
                columNummer[i] = columName.Remove(columName.IndexOf(colonums[i])).Count(f => f == ' ');
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
                            cels[cel] = row.Remove(row.IndexOf("' "));
                            row = row.Substring(row.IndexOf("' ") + 2);
                        }
                        else
                        {
                            cels[cel] = row.Remove(row.IndexOf(' '));
                            row = row.Substring(row.IndexOf(' ') + 1);
                        }
                    }
                    for (int chaceCel = 0; chaceCel < columNummer.Length; chaceCel++)
                    {
                        cels[columNummer[chaceCel]] = variabler[chaceCel].ToString();
                    }
                    string newRow = "";
                    for (int cel = 0; cel < cels.Length; cel++)
                    {
                        if (typer[cel].Equals("String") || typer[cel].Equals("Char"))
                        {
                            newRow += "'" + cels[cel].ToString().Replace("\n", "''") + "' ";
                        }
                        else
                        {
                            newRow += cels[cel] + " ";
                        }
                    }
                    fil[i] = newRow;
                    break;
                }
            }
            File.Delete(Location + Name + file);
            File.WriteAllLines(Location + Name + file, fil);
        }
        public void UpdateVariable(Select seach, string[] seachColonums, string[] updateColonums, object[] variabler, string tabel)
        {
            string file = "\\" + tabel + ".txt";
            object[,] tablen = ReadTable(tabel);
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
                object[] cles = new object[seachColonums.Length];
                for (int colum = 0; colum < cles.Length; colum++)
                {

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
            for (int x = 0; x < tablen.GetLength(0); x++)
            {
                string row = "";
                for (int y = 0; y < tablen.GetLength(1); y++)
                {
                    if (typer[y] == "String" || typer[y] == "Char")
                    {
                        row += "'" + tablen[x, y].ToString().Replace("\n", "''") + "' ";
                    }
                    else
                    {
                        row += tablen[x, y] + " ";
                    }
                }
                filWrither.Add(row);
            }
            filWrither.Add("<\\" + tablen + ">");
            File.Delete(Location + Name + file);
            File.WriteAllLines(Location + Name + file, filWrither);
        }
        public object[,] ReadTable(string tabel)
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
                            tabellen[value, celle] = linje.Substring(1).Remove(linje.IndexOf("' ") - 1).Replace("''", "\n");
                            linje = linje.Substring(linje.IndexOf("' ") + 2);
                            break;
                        case "Char":
                            tabellen[value, celle] = char.Parse(linje.Substring(1).Remove(linje.IndexOf("' ") - 1).Replace("''", "\n"));
                            linje = linje.Substring(linje.IndexOf("' ") + 2);
                            break;
                        default:
                            Console.WriteLine("Kender ikke denne type\n" + type[celle]);
                            break;
                    }
                }
            }
            return tabellen;
        }
        public object[] ReadTable(string[] colonums, int id, string tabel)
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
                                s = linje.Substring(1).Remove(linje.IndexOf("' ") - 1);
                                UndoReplace(ref s);
                                celler[celle] = s;
                                linje = linje.Substring(linje.IndexOf("' ") + 2);
                                break;
                            case "Char":
                                s = linje.Substring(1).Remove(linje.IndexOf("' ") - 1);
                                Replace(ref s);
                                celler[celle] = s[0];
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
        public object[,] ReadTable(Select seach, string[] seachColonums, string[] returnColonums, string tabel)
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
            object[,] table = ReadTable(tabel);
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
    }
}