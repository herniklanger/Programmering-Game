using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmer.Game.Objekter;

namespace Programmer.Game_Engen.PlaceObjects
{
    class Edit : SuberPlace
    {
        Ithems preEdit;
        Ithems afterEdit;
        Ithems ithem;
        public Edit(Ithems eddiet)
        {
            preEdit = eddiet.Copy();
            ithem = eddiet;
            new Editer(eddiet).ShowDialog();
            afterEdit = eddiet.Copy();
            DoIt();
        }
        protected override void DoIt()
        {
            ithem = afterEdit;
        }

        protected override void UndoThem()
        {
            ithem = preEdit;
        }
    }
}
