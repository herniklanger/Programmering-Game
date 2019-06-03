using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmer.Game.Objekter;

namespace Programmer.Game_Engen.PlaceObjects
{
    class Place:SuberPlace
    {
        int GameX, GameY;
        Ithems ithem;
        
        Place(int GameX, int GameY) : base()
        {
            this.GameX = GameX;
            this.GameY = GameY;
            //switch(Form2)
        }

        protected override void RedoThem()
        {
            WorldCreader.Instans().objekter.Add(ithem);
        }

        protected override void UndoThem()
        {
            WorldCreader.Instans().objekter.Remove(ithem);
        }
    }
}
