using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter
{
    class Store : Ithems
    {
        InventoryIthem[] stock;

        public Store(int IthemID, int LocationX, int LocationY, int width, int heigth, InventoryIthem[] stock) : base("Shop", IthemID, LocationX, LocationY, width, heigth)
        {
            this.stock = stock;
        }
        public override object[] Save()
        {
            return new object[] { IthemID, X, Y, Width, Heith, stock };
        }
        public override string[] ValuseName()
        {
            return new string[] { "IthemID", "X", "Y", "Width", "Heith", "stock" };
        }
        public override Ithems Copy(int id )
        {
            return new Store(id == -1 ? IthemID : id, X, Y,Width,Heith, new InventoryIthem[0]);
        }
    }
}
