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
        
        public Player(String name,int startPosisioX,int startPosisioY, int[] houses, int[] Workspace) :base(name,startPosisioX,startPosisioY, 30,houses,Workspace)
        {
            
        }

        public override Ithem Copy()
        {
            return null;
        }
    }
}
