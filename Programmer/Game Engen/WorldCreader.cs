using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using Programmer.Game.Objekter;

namespace Programmer.Game_Engen
{
    class WorldCreader : Engen
    {
        Form2 selectore;
        private static WorldCreader instans;
        private WorldCreader(int width, int heith) : base(width, heith)
        {
            selectore = new Form2();
            selectore.Show();
        }
        public static WorldCreader Instans(int width = 600, int heith = 800)
        {
            if (instans == null)
            {
                instans = new WorldCreader(width, heith);
            }
            return instans;
        }
        public override void Garphish(Graphics g)
        {
            g.DrawRectangle(new Pen (new SolidBrush(Color.FromArgb(127,255,0,0))), (Grid==0?0:MouseX / Grid) * Grid, (Grid == 0 ? 0 : MouseY / Grid) * Grid, 6 * Grid, 2 * Grid);
            foreach (Ithem i in objekter)
            {
                i.Draw(g, ScreenX, ScreenY, Grid, Grid);
            }
        }
        public override Ithem IsThisfealtEmty(int x, int y)
        {
            foreach (Ithem ithem in objekter)
            {
                if (ithem.X <= x && ithem.X + ithem.Width > x && ithem.Y <= y && ithem.Y + ithem.Heith > y)
                {
                    return ithem;
                }
            }
            return null;
        }
        internal override void Game()
        {
            bool LeftClik = false;
            while(true)
            {
                if (LeftClik && !mouseLeft)
                {
                    Console.WriteLine("TryToPlace");
                    switch (selectore.Ithems.Invoke(selectore.GetSelected))
                    {
                        case "Store":
                            Console.WriteLine("Store Plaest");
                            break;
                        default:
                            Console.WriteLine("Dette Ithem er ikke kendet");
                            break;
                    }
                    //Place(new House("House",(MouseX / Grid) + ScreenX, (MouseY / Grid) + ScreenY, 8, 5));
                }
                LeftClik = mouseLeft;
                Thread.Sleep(1);
            }
        }
        public void Place(Ithem ithem)
        {
            for (int x = 0; x > ithem.Width; x++)
            {
                for (int y = 0; y > ithem.Heith; y++)
                {
                    if(null==IsThisfealtEmty(x+ithem.X,y+ithem.Y))
                    {
                        Console.WriteLine("Not able to place");
                        return;
                    }
                }
            }
            objekter.Add(ithem);
        }
    }
}
