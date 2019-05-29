using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programmer.Game.Objekter
{
    class House : Ithem
    {
        public House(int IthemID, string name, int LocationX, int LocationY, int width, int height) : base(name, IthemID, LocationX, LocationY, width, height)
        {

        }
        public virtual void Event(Ithem Kereatore)
        {

        }
        public override object[] Save()
        {
            return new object[] { IthemID, Name, X, Y, Width, Heith };
        }
        public override string[] ValuseName()
        {
            return new string[] { "IthemID", "Name", "X", "Y", "Width", "Heith" };
        }
        public override Ithem Copy()
        {
            return new House(IthemID, Name, 0, 0, Width, Heith);
        }
    }
}
