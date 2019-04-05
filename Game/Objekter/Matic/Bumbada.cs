using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Game_Engen;
using Game.Game.Personer;

namespace Game.Game.Objekter.Matic
{
    class Bumbada : Spells
    {
        public int endX = 0, endY= 0;
        public Ithem[] heddet;
        public Bumbada(Ithem carster, int musX, int musY) : base(carster, "Bumbada", carster.X, carster.Y, 3, 3, musX, musY, 10, 60)
        {
            endX = musX;
            endY = musY;
        }
        public Bumbada(Ithem carster, double startX, double startY, int musX, int musY) : base(carster, "Bumbada", startX, startY, 3, 3, musX, musY, 10, 60)
        {
            endX = musX;
            endY = musY;
        }
        public override void Muve(double not1 = 0, double not2 = 0)
        {
            if(heddet != null)
            {
                Ithem hit = Engen2D.Engenen2D().Hiditextion(X + MuvmentX, Y + MuvmentY, this);
                if (hit != null||X > endX ^ X + MuvmentX > endX || Y > endY ^ Y + MuvmentY > endY)
                {
                    heddet=Engen2D.Engenen2D().IthemInTheReadius(5,this);
                    foreach(Ithem hed in heddet)
                    {
                        if(hed.GetKareakter() !=null)
                        {
                            hed.GetKareakter().notAbleToMuve++;
                        }
                    }
                    Helf--;
                }
                X += MuvmentX;
                Y += MuvmentY;
            }
            
            Helf--;
        }
        public override void Delete()
        {
            foreach(Karektere hit in heddet)
            {
                if (hit != null && hit.GetKareakter() != null)
                {
                    hit.GetKareakter().notAbleToMuve--;
                }
            }
            
        }
        public override void Hit(Ithem heitet)
        {
            heddet = Engen2D.Engenen2D().IthemInTheReadius(5, this);
            foreach (Ithem hed in heddet)
            {
                if (hed.GetKareakter() != null)
                {
                    hed.GetKareakter().notAbleToMuve++;
                }
            }
            Helf--;
        }
    }
}
