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
        public Karektere(String name, int x, int y, int speed, int width = 1, int height = 1) : base(name, x, y, width, height)
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
                Ithem head =null;
                switch(Direction)
                {
                    case 1:
                        
                        if ((head=Game_Engen.Engen2D.Engenen2D().IsThisfealtEmty(X + 1,Y))==null)
                        {
                            X++;
                        }
                        break;
                    case 2:
                        if ((head = Game_Engen.Engen2D.Engenen2D().IsThisfealtEmty(X, Y+1)) == null)
                        {
                            Y++;
                        }
                        break;
                    case 3:
                        if ((head = Game_Engen.Engen2D.Engenen2D().IsThisfealtEmty(X , Y- 1)) == null)
                        {
                            Y--;
                        }
                        break;
                    case 4:
                        if ((head = Game_Engen.Engen2D.Engenen2D().IsThisfealtEmty(X - 1, Y)) == null)
                        {
                            X--;
                        }
                        break;
                }
                if (head != null)
                {
                    head.Event(this);
                }
                Direction = 0;
            }
        }
    }
}
