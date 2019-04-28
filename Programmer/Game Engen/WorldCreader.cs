using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using Programmer.Game.Objekter;

namespace Programmer.Game_Engen
{
    class WorldCreader : Engen
    {
        public static Form1 form;
        private static Form2 selectore;
        private static WorldCreader instans;
        private WorldCreader(int width, int heith) : base(width, heith)
        {
            selectore = new Form2();
            selectore.Show();
        }
        public static WorldCreader Instans(Form1 f,int width = 600, int heith = 800)
        {
            form = f;
            if (instans == null)
            {
                instans = new WorldCreader(width, heith);
            }
            return instans;
        }
        public override void Garphish(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black),0,0,20,20);
            g.FillPolygon(new SolidBrush(Color.LightGreen), new Point[] { new Point(5, 5), new Point(5, 15), new Point(15, 10) });
            selectore.DrawSelected(g, (Grid == 0 ? 0 : MouseX / Grid)-1, (Grid == 0 ? 0 : MouseY / Grid)-1,Grid);
            lock (objektLock)
            {
                foreach (Ithem i in objekter)
                {
                    i.Draw(g, ScreenX, ScreenY, Grid, Grid);
                }
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
            selectore.Visible = true;
            return null;
        }
        internal override void Game()
        {
            bool LeftClik = false;
            while(true)
            {
                if (LeftClik && !mouseLeft)
                {
                    if (MouseX >= 0 && MouseX < 20 && MouseY >= 0 && MouseY < 20)
                    {
                        form.Game();
                    }else
                    {
                        lock (objektLock)
                        {
                            Console.WriteLine("TryToPlace");
                            object place = selectore.GetIthem((Grid == 0 ? 0 : MouseX / Grid), (Grid == 0 ? 0 : MouseY / Grid));
                            if(place != null)
                            {
                                objekter.Add((Ithem)place);
                            }
                            //Place(new House("House",(MouseX / Grid) + ScreenX, (MouseY / Grid) + ScreenY, 8, 5));
                        }
                    }
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
