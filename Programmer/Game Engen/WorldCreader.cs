using Programmer.Game.Objekter;
using Programmer.Game.Objekter.Personer;
using System;
using System.Drawing;
using System.Threading;
using Programmer.Game.AppData;
using Programmer.Game_Engen.PlaceObjects;

namespace Programmer.Game_Engen
{
    class WorldCreader : Engen
    {
        public long[] keyStrouckReleace;
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
        }
        /// <summary>
        /// Get the Instans of the WorldCreader so there only can be one
        /// </summary>
        /// <param name="f"></param>
        /// <param name="width"></param>
        /// <param name="heith"></param>
        /// <returns></returns>
        public static WorldCreader Instans(Form1 f, int width = 600, int heith = 800)
        {
            form = f;
            if (instans == null)
            {
                instans = new WorldCreader(width, heith);
            }
            return instans;
        }
        public static WorldCreader Instans()
        {
            return instans;
        }
        /// <summary>
        /// Wrtiting the game
        /// </summary>
        /// <param name="g"></param>
        public override void Garphish(Graphics g)
        {
            
            selectore.DrawSelected(g, (Grid == 0 ? 0 : MouseX / Grid)*Grid, (Grid == 0 ? 0 : MouseY / Grid) * Grid, Grid);
            lock (objektLock)
            {
                Console.WriteLine(objekter.Count);
                foreach (Ithems i in objekter)
                {
                    i.Draw(g, ScreenX, ScreenY, Grid, Grid);
                }
            }
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 20, 20);
            g.FillPolygon(new SolidBrush(Color.LightGreen), new Point[] { new Point(5, 5), new Point(5, 15), new Point(15, 10) });
            g.FillRectangle(new SolidBrush(Color.Black), 21, 0, 20, 20);
            g.FillPolygon(new SolidBrush(Color.Blue), new Point[] { new Point(26, 3), new Point(24, 12), new Point(32, 10) });
            g.DrawArc(new Pen(Color.Blue,2), 26, 5,10,10,60,-180);
            g.FillRectangle(new SolidBrush(Color.Black), 42, 0, 20, 20);
            g.FillPolygon(new SolidBrush(Color.Blue), new Point[] { new Point(52, 10), new Point(59, 11), new Point(55, 2) });
            g.DrawArc(new Pen(Color.Blue, 2), 47, 5, 10, 10, 110, 210);
        }
        /// <summary>
        /// tjeking the fealt emtines and remember that the input value is the the gridt 
        /// </summary>
        /// <param GridtX="x"></param>
        /// <param GridtY="y"></param>
        /// <returns></returns>
        public override Ithems IsThisfealtEmty(int x, int y)
        {
            foreach (Ithems ithem in objekter)
            {
                if (ithem.X <= x && ithem.X + ithem.Width > x && ithem.Y <= y && ithem.Y + ithem.Heith > y)
                {
                    return ithem;
                }
            }
            return null;
        }
        /// <summary>
        /// Updating the game
        /// </summary>
        internal override void Game()
        {
            keyStrouckReleace = new long[keyStrouck.Length];
            bool LeftClik = false;
            bool RithClik = false;
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

                    if ((MustStartX != -1 && ((MouseX - MustStartX) * (MouseX - MustStartX) + (MouseY - MustStartY) * (MouseY - MustStartY)) > 4) || muving)
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
                        if (!muving)
                        {
                            //knapper
                            if (MouseX >= 0 && MouseX < 60 && MouseY >= 0 && MouseY < 20)
                            {
                                if (0 == MouseX / 20)
                                {
                                    selectore.Invoke(selectore.Clos);
                                    DataBaseHandling.Iniselise().Save(objekter.ToArray());
                                    form.Game();
                                    instans = null;
                                    gameIsRinning = false;
                                } else if (1 == MouseX / 20)
                                {
                                    SuberPlace.Undo();
                                } else
                                {
                                    SuberPlace.Redo();
                                }
                            } else
                            {
                                new Place(MouseX / Grid - ScreenX, MouseY / Grid - ScreenY, selectore);
                            }
                        }
                        muving = false;
                    }
                    LeftClik = mouseLeft;
                    
                }
                lock(mouseRithLock)
                {
                    if (RithClik && !mouseRith)
                    {
                        Ithems ithem = IsThisfealtEmty(MouseX/Grid,MouseY/Grid);
                        if(ithem != null)
                        {
                            new Edit(ithem);
                        }
                    }
                    RithClik = mouseRith;
                }
                //Keyboard buttons
                lock(keyStrouckLock)
                {
                    if (!keyStrouck[90] && keyStrouckReleace[90] != 0)
                    {
                        if (keyStrouck[17])
                        {
                            SuberPlace.Undo();
                        }
                    }
                    if (!keyStrouck[89] && keyStrouckReleace[89] != 0)
                    {
                        if (keyStrouck[17])
                        {
                            SuberPlace.Redo();
                        }
                    }
                    for (int i = 0; i < keyStrouck.Length;i++)
                    {
                        if(keyStrouck[i])
                        {
                            if(keyStrouckReleace[i] == 0)
                            {
                                keyStrouckReleace[i] = DateTime.Now.Ticks;
                            }
                        }else
                        {
                            keyStrouckReleace[i] = 0;
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
        /// <summary>
        /// Try to plac 
        /// </summary>
        /// <param name="ithem"></param>
        public void Place(Ithems ithem)
        {
            for (int x = 0; x < ithem.Width; x++)
            {
                for (int y = 0; y < ithem.Heith; y++)
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
