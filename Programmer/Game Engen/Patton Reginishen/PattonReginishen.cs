using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Programmer.Game_Engen.Patton_Reginishen
{
    class PattonReginision
    {
        //Queue<Point> Mynster;
        private static PattonReginision instans;
        private PattonReginision()
        {

        }
        public static PattonReginision Inilizer()
        {
            if(instans == null)
            {
                instans = new PattonReginision();
            }
            return instans;
        }
        public void findMynster(List<Point> Drawing)
        {
            Point start = Drawing[0];
            Point slut = Drawing[Drawing.Count - 1];
            double afstand = Math.Sqrt(Math.Pow(start.X - slut.X, 2) + Math.Pow(start.Y - slut.Y, 2));
            
        }
        
    }
}
