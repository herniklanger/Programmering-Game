using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game.Objekter.Movements;

namespace Game.Game.Objekter.Matic
{
    class Flipendo : Spells
    {
        public Flipendo(Ithem carster, int musX, int musY) : base(carster, "Bumbada", carster.X, carster.Y, 3, 3, musX, musY, 10, 60)
        {
        }
        public Flipendo(Ithem carster, double startX, double startY, int musX, int musY) : base(carster, "Bumbada", startX, startY, 3, 3, musX, musY, 10, 60)
        {
        }
        public override void Hit(Ithem heitet)
        {
            double Mument = 0;
            if(heitet.GetKareakter() != null)
            {
                Mument = heitet.GetKareakter().MuvmentSpeed;
            }
            heitet.Pussing.Add(new Movement(MuvmentX, MuvmentY, Mument, 10));
            Helf = 0;
        }
    }
}