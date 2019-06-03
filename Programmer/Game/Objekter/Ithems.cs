using Programmer.Game.Objekter.Personer;
using System;
using System.Drawing;
namespace Programmer.Game.Objekter
{
    abstract class Ithems
    {
        public int IthemID { get; }
        private Image Person;
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public int Width { get; internal set; }
        public int Heith { get; internal set; }
        public String Name { get; set; }
        public int RunMument { get; set; }
        public Ithems(String name, int IthemID, int LocationX, int LocationY, int width = 1, int height = 1)
        {
            this.IthemID = IthemID;
            X = LocationX;
            Y = LocationY;
            Width = width;
            Heith = height;
            Name = name;
            RunMument = 0;
        }
        /// <summary>
        /// updating the locations values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
        /// <summary>
        /// Draw the Ithem
        /// </summary>
        /// <param name="g"></param>
        /// <param name="screenX"></param>
        /// <param name="screenY"></param>
        /// <param name="GridWidth"></param>
        /// <param name="GridtHeith"></param>
        public virtual void Draw(Graphics g, int screenX, int screenY, int GridWidth, int GridtHeith)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), (X + screenX) * GridWidth, (Y + screenY) * GridtHeith, GridWidth * Width, GridtHeith * Heith);
        }
        /// <summary>
        /// returne the valuse for saving in the txt database
        /// </summary>
        /// <returns></returns>
        public abstract object[] Save();
        /// <summary>
        /// return the names of the waluse for columns of a database
        /// </summary>
        /// <returns></returns>
        public abstract string[] ValuseName();
        /// <summary>
        /// Make a hard copy of the object
        /// </summary>
        /// <returns></returns>
        public abstract Ithems Copy(int id = -1);
    }
}