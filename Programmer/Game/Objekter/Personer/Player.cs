using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmer.Game.Objekter.Personer
{
    class Player:Karektere
    {
        
        public Player(int IthemID, string name, int startPosisioX,int startPosisioY, int[] houses, int[] Workspace) :base(IthemID, name, startPosisioX,startPosisioY, 30,houses,Workspace)
        {
            
        }

        public override Ithem Copy()
        {
            return this;
        }
    }
}
