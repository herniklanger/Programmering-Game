using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game.Objekter;
using System.Drawing;
using System.Threading;
using System.Media;
using Game.Game_Engen;

namespace Game.Game.Objekter.Matic
{
    abstract class Spells:Ithem
    {
        public double MuvmentX { get; internal set; }
        public double MuvmentY { get; internal set; }
        public Ithem Caster { get; }
        
        public Spells(Ithem carster,String name,double x, double y,int width,int heith,int musX,int musY, int muvmentSpeed,int secoundAndLfve) :base(name,x,y,width, heith, secoundAndLfve,false)
        {
            Caster = carster;
            double hyP = Math.Sqrt(Math.Pow(x - musX,2) + Math.Pow(y - musY,2));
            MuvmentX = (musX - x) / hyP * muvmentSpeed;
            MuvmentY = (musY - y) / hyP * muvmentSpeed;
            Console.WriteLine(Math.Pow(MuvmentX* MuvmentX + MuvmentY*MuvmentY,0.5));
        }
        public override void Muve()
        {
            Ithem hit = Engen2D.Engenen2D().Hiditextion( X + MuvmentX, Y + MuvmentY, this);
            X += MuvmentX;
            Y += MuvmentY;
            if(hit != null)
            {
                Hit(hit);
            }
            Helf--;
        }
        public override void Draw(Graphics g, int screenX, int screenY)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), (int)X - screenX, (int)Y - screenY, Width, Height);
        }
        public override Spells GetSpell()
        {
            return this;
        }
        public abstract void Hit(Ithem heitet);
    }
}
