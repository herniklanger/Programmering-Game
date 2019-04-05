using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Programmer.Game.Objekter;
using Programmer.Game_Engen;
using Programmer.Game.Objekter.Movements;
namespace Programmer.Game.Personer
{
    abstract class Karektere : Ithem
    {
        private Image[] Person;
        public Stack<Ithem> PuseableToHit = new Stack<Ithem>();
        internal List<Movement> Mooment = new List<Movement>();

        public int notAbleToMuve = 0;
        public bool HaveMuve { get; private set; }
        public double MuvmentSpeed { get; private set; }
        public Karektere(String name, int x, int y, double speed) : base(name, x, y, 20, 20, 100,true)
        {
            MuvmentSpeed = speed;
            Person = new Image[1];
        }
        public void updateSpeed(double speed)
        {
            MuvmentSpeed = speed;
        }
        public override void Draw(Graphics g, int screenX, int screenY)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), (int)X - screenX, (int)Y - screenY, Width, Height);
            while (PuseableToHit.Count > 0)
            {
                Console.WriteLine(PuseableToHit.Pop());
            }
        }
        public override Karektere GetKareakter()
        {
            return this;
        }
        public override void AddPusiabelToHit(Ithem I)
        {
            PuseableToHit.Push(I);
        }
        public override void Muve()
        {
            if(Flying.Count > 0)
            {
                for(int i = Flying.Count - 1; i >= 0;i--)
                {
                    Flying[i].Muve(this);
                    if (Flying[i].helf <= 0)
                    {
                        Flying.RemoveAt(i);
                    }
                }
                for (int i = Mooment.Count - 1; i >= 0; i--)
                {
                    Mooment[i].helf--;
                    if (Mooment[i].helf <= 0)
                    {
                        Mooment.RemoveAt(i);
                    }
                }
            }
            else
            {
                for (int i = Mooment.Count-1; i >= 0; i--)
                {
                    Mooment[i].Muve(this);
                    if (Mooment[i].helf <= 0)
                    {
                        Mooment.RemoveAt(i);
                    }
                }
            }
            for (int i = Pussing.Count - 1; i >= 0; i--)
            {
                Pussing[i].Muve(this);
                if (Pussing[i].helf <= 0)
                {
                    Pussing.RemoveAt(i);
                }
            }
        }
        public abstract Player GetPlayer();
    }
}
