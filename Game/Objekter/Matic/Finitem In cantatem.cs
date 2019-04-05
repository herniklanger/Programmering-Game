using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Game.Objekter.Matic
{
    class Finitem_In_cantatem : Spells
    {
        public Finitem_In_cantatem(Ithem carster, int musX, int musY) : base(carster, "Bumbada", carster.X, carster.Y, 3, 3, musX, musY, 0, 60)
        {
        }public Finitem_In_cantatem(Ithem carster, double startX, double startY, int musX, int musY) : base(carster, "Bumbada", startX, startY, 3, 3, musX, musY, 0, 60)
        {
        }

        public override void Hit(Ithem heitet)
        {
            throw new NotImplementedException();
        }
    }
}
