using Programmer.Game.Objekter.Personer;
using System;
using System.Drawing;
namespace Programmer.Game.Objekter
{
    abstract class Ithem
    {
        int IThemID;
        private Image Person;
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public int Width { get; internal set; }
        public int Heith { get; internal set; }
        public String Name { get; internal set; }
        public int RunMument { get; set; }
        public Ithem(String name, int LocationX, int LocationY, int width = 1, int height = 1)
        {
            X = LocationX;
            Y = LocationY;
            Width = width;
            Heith = height;
            Name = name;
            RunMument = 0;
        }
        public void SetLocation(int x, int y)
        {
            X = x;
            Y = y;
        }
        public virtual Karektere GetKareakter()
        {
            return null;
        }
        public virtual void Event(Karektere Kereatore, int type)
        {

        }
        public virtual void Draw(Graphics g, int screenX, int screenY, int GridWidth, int GridtHeith)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), (X + screenX) * GridWidth, (Y + screenY) * GridtHeith, GridWidth * Width, GridtHeith * Width);
        }
        public abstract string Save();
    }
}