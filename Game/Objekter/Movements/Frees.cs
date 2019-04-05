using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Game.Objekter.Movements
{
    class Frees : Movement
    {
        public Frees(int helf) : base(0, 0, 0, helf)
        {
            
        }
        public override void Muve(Ithem subjekt)
        {
            helf--;
        }
    }
}
