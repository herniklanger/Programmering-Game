using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using Programmer.Game.Objekter;

namespace Programmer.Game_Engen
{
    abstract class Engen
    {
        public bool[] keyStrouck;
        public int Width { get; internal set; }
        public int Heith { get; internal set; }
        public int ScreenX { get; internal set; }
        public int ScreenY { get; internal set; }
        public int MouseX { get; set; }
        public int MouseY { get; set; }
        internal bool gameIsRinning = false;
        public object mouseLeftLock = new object();
        public bool mouseLeft { get; set; }
        public bool mouseRith = false;
        public int Grid { get; internal set; }
        internal List<Ithems> objekter = new List<Ithems>(); internal readonly object objektLock = new object();
        private Thread game;
        public Engen(int width, int heith)
        {
            mouseLeft = false;
            keyStrouck = new bool[256];
            Width = width;
            Heith = heith;
            game = new Thread(Game);
            game.IsBackground = true;
            game.Start();
        }
        internal static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
        public void upDateSize(int width, int heith)
        {
            Width = width;
            Heith = heith;
            Grid = Width / 50;
        }
        internal abstract void Game();
        public abstract void Garphish(Graphics g);
        public abstract Ithems IsThisfealtEmty(int x, int y);
    }
}