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
        public Karektere(String name, int IthemID, int x, int y, int speed,int[] Houses,int[] WorkPlace) : base(name, IthemID, x, y)
        {
            this.speed = speed;
            this.Houses = Houses;
            Worck = WorkPlace;
        }
        public override Karektere GetKareakter()
        {
            return this;
        }
        public override string Save(string tab)
        {
            string save = tab + $"{Name}, {IthemID}, {X},{Y},{speed}\n";
            save += "<hus>\n";
            tab += "\t";
            foreach(int hus in Houses)
            {
                save += tab + hus+"\n";
            }
            tab = tab.Remove(tab.Length-1);
            save += tab+"<\\hus>\n";
            save += tab+"<Work>\n";
            tab += "\t";
            foreach(int work in Worck)
            {
                save += tab + work + "\n";
            }
            tab = tab.Remove(tab.Length - 1);
            save += tab + "<\\Work>\n";
            return save;

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
