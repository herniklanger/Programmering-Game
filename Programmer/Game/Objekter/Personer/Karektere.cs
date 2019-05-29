using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Programmer.Game.Tasks;

namespace Programmer.Game.Objekter.Personer
{
    abstract class Karektere : Ithem
    {
        private Image[] Person= new Image[1];
        public int notAbleToMuve = 0;
        int[] Houses;
        int[] Worck;
        List<Task> task = new List<Task>();
        public int Muvment { get; private set; }
        private int speed; 
        public Int16 Direction { get; set; }
        public Karektere(int IthemID, string name, int x, int y, int speed,int[] Houses,int[] WorkPlace) : base(name, IthemID, x, y)
        {
            this.speed = speed;
            this.Houses = Houses;
            Worck = WorkPlace;
        }
        public Karektere(object[] load) : base((string)load[0], (int)load[1], (int)load[2], (int)load[3])
        {
            speed = (int)load[5];
            Houses = (int[])load[6];
            Worck = (int[])load[7];
        }
        public override Karektere GetKareakter()
        {
            return this;
        }
        public override object[] Save()
        {
            return new object[] {IthemID, Name, X, Y, speed, speed, Houses, task};
        }
        public override string[] ValuseName()
        {
            return new string[] { "IthemID", "Name", "X", "Y", "speed", "speed", "Houses", "task" };
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
                    head.Event(this, 0);
                }
                Direction = 0;
            }
        }
    }
}
