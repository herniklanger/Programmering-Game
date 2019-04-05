using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game.Objekter.Movements;

namespace Game.Game.Objekter.Matic
{
    class Lammer : Spells
    {
        public Lammer(Ithem carster, int musX, int musY) : base(carster, "Bumbada", carster.X, carster.Y, 3, 3, musX, musY, 10, 60)
        {
        }
        public Lammer(Ithem carster, double startX, double startY, int musX, int musY) : base(carster, "Bumbada", startX, startY, 3, 3, musX, musY, 10, 60)
        {
        }

        public override void Hit(Ithem heitet)
        {
            if(heitet.GetKareakter() != null)
            {
                heitet.Flying.Add(new FreesForEver());
            }else
            {
                heitet.Flying.Add(new Exponent(MuvmentX, MuvmentY, 20, 0.01));
            }
            Helf = 0;
        }
    }
}
