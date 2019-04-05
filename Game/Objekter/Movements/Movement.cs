using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game_Engen;

namespace Game.Game.Objekter.Movements
{
    class Movement
    {
        internal double mumentX, mumentY, hyP;
        public int helf;
        public Movement(double mumentX, double mumentY, double mumentSpeed, int helfth = 1)
        {
            hyP = Math.Sqrt(Math.Pow(mumentX, 2) + Math.Pow(mumentY, 2));
            this.mumentX = (mumentX) / hyP * (mumentSpeed / 60.0);
            this.mumentY = (mumentY) / hyP *(mumentSpeed / 60.0);
            helf = helfth;
        }
        public Movement(double mumentX1, double mumentY1, double mumentX2, double mumentY2, double mumentSpeed, int helfth = 1)
        {
            hyP = Math.Sqrt(Math.Pow(mumentX2 - mumentX1, 2) + Math.Pow(mumentY2-mumentY1, 2));
            mumentX = (mumentX2) / hyP * (mumentSpeed /60);
            mumentY = (mumentY2) / hyP * (mumentSpeed /60);
            helf = helfth;
        }

        public virtual void Muve(Ithem subjekt)
        {
            if (mumentX != 0)
            {
                int x = mumentX > 0 ? 1 : -1;
                for (int i = (int)(mumentX); i != 0; i-=x)
                {
                    subjekt.X += x;
                    if (!Engen2D.Engenen2D().HidetObject(subjekt.X, subjekt.X + subjekt.Width, subjekt.Y, subjekt.Y + subjekt.Height, subjekt))
                    {
                        subjekt.X -= x;
                    }
                }
                subjekt.X += mumentX % 1;
                if (!Engen2D.Engenen2D().HidetObject(subjekt.X, subjekt.X + subjekt.Width, subjekt.Y, subjekt.Y + subjekt.Height, subjekt))
                {
                    subjekt.X -= mumentX % 1;
                }
            }
            if (mumentY != 0)
            {
                int y = mumentY > 0 ? 1 : -1;
                for (int i = (int)(mumentY); i != 0; i-=y)
                {
                    subjekt.Y += y;
                    if (!Engen2D.Engenen2D().HidetObject(subjekt.X, subjekt.X + subjekt.Width, subjekt.Y, subjekt.Y + subjekt.Height, subjekt))
                    {
                        subjekt.Y -= y;
                    }
                }
                subjekt.Y += (mumentY) % 1;
                if (!Engen2D.Engenen2D().HidetObject(subjekt.X, subjekt.X + subjekt.Width, subjekt.Y, subjekt.Y + subjekt.Height, subjekt))
                {
                    subjekt.Y -= mumentY%1;
                }
            }
            helf--;
        }
    }
}