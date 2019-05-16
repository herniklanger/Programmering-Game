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
        public override string Save(string tab)
        {
            string Save = tab + $"{IthemID}, { X}, { Y}, { Width}, { Heith},{{";
            foreach(string stuck in stock)
            {
                Save += stuck +", ";
            }
            return Save.Remove(Save.Length-2)+"}";
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
