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
using Programmer.Game.AppData;

namespace Programmer
{
    public partial class Form2 : Form
    {
        public delegate object Place(int X, int Y);
        public Place GetIthem;
        public Place SelectedIthem;
        /// <summary>
        /// Draw the selected Ithem
        /// </summary>
        /// <param name="g"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Gridt"></param>
        public delegate void drawSelected(Graphics g, int X, int Y, int Gridt);
        public drawSelected DrawSelected;
        /// <summary>
        /// close the window
        /// </summary>
        public delegate void Despose();
        public Despose Clos;

        private Ithems selected;
        public Form2()
        {
            DrawSelected = (Graphics g, int X, int Y, int Gridt) =>
            {
                if (null != selected)
                {
                    Console.WriteLine(selected.IthemID);
                    selected.Draw(g, (-selected.X) + X + 1, (-selected.Y) + Y + 1, Gridt, Gridt);
                }
            };
            Clos = () =>
            {
                Close();
            };
            InitializeComponent();
            Ithems.SelectedIndex = 0;
            Height.Value = 1;
            Width.Value = 1;
        }
        /// <summary>
        /// return the walue if the heith walue
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// return the withe walue
        /// </summary>
        /// <returns></returns>
        private int GetWidth()
        {
            string number = "";
            foreach (char remuve in Width.Text)
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
        /// <summary>
        /// uodater the selected ithe samt the pree wiew
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ithems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (selected == null || selected.IthemID == -1)
            {
                Console.WriteLine(Ithems.SelectedValue);
                switch(Ithems.SelectedItem)
                {
                    case "Tree":
                        selected = new Tree(-1,"Tree",1,1,GetWidth());
                        break;
                    case "Store":
                        selected = new Store(-1, 1, 1, GetWidth(), GetHeigth(),new string[0]);
                        break;
                    default:
                        Ithems.SelectedIndex = 0;
                        Ithems_SelectedIndexChanged(sender, e);
                        break;
                }
            }
            if(selected != null)
            {
                selected.Draw(g, -selected.X+1, -selected.Y+1, trackBar1.Value, trackBar1.Value);
            }
        }
        /// <summary>
        /// when loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            Ithems_SelectedIndexChanged(sender, e);
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
