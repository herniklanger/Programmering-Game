using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter
{
    class Tree : Ithem
    {
        public Tree(int IthemID, string Name, int X, int Y, int Width) : base(Name, IthemID, X, Y, Width, Width)
        {

        }
        public override Ithem Copy()
        {
            Ithem I = new Tree(IthemID, Name, X, Y, Width);
            return I;
        }

        public override object[] Save()
        {
            return new object[] { IthemID, Name, X, Y, Width };
        }
        public override string[] ValuseName()
        {
            return new string[] { "IthemID", "Name", "X", "Y", "Width" };
        }
    }
}
