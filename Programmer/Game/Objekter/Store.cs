using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter
{
    class Store : Ithem
    {
        string[] stock;

        public Store(int IthemID, int LocationX, int LocationY, int width, int heigth, string[] stock) : base("Shop", IthemID, LocationX, LocationY, width, heigth)
        {
            this.stock = stock;
        }
        public override object[] Save()
        {
            return new object[] { IthemID, X, Y, Width, Heith, stock };
        }
        public override Ithem Copy()
        {
            string[] stock = null;
            if(this.stock != null)
            {
                stock = new string[this.stock.Length-1];
                for (int i = 0; i < this.stock.Length; i++)
                {
                    stock[i] = this.stock[i];
                }
            }
            return new Store(IthemID, X, Y,Width,Heith,stock);
        }
    }
}
