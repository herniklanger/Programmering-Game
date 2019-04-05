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
    class Player : Karektere
    {
        public Player(String name,int startPosisioX,int startPosisioY):base(name,startPosisioX,startPosisioY,40)
        {
            
        }
        public override Spells GetSpell()
        {
            return null;
        }
        public override Player GetPlayer()
        {
            return this;
        }
        public void addMoovment(Movement m)
        {
            Mooment.Add(m);
        }
        public void addMoovment(int x,int y)
        {
            Mooment.Add(new Movement(x,y, MuvmentSpeed));
        }
    }
}
