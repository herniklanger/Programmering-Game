using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using Programmer.Game.Personer;
namespace Programmer.Game.Objekter
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
        public virtual Karektere GetKareakter()
        {
            return null;
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
        public abstract void Muve(double x, double y);
        public abstract void Muve();
    }
}