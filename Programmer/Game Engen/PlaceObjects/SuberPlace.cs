using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game_Engen.PlaceObjects
{
    abstract class SuberPlace
    {
        protected static Stack<SuberPlace> History;
        protected static Stack<SuberPlace> RedoHistory;
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
            if(History != null)
            {
                if(RedoHistory == null)
                {
                    RedoHistory = new Stack<SuberPlace>();
                }
                History.Peek().UndoThem();
                RedoHistory.Push(History.Pop());
            }
        }
        protected abstract void UndoThem();
        public static void Redo()
        {
            if(RedoHistory != null && RedoHistory.Count > 0)
            {
                RedoHistory.Peek().DoIt();
                History.Push(RedoHistory.Pop());
            }
        }
        protected abstract void DoIt();
    }
}