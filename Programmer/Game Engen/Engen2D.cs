using Programmer.Game.Objekter;
using Programmer.Game.Objekter.Personer;
using System;
using System.Drawing;
using System.Threading;
using Programmer.Game.AppData;

namespace Programmer.Game_Engen
{
    class Engen2D : Engen
    {
        private static Engen2D engen2D;
        private Player player;
        public bool mouseLeftPrivias = false;
        private int tickCount = 0;
        long currentTime = 0;
        //public Hotbar hotbar;
        private Engen2D(int width, int heith) : base(width, heith)
        {
            Grid = Width / 50;
            player = new Player(-1, "Henrik",0, 0, null, null);
            objekter.Add(player);
            objekter.AddRange(DataBaseHandling.Iniselise().Load());
            gameIsRinning = true;
            Random r = new Random();
        }
        public static Engen2D Engenen2D(int width = 600, int heith = 800)
        {
            if (engen2D == null)
            {
                engen2D = new Engen2D(width, heith);
            }
            return engen2D;
        }
        public static Engen2D Restart(int width = 600, int heith = 800)
        {
            engen2D = new Engen2D(width, heith);
            return engen2D;
        }
        public override void Garphish(Graphics g)
        {
            for (int i = 0; i < objekter.Count; i++)
            {
                objekter[i].Draw(g, ScreenX, ScreenY, Grid, Grid);
            }
        }
        internal override void Game()
        {
            int frames = 0;
            double unprocessedSeconds = 0;
            long previousTime = nanoTime();
            double secoundsPerTick = 1 / 60.0;
            bool ticked = false;
            while (gameIsRinning)
            {
                currentTime = nanoTime();
                long passedTime = currentTime - previousTime;
                previousTime = currentTime;
                unprocessedSeconds += passedTime / 1000000000.0;
                while (unprocessedSeconds > secoundsPerTick)
                {
                    Animation();
                    unprocessedSeconds -= secoundsPerTick;
                    ticked = true;
                    tickCount++;
                    if (tickCount % 60 == 0)
                    {
                        Console.WriteLine(frames + "FPS ");
                        previousTime += 1000;
                        frames = 0;
                    }
                }
                if (ticked)
                {
                    render();
                    frames++;
                }
                render();
                frames++;
                Thread.Sleep(1);
            }
        }
        private long MumentBuffer = 0;
        public void render()
        {
            ScreenX += player.X + ScreenX > 3 + Width / (Grid * 2) ? -1 : 0;
            ScreenX += player.X + ScreenX < -3 + Width / (Grid * 2) ? 1 : 0;
            ScreenY += player.Y + ScreenY > 3 + Heith / (Grid * 2) ? -1 : 0;
            ScreenY += player.Y + ScreenY < -3 + Heith / (Grid * 2) ? 1 : 0;
            if (keyStrouck[65] ^ keyStrouck[87] ^ keyStrouck[68] ^ keyStrouck[83] && MumentBuffer + 100000000 < currentTime)
            {
                player.Direction = (Int16)(keyStrouck[83] ? 2 : player.Direction);
                player.Direction = (Int16)(keyStrouck[65] ? 4 : player.Direction);
                player.Direction = (Int16)(keyStrouck[87] ? 3 : player.Direction);
                player.Direction = (Int16)(keyStrouck[68] ? 1 : player.Direction);
                MumentBuffer = currentTime;
            }
        }
        private void Animation()
        {
            //Console.WriteLine(ScreenX+", "+ScreenY);
            lock (objektLock)
            {
                for (int i = 0; i < objekter.Count; i++)
                {
                    if (objekter[i].GetKareakter() != null)
                    {
                        objekter[i].GetKareakter().Muve(ref tickCount);
                    }
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
            return null;
        }
        public bool IthemInNextSpot(int x, int y)
        {
            foreach (Ithem ithem in objekter)
            {
                if (ithem.X <= x && ithem.X + ithem.Width > x && ithem.Y <= y && ithem.Y + ithem.Heith > y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}