﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Game.Objekter.Matic
{
    class Nox : Spells
    {
        public Nox(Ithem carster, int musX, int musY) : base(carster, "Bumbada", carster.X, carster.Y, 3, 3, musX, musY, 10, 60)
        {
        }
        public Nox(Ithem carster, double startX, double startY, int musX, int musY) : base(carster, "Bumbada", startX, startY, 3, 3, musX, musY, 10, 60)
        {
        }

        public override void Hit(Ithem heitet)
        {
            throw new NotImplementedException();
        }
    }
}