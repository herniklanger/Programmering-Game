using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter
{
    class InventoryIthem : Ithems
    {
        public InventoryIthem(int IthemID,String name, int LocationX, int LocationY) : base(name, IthemID, LocationX, LocationY)
        {

        }
        public override Ithems Copy(int id = -1)
        {
            throw new NotImplementedException();
        }

        public override object[] Save()
        {
            throw new NotImplementedException();
        }

        public override string[] ValuseName()
        {
            throw new NotImplementedException();
        }
    }
}
