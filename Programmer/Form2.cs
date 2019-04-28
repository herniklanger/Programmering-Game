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
        public delegate string selectedUpdate();
        public delegate int selectedSize();
        public selectedUpdate GetSelected;

        public selectedSize GetWidth;
        public selectedSize GetHeigth;

        public string selectedIthem;
        public Form2()
        {
            InitializeComponent();
            GetSelected = () => { return Ithems.SelectedItem.ToString(); };
            GetWidth = () =>
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
            };
            GetHeigth = () =>
            {
                string number = "0";
                foreach (char remuve in Height.Text)
                {
                    if("1234567890".Contains(remuve))
                    {
                        number += remuve;
                    }
                }
                return int.Parse(number);
            };
            Ithems.SelectedIndex = 0;
        }

        private void Ithems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Console.WriteLine(trackBar1.Value);
            g.FillRectangle(new SolidBrush(Color.White),0,0, pictureBox1.Size.Width, pictureBox1.Size.Height);
            switch(Ithems.Text)
            {
                case "Tree":
                    g.DrawRectangle(new Pen(new SolidBrush(Color.Red)),0,0,GetWidth()*trackBar1.Value, GetWidth() * trackBar1.Value);
                    break;
                case "Store":
                    g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), 0, 0, GetWidth() * trackBar1.Value, GetHeigth() * trackBar1.Value);
                    break;
            }
        }
    }
}
