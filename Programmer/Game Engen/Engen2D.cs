using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using Programmer.Game.Objekter;

namespace Programmer.Game_Engen
{
    class Engen2D
    {
        private static Engen2D engen2D;
        private Thread game;
        private bool gameIsRinning = false;
        private int mouseX = 0, mouseY = 0;
        public readonly object objektLock = new object();
        private List<Ithem> objekter = new List<Ithem>();
        public bool[] keyStrouck;
        public bool mouseLeft = false;
        public bool mouseLeftPrivias = false;
        public bool mouseRith = false;
        public int ScreenX { get; private set; }
        public int ScreenY { get; private set; }
        public int Width { get; private set; }
        public int Heith { get; private set; }
        //public Hotbar hotbar;
        private Engen2D(int width, int heith)
        {
            keyStrouck = new bool[256];
            Width = width;
            Heith = heith;
            gameIsRinning = true;
            game = new Thread(Game);
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
        }
        public void Garphish(Graphics g)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), (Width / 2) - 50, (Heith / 2) - 50, 120, 120);
        }
        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
        public void Game()
        {
            int frames = 0;
            double unprocessedSeconds = 0;
            long previousTime = nanoTime();
            double secoundsPerTick = 1 / 60.0;
            int tickCount = 0;
            bool ticked = false;
            while (gameIsRinning)
            {
                long currentTime = nanoTime();
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
            }
        }
        public void render()
        {
            
        }
        public void Animation()
        {
            
        }
        public bool IthemInNextSpot(int x,int y)
        {
            return true;
        }

    }
}