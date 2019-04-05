using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Game.OwnLiberry;
using System.IO;
using Game.Data;
using Game.Game.Objekter.Matic;

namespace Game.Game.Hotbar
{
    class Hotbar
    {
        TextureBrush[] b = new TextureBrush[1];
        Point[] points = new Point[8];
        double picture = 0;
        DoubeltLinkedLoopList SpelMenu;
        int select = 0;
        public Hotbar()
        {
            b[0] = new TextureBrush(Image.FromFile(@"C:\Git\C#\GameMinusAI\Resorce\HotBarImages\Unavngivet.png"));
            //Load Spels
            string[] spels = File.ReadAllLines(FilesLocation.SpelFileLocation);
            SpelMenu = new DoubeltLinkedLoopList();
            foreach (string s in spels)
            {
                SpelMenu.Add(new Spel(@"C:\Git\C#\GameMinusAI\Resorce\HotBarImages\SpelsMynsters\" + s + ".png", s));
            }
        }
        public void Draw(Graphics g)
        {
            picture = (picture + 60 / b.Length) % b.Length;
            Pen p = new Pen(Color.DarkBlue, 3);
            g.FillPolygon(b[(int)(picture)], points);
            g.DrawLine(p, points[0], points[7]);
            g.DrawLine(p, points[7], points[6]);
            g.DrawLine(p, points[6], points[5]);
            g.DrawLine(p, points[5], points[4]);
            g.DrawLine(p, points[4], points[3]);
            int z = (points[5].X - points[6].X) / 12;
            for (int i = 0; i < 10; i++)
            {
                if (i == select)
                {
                    p.Color = Color.ForestGreen;
                }else
                {
                    p.Color = Color.DarkBlue;
                }
                g.DrawRectangle(p, (points[6].X + z * i + 5 * i), points[7].Y, z, z);
                g.DrawImage(SpelMenu[i % SpelMenu.cound].symbol, (points[6].X + z * i + 5 * i), points[7].Y, z, z);
            }
        }
        public void rezaise()
        {
            points[0] = new Point(0, Game_Engen.Engen2D.Engenen2D().Heith - Game_Engen.Engen2D.Engenen2D().Heith / 5);
            points[1] = new Point(0, Game_Engen.Engen2D.Engenen2D().Heith);
            points[2] = new Point(Game_Engen.Engen2D.Engenen2D().Width, Game_Engen.Engen2D.Engenen2D().Heith);
            points[3] = new Point(Game_Engen.Engen2D.Engenen2D().Width, Game_Engen.Engen2D.Engenen2D().Heith - Game_Engen.Engen2D.Engenen2D().Heith / 5);
            points[4] = new Point(Game_Engen.Engen2D.Engenen2D().Width - Game_Engen.Engen2D.Engenen2D().Width * (5) / (6 * 3), Game_Engen.Engen2D.Engenen2D().Heith - Game_Engen.Engen2D.Engenen2D().Heith / 5);
            points[5] = new Point(Game_Engen.Engen2D.Engenen2D().Width - (Game_Engen.Engen2D.Engenen2D().Width * (1 + 1) / (6 * 1)), Game_Engen.Engen2D.Engenen2D().Heith - (Game_Engen.Engen2D.Engenen2D().Heith / 7));
            points[6] = new Point(Game_Engen.Engen2D.Engenen2D().Width * (1 + 1) / (6 * 1), Game_Engen.Engen2D.Engenen2D().Heith - (Game_Engen.Engen2D.Engenen2D().Heith / 7));
            points[7] = new Point((Game_Engen.Engen2D.Engenen2D().Width * (5) / (6 * 3)), Game_Engen.Engen2D.Engenen2D().Heith - Game_Engen.Engen2D.Engenen2D().Heith / 5);
        }
        public void MuveLeft(int x=1)
        {
            SpelMenu.MuveUp(x);
        }
        public void MuveRith(int x=1)
        {
            SpelMenu.MuveDown(x);
        }
        public void Selcet(int x)
        {
            select = x;
        }
        public string SelectedSpell()
        {
            return SpelMenu[select].name;
        }
    }
}