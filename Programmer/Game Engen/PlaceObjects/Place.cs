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
        
        public Place(int GameX, int GameY,Form2 f) : base()
        {
            this.GameX = GameX;
            this.GameY = GameY;
            //string SelctedText = f.
            Console.WriteLine(f.Invoke(f.GetWidth).GetType());
            switch((string)f.Invoke(f.GetComboBoxText))
            {
                case "Tree":
                    ithem = new Tree(-1, "Tree", GameX, GameY, (int)(decimal)f.Invoke(f.GetWidth));
                    break;
                case "Store":
                    ithem = new Store(-1, GameX, GameY, (int)(decimal)f.Invoke(f.GetWidth), (int)(decimal)f.Invoke(f.GetHeight),new InventoryIthem[0]);
                    break;
                default:
                    Console.WriteLine("Dette objekt er eksistere ikke i nu");
                    History.Pop();
                    return;
            }
            DoIt();
        }

        protected override void DoIt()
        {
            lock(WorldCreader.Instans().objektLock)
            {
                WorldCreader.Instans().objekter.Add(ithem);
            }
        }

        protected override void UndoThem()
        {
            Console.WriteLine(WorldCreader.Instans().objekter.Count);
            WorldCreader.Instans().objekter.Remove(ithem);
            Console.WriteLine(WorldCreader.Instans().objekter.Count);
        }
    }
}
