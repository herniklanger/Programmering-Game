using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter
{
    class Tree : Ithem
    {
        public Tree(string Name,int X,int Y, int Width):base(Name, X,Y,Width,Width)
        {

        }
        public override Ithem Copy()
        {
            Ithem I = new Tree(Name, X, Y, Width);
            return I;
        }

        public override string Save()
        {
            string s = $"{Name}, {X}, {Y}, {Width}";
            return s;
        }
    }
}
