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

        public delegate object GetValue();
        public GetValue GetComboBoxText;
        public GetValue GetWidth;
        public GetValue GetHeight;
        public Form2()
        {

            DrawSelected = (Graphics g, int X, int Y, int Gridt) =>
            {
                switch (Ithems.SelectedItem)
                {
                    case "Tree":
                        g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), X, Y, (int)Width.Value*Gridt, (int)Width.Value * Gridt);
                        break;
                    case "Store":
                        g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), X, Y, (int)Width.Value * Gridt, (int)Height.Value * Gridt);
                        break;
                }
            };
            Clos = () =>
            {
                Close();
            };

            GetComboBoxText = () => { return Ithems.SelectedItem.ToString(); };
            GetWidth = () => { return Width.Value; };
            GetHeight = () => { return Height.Value; };

            InitializeComponent();
            Ithems.SelectedIndex = 0;
            Height.Value = 1;
            Width.Value = 1;
        }
        /// <summary>
        /// uodater the selected ithe samt the pree wiew
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ithems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            DrawSelected(g, 1, 1, trackBar1.Value);
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
