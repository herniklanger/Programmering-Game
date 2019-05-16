using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programmer.Game.Objekter;

namespace Programmer
{
    public partial class Form2 : Form
    {
        public delegate object Place(int X, int Y);
        public Place GetIthem;
        public delegate void drawSelected(Graphics g, int X, int Y,int Gridt);
        public drawSelected DrawSelected;
        public delegate void Despose();
        public Despose Clos;
        private Ithem selected;
        public string selectedIthem;
        public Form2()
        {
            DrawSelected = (Graphics g, int X, int Y, int Gridt) =>
            {
                selected.Draw(g, X, Y, Gridt, Gridt);
            };
            GetIthem = (int X, int Y) =>
            {
                Ithem i = selected.Copy();
                i.SetLocation(X, Y);
                return i;
            };
            Clos = () =>
            {
                Close();
            };
            InitializeComponent();
            Ithems.SelectedIndex = 0;
            Height.Text = "1";
            Width.Text = "1";
        }
        private int GetHeigth()
        {
            string number = "";
            foreach (char remuve in Height.Text)
            {
                if ("1234567890".Contains(remuve))
                {
                    number += remuve;
                }
            }
            if (number.Length == 0)
            {
                number = "0";
            }
            return int.Parse(number);
        }
        private int GetWidth()
        {
            string number = "";
            foreach (char remuve in Width.Text)
            {
                if("1234567890".Contains(remuve))
                {
                    number += remuve;
                }
            }
            if(number.Length ==0)
            {
                number = "0";
            }
            return int.Parse(number);
        }

        private void Ithems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.White),0,0, pictureBox1.Size.Width, pictureBox1.Size.Height);
            Console.WriteLine(GetHeigth());
            switch(Ithems.Text)
            {
                case "Tree":
                    selected = new Tree("Tree",2,1,1,GetWidth());
                    break;
                case "Store":
                    selected = new Store(0,1, 1, GetWidth(), GetHeigth(),null);
                    break;
            }
            selected.Draw(g, 0, 0, trackBar1.Value, trackBar1.Value);
        }
    }
}
