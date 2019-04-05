using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            switch (e.KeyValue)
            {
                case 37: //left
                    game.hotbar.MuveLeft();
                    break;
                case 38: //Up
                    game.hotbar.MuveLeft(10);
                    break;
                case 39: //Rith
                    game.hotbar.MuveRith();
                    break;
                case 40: //Down
                    game.hotbar.MuveRith(10);
                    break;
                case 48:
                    game.hotbar.Selcet(9);
                    break;
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                    game.hotbar.Selcet(e.KeyValue - 49);
                    break;
            }
            game.keyStrouck[e.KeyValue] = true;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            game.keyStrouck[e.KeyValue] = false;


        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                game.mouseLeft = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                game.mouseRith = true;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                game.mouseLeft = false;
                game.CreadSpel(game.player, e.X + game.ScreenX, e.Y + game.ScreenY);
                museX = e.X;
                museY = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                game.mouseRith = false;
            }
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
