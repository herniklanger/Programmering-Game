using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game.Objekter.Matic;
using Game.Game.Objekter.Movements;

namespace Game.Game.Personer
{
    class Mugler : Karektere
    {
        public Mugler(int x, int y) : base("Mugler",x, y, 20)
        {

        }
        public override void Draw(Graphics g,int screenX,int ScreemY)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)),(int)X- screenX, (int)Y-ScreemY,Width, Height);
        }
        public override void Muve()
        {
            base.Muve();
            Mooment.Add(new Movement(1,1, MuvmentSpeed,1));
        }
        public override Spells GetSpell()
        {
            return null;
        }
        public override Karektere GetKareakter()
        {
            return this;
        }
        public override Player GetPlayer()
        {
            return null;
        }
    }
}
