using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using Game.Game.Objekter.Matic;
using Game.Game.Objekter.Movements;
using Game.Game.Personer;
namespace Game.Game.Objekter
{
    abstract class Ithem
    {
        private Image Person;
        public double X { get; internal set; }
        public double Y { get; internal set; }
        public int Width { get; internal set; }
        public int Height { get; internal set; }
        public int MaxHelf { get; }
        public int Helf { get; internal set; }
        public String Name { get; internal set; }
        public int RunMument { get; set; }
        public List<Movement> Pussing = new List<Movement>();
        public List<Movement> Flying = new List<Movement>();
        public Ithem(String name,double LocationX,double LocationY,int width,int height,int helf,bool Laif)
        {
            X = LocationX;
            Y = LocationY;
            Width = width;
            Height = height;
            Name = name;
            Helf = helf;
            MaxHelf = helf;
            RunMument = 0;
        }
        public virtual void Muve(double x, double y)
        {
            X =(int) x;
            Y =(int) y;
        }
        public virtual void Muve()
        {
            for(int i = Flying.Count-1;i>= 0 ;i--)
            {
                Flying[i].Muve(this);
                if (Flying[i].helf <= 0)
                {
                    Flying.RemoveAt(i);
                }
            }
            for (int i = Pussing.Count-1;i >= 0 ;i--)
            {
                Pussing[i].Muve(this);
                if (Pussing[i].helf <= 0)
                {
                    Pussing.RemoveAt(i);
                }
            }
        }
        public virtual Spells GetSpell()
        {
            return null;
        }
        public virtual Karektere GetKareakter()
        {
            return null;
        }
        public virtual void AddPusiabelToHit(Ithem I)
        {
            return;
        }
        public void SetLocation(double x, double y)
        {
            X = x;
            Y = y;
        }
        public virtual void Draw(Graphics g, int screenX, int screenY)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), (int)X - screenX, (int)Y - screenY, Width, Height);
        }
        public virtual void Delete()
        {

        }
    }
}