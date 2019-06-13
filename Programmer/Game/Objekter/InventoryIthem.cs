using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter
{
    class InventoryIthem : Ithems
    {
        int amount;
        public InventoryIthem(int IthemID, String name, int amount) : base(name, IthemID, 0, 0)
        {
            this.amount = amount;
        }
        public override Ithems Copy(int id = -1)
        {
            return new InventoryIthem(id == -1 ? IthemID : id, Name, amount);
        }
        public override object[] Save()
        {
            return new object[] { IthemID, Name, amount };
        }

        public override string[] ValuseName()
        {
            return new string[] { "IthemID", "Name", "amount" };
        }
        public static bool operator ==(InventoryIthem a, string b)
        {
            return a.Name.Equals(b);
        }
        public static bool operator !=(InventoryIthem a, string b)
        {
            return !a.Name.Equals(b);
        }
        public static bool operator ==( string b,InventoryIthem a)
        {
            return b.Equals(a.Name);
        }
        public static bool operator !=( string b,InventoryIthem a)
        {
            return !b.Equals(a.Name);
        }
    }
}
