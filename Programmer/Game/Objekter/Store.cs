using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter
{
    class Store : Ithem
    {
        Ithem[] Stock;

        public Store(int LocationX, int LocationY, int width, int heigth, Ithem[] stock) : base("Shop", LocationX, LocationY, width, heigth)
        {
            Stock = stock;
        }

        public override string Save()
        {
            string Save="";
            return Save;
        }
    }
}
