using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game_Engen.PlaceObjects
{
    abstract class SuberPlace
    {
        private static Stack<SuberPlace> History;
        private static Stack<SuberPlace> RedoHistory;
        public static Form2 info;
        public SuberPlace()
        {
            if (History == null)
            {
                History = new Stack<SuberPlace>();
            }
            RedoHistory = null;
            History.Push(this);
        }
        public static void Undo()
        {
            if(RedoHistory == null)
            {
                RedoHistory = new Stack<SuberPlace>();
            }
            History.Peek().UndoThem();
            RedoHistory.Push(History.Pop());
        }
        protected abstract void UndoThem();
        public static void Redo()
        {
            if (History == null)
            {
                History = new Stack<SuberPlace>();
            }
            RedoHistory.Peek().RedoThem();
            History.Push(RedoHistory.Pop());
        }
        protected abstract void RedoThem();
    }
}