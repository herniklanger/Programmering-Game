using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using Programmer.Game.Objekter;
using Programmer.Game.Objekter.Personer;

namespace Programmer.Game_Engen
{
    class Engen2D
    {
        private Thread game;
        private static Engen2D engen2D;

        private Player player;
        public readonly object objektLock = new object();
        private List<Ithem> objekter = new List<Ithem>();

        public bool[] keyStrouck;
        private bool gameIsRinning = false;
        public bool mouseLeft = false;
        public bool mouseLeftPrivias = false;
        public bool mouseRith = false;

        public int ScreenX { get; private set; }
        public int ScreenY { get; private set; }
        public int Width { get; private set; }
        public int Heith { get; private set; }
        private int tickCount = 0;
        private int Grid;

        //public Hotbar hotbar;
        private Engen2D(int width, int heith)
        {
            keyStrouck = new bool[256];
            Width = width;
            Heith = heith;
            Grid= Width / 50;
            player = new Player("Henrik",0,0);
            objekter.Add(player);
            objekter.Add(new House("unknown",10,10,5,5));
            gameIsRinning = true;
            game = new Thread(Game);
            game.IsBackground = true;
            Random r = new Random();
            game.Start();
        }
        public static Engen2D Engenen2D(int width = 600, int heith = 800)
        {
            if (engen2D == null)
            {
                engen2D = new Engen2D(width, heith);
            }
            return engen2D;
        }
        public void upDateSize(int width, int heith)
        {
            Width = width;
            Heith = heith;
            Grid = Width / 50;
        }
        public void Garphish(Graphics g)
        {
            for(int i =0;i<objekter.Count;i++ )
            {
                objekter[i].Draw(g, ScreenX, ScreenY, Grid, Grid);
            }
        }
        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
        long currentTime = 0;
        public void Game()
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
        private long MumentBuffer =0;
        public void render()
        {
            ScreenX += player.X + ScreenX > 3+Width/(Grid * 2) ? -1 : 0;
            ScreenX += player.X + ScreenX < -3+Width / (Grid * 2) ? 1 : 0;
            ScreenY += player.Y + ScreenY > 3+Heith / (Grid * 2) ? -1 : 0;
            ScreenY += player.Y + ScreenY < -3+Heith / (Grid * 2)? 1 : 0;
            if(keyStrouck[65]^keyStrouck[87]^keyStrouck[68]^keyStrouck[83] && MumentBuffer+100000000 < currentTime)
            {
                player.Direction = (Int16)(keyStrouck[83] ? 2: player.Direction);
                player.Direction = (Int16)(keyStrouck[65] ? 4: player.Direction);
                player.Direction = (Int16)(keyStrouck[87] ? 3: player.Direction);
                player.Direction = (Int16)(keyStrouck[68] ? 1: player.Direction);
                MumentBuffer = currentTime;
            }
        }
        public void Animation()
        {
            //Console.WriteLine(ScreenX+", "+ScreenY);
            lock(objektLock)
            {
                for (int i = 0; i < objekter.Count;i++)
                {
                    if(objekter[i].GetKareakter() != null)
                    {
                        objekter[i].GetKareakter().Muve(ref tickCount);
                    }
                }
            }
        }
        public Ithem IsThisfealtEmty(int x,int y)
        {
            foreach(Ithem ithem in objekter)
            {
                if (ithem.X <= x && ithem.X + ithem.Width > x && ithem.Y <= y&& ithem.Y + ithem.Heith > y)
                {
                    return ithem;
                }
            }
            return null;
        }
        public bool IthemInNextSpot(int x,int y)
        {
            return true;
        }
    }
}