using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programmer.Game.Objekter
{
    class House : Ithems
    {
        public House(int IthemID, string name, int LocationX, int LocationY, int width, int height) : base(name, IthemID, LocationX, LocationY, width, height)
        {

        }
        public virtual void Event(Ithems Kereatore)
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
        public override Ithems Copy(int id = -1)
        {
            return new House(id == -1 ? IthemID : id, Name, 0, 0, Width, Heith);
        }
    }
}
