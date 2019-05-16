using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter
{
    class Tree : Ithem
    {
        public Tree(string Name, int IthemID, int X,int Y, int Width):base(Name, IthemID, X, Y,Width,Width)
        {

        }
        public override Ithem Copy()
        {
            Ithem I = new Tree(Name, IthemID, X, Y, Width);
            return I;
        }

        public override string Save(string tab)
        {
            string s = tab + $"{Name}, {IthemID}, {X}, {Y}, {Width}";
            return s;
        }
    }
}
