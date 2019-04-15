using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Programmer.Game.Objekter.Personer
{
    abstract class Karektere : Ithem
    {
        private Image[] Person= new Image[1];
        public int notAbleToMuve = 0;
        public int Muvment { get; private set; }
        private int speed; 
        public Int16 Direction { get; set; }
        public Karektere(String name, int x, int y, int speed) : base(name, x, y, 100,true)
        {
            this.speed = speed;
        }
        public override Karektere GetKareakter()
        {
            return this;
        }
        public virtual Player GetPlayer()
        {
            return null;
        }
        public virtual void Muve(ref int muve)
        {
            if(muve%speed ==0)
            {
                Console.WriteLine("Direction is " + Direction);
                switch(Direction)
                {
                    case 1:
                        if (!Game_Engen.Engen2D.Engenen2D().IsThisfealtEmty(X + 1,Y,this))
                        {
                            X++;
                        }
                        break;
                    case 2:
                        if (!Game_Engen.Engen2D.Engenen2D().IsThisfealtEmty(X, Y+1, this))
                        {
                            Y++;
                        }
                        break;
                    case 3:
                        if (!Game_Engen.Engen2D.Engenen2D().IsThisfealtEmty(X , Y- 1, this))
                        {
                            Y--;
                        }
                        break;
                    case 4:
                        if (!Game_Engen.Engen2D.Engenen2D().IsThisfealtEmty(X - 1, Y, this))
                        {
                            X--;
                        }
                        break;
                }
                Direction = 0;
            }
        }
    }
}
