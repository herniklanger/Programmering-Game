using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programmer.Game_Engen;

namespace Programmer
{
    public partial class Form1 : Form
    {
        Engen game;
        public delegate void StartSpil();
        public StartSpil Game;
        //dette er en test

        public Form1()
        {
            InitializeComponent();
            #if DEBUG
            game = WorldCreader.Instans(this,Width, Height);
            Game = () =>
            {
                game = Engen2D.Restart(Width, Height);
            };
            #else
            game = Engen2D.Engenen2D(Width, Height);
            #endif
            GameTime.Interval = (1000 / 60);
            GameTime.Tick += Timer;
            GameTime.Start();
        }
        private void Timer(object sender, EventArgs e)
        {
            game.upDateSize(Width, Height);
            Refresh();
        }
        private void TheGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            game.Garphish(g);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        //    Console.WriteLine(e.KeyValue + ", " + e.KeyCode);
        //    Console.WriteLine("test");
            game.keyStrouck[e.KeyValue] = true;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            game.keyStrouck[e.KeyValue] = false;
            #if DEBUG
            if (e.KeyValue == 27)
            {
                game = WorldCreader.Instans(this, Width, Height);
            }
            #endif
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                game.mouseLeft = true;
                game.MouseX = e.X;
                game.MouseY = e.Y;
            }else if(e.Button == MouseButtons.Right)
            {
                Console.WriteLine("R");
                game.mouseRith = true;
                game.MouseX = e.X;
                game.MouseY = e.Y;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                game.mouseLeft = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                game.mouseRith = false;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            game.MouseX = e.X;
            game.MouseY = e.Y;
        }
    }
}
