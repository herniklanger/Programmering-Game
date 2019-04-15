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
        Engen2D game;
        public int museX = 0, museY = 0;

        public Form1()
        {
            InitializeComponent();
            GameTime.Interval = (1000 / 60);
            GameTime.Tick += Timer;
            GameTime.Start();
            game = Engen2D.Engenen2D(Width, Height);
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
            Console.WriteLine(e.KeyValue + ", " + e.KeyCode);
            
            game.keyStrouck[e.KeyValue] = true;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            game.keyStrouck[e.KeyValue] = false;


        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void GameTime_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.mouseRith)
            {
                museX = e.X;
                museY = e.Y;
            }
        }
    }
}
