using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game.Objekter;
using Game.Game_Engen;

namespace Game.Game.Objekter.Movements
{
    class Exponent : Movement
    {
        private double adder, realMumentX, realMumentY;

        public Exponent(double mumentX, double mumentY, int helfth, double exponent) : base(mumentX, mumentY, 1, helfth)
        {
            realMumentX = mumentX;
            realMumentY = mumentY;
            adder = exponent;
        }
        public Exponent(double mumentX1, double mumentY1, double mumentX2, double mumentY2, int helfth, double exponent) : base(mumentX1, mumentY1, mumentX2, mumentY2, 0, helfth)
        {
            this.adder = exponent;
        }
        public override void Muve(Ithem subjekt)
        {
            double speed = Math.Pow(helf, 2) * adder;
            mumentX = realMumentX / hyP * speed;
            mumentY = realMumentY / hyP * speed;
            Console.WriteLine("Mument X: " + mumentX);
            Console.WriteLine("Mument Y: " + mumentY);
            base.Muve(subjekt);
        }
    }
}