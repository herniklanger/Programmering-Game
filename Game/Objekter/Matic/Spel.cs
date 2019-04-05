using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game.Game.Objekter.Matic
{
    public struct Spel
    {
        public Image symbol;
        public string name;
        public Spel(Image image,string name)
        {
            symbol = image;
            this.name = name;
        }
        public Spel(string ImageLocation,string name)
        {
            symbol = Image.FromFile(ImageLocation);
            this.name = name;
        }
    }
}
