using Programmer.Game.Objekter;
using Programmer.Game.Objekter.Personer;
using System;
using System.Drawing;
using System.Threading;
using Programmer.Game.AppData;

namespace Programmer.Game_Engen
{
    class WorldCreader : Engen
    {
        private int MustStartX { get; set; }
        private int MustStartY { get; set; }
        private bool muving = false;
        public static Form1 form;
        private static Form2 selectore;
        private static WorldCreader instans;
        private WorldCreader(int width, int heith) : base(width, heith)
        {
            MustStartX = -1;
            gameIsRinning = true;
            selectore = new Form2();
            selectore.Show();
            objekter.AddRange(DataBaseHandling.Iniselise().Load());
            //objekter.Add(new Player(-1, "Henrik",0, 0, new int[0],new int[0]));
        }
        public static WorldCreader Instans(Form1 f, int width = 600, int heith = 800)
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
            g.DrawRectangle(new Pen(Color.Black), 0, 0, 20, 20);
            g.FillPolygon(new SolidBrush(Color.LightGreen), new Point[] { new Point(5, 5), new Point(5, 15), new Point(15, 10) });
            selectore.DrawSelected(g, (Grid == 0 ? 0 : MouseX / Grid) - 1, (Grid == 0 ? 0 : MouseY / Grid) - 1, Grid);
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
            double ofsetX = 0;
            double ofsetY = 0;
            while (gameIsRinning)
            {
                lock (mouseLeftLock)
                {
                    if (mouseLeft && !LeftClik)
                    {
                        MustStartX = MouseX;
                        MustStartY = MouseY;
                    }
                    if ((MustStartX != -1 && ((MouseX - MustStartX) * (MouseX - MustStartX) + (MouseY - MustStartY)*(MouseY - MustStartY))>4) || muving)
                    {
                        if (!muving)
                        {
                            muving = true;
                        }
                        ofsetX += (MouseX - MustStartX) / (Grid + 0.0);
                        ofsetY += (MouseY - MustStartY) / (Grid + 0.0);
                        ScreenX += (int)ofsetX;
                        ScreenY += (int)ofsetY;
                        ofsetX -= (int)ofsetX;
                        ofsetY -= (int)ofsetY;
                        MustStartX = MouseX;
                        MustStartY = MouseY;
                    }
                    if (LeftClik && !mouseLeft)
                    {

                        MustStartX = -1;
                        //knap
                        if (MouseX >= 0 && MouseX < 20 && MouseY >= 0 && MouseY < 20)
                        {
                            DataBaseHandling.Iniselise().Save(objekter.ToArray());
                            selectore.Invoke(selectore.Clos);
                            form.Game();
                            instans = null;
                            gameIsRinning = false;
                        }
                        else if (!muving)
                        {
                            lock (objektLock)
                            {
                                Console.WriteLine("TryToPlace");
                                object place = selectore.GetIthem((Grid == 0 ? 0 - ScreenX : MouseX / Grid - ScreenX), (Grid == 0 ? 0 - ScreenY : MouseY / Grid - ScreenY));
                                if (place != null)
                                {
                                    objekter.Add((Ithem)place);
                                }
                                //Place(new House("House",(MouseX / Grid) + ScreenX, (MouseY / Grid) + ScreenY, 8, 5));
                            }
                        }
                        muving = false;
                    }
                    LeftClik = mouseLeft;
                }
                Thread.Sleep(1);
            }
        }
        public void Place(Ithem ithem)
        {
            for (int x = 0; x > ithem.Width; x++)
            {
                for (int y = 0; y > ithem.Heith; y++)
                {
                    if (null == IsThisfealtEmty(x + ithem.X, y + ithem.Y))
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
