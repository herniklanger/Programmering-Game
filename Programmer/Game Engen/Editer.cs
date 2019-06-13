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

namespace Programmer.Game_Engen
{
    public partial class Editer : Form
    {
        Ithems ithem;
        public Editer(object chance)
        {
            Console.WriteLine(chance.GetType().Name);
            ithem = (Ithems)chance;
            InitializeComponent();
            X.Value = ithem.X;
            Y.Value = ithem.Y;
            Width.Value = ithem.Width;
            Heith.Value = ithem.Heith;
            switch(ithem.GetType().Name)
            {
                case "Store":
                    Shop.Location = new Point(12, 94);
                    break;
                case "Tree":
                    Tree.Location = new Point(12, 94);
                    break;
            }
        }

        private void Editer_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (ithem.GetType().Name)
            {
                case "Store":
                    List<InventoryIthem> stock = new List<InventoryIthem>();
                    bool b;
                    for(int i = 0; i < Stock.RowCount;i++)
                    {
                        b = true;
                        foreach (InventoryIthem item in stock)
                        {
                            if(item == (string)Stock.Rows[i].Cells[0].Value)
                            {
                                b = false;
                                break;
                            }
                        }
                        if(b)
                        {
                            stock.Add(new InventoryIthem(ithem.IthemID, (string)Stock.Rows[i].Cells[0].Value, (int)Stock.Rows[i].Cells[1].Value));
                        }
                    }
                    ithem = new Store(ithem.IthemID, (int)X.Value, (int)Y.Value, (int)Width.Value, (int)Heith.Value, stock.ToArray());
                    break;
                case "Tree":
                    Tree.Location = new Point(12, 94);
                    break;
                }
        }
    }
}
