using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Game.Objekter.Matic
{
    class Difindo : Spells
    {
        public Difindo(Ithem carster, int musX, int musY) : base(carster, "Difndo", carster.X, carster.Y, 3, 3, musX, musY, 10, 60)
        {
        }
        public Difindo(Ithem carster, double startX, double startY, int musX, int musY) : base(carster, "Difndo", startX, startY, 3, 3, musX, musY, 10, 60)
        {
        }

        public override void Hit(Ithem heitet)
        {

        }
    }
}
