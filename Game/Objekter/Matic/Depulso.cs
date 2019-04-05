using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game.Objekter.Movements;
using Game.Game_Engen;

namespace Game.Game.Objekter.Matic
{
    class Depulso : Spells
    {
        public Depulso(Ithem carster, int MusX, int MusY) : base(carster, "Depulso", carster.X, carster.Y, 3, 3, MusX, MusY, 10, 60)
        {
        }
        public Depulso(Ithem carster, double startX, double startY, int MusX, int MusY) : base(carster, "Depulso", startX, startY, 3, 3, MusX, MusY, 10, 60)
        {
        }
        public override void Hit(Ithem heitet)
        {
            heitet.Flying.Add(new Exponent(MuvmentX,MuvmentY,20,0.01));
            Helf = 0;
        }
    }
}
