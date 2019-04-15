﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using Programmer.Game.Objekter.Personer;
namespace Programmer.Game.Objekter
{
    abstract class Ithem
    {
        private Image Person;
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public int Width { get; internal set; }
        public int Heith { get; internal set; }
        public int MaxHelf { get; }
        public int Helf { get; internal set; }
        public String Name { get; internal set; }
        public int RunMument { get; set; }
        public Ithem(String name,int LocationX,int LocationY,int helf,bool Laif,int width =1,int height=1)
        {
            X = LocationX;
            Y = LocationY;
            Width = width;
            Heith = height;
            Name = name;
            Helf = helf;
            MaxHelf = helf;
            RunMument = 0;
        }
        public virtual Karektere GetKareakter()
        {
            return null;
        }
        public void SetLocation(int x, int y)
        {
            X = x;
            Y = y;
        }
        public virtual void Draw(Graphics g,int screenX,int screenY,int GridWidth,int GridtHeith)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), (X + screenX) * GridWidth, (Y + screenY) * GridtHeith, GridWidth, GridtHeith);
        }
    }
}