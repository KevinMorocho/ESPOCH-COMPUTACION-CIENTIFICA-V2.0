using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputacionCientifica
{
    class Segmento:Vector
    {
        public double xf { get; set; }
        public double yf { get; set; }

        public Segmento()
        {

        }

        public override void Encender(Bitmap lienzo)
        {
            double t = 0;
            double dt = 0.001;
            Vector v = new Vector();
            do
            {
                v.x0 = (x0 + (xf - x0) * t);
                v.y0 = (y0 + (yf - y0) * t);
                v.color0 = color0;
                v.Encender(lienzo);
                t = t + dt;

            } while (t <= 1);
        }
        int interpola(int y0, int yf, double x, int xf)
        {
            int x0 = 0;
            double y = 0;
            y = (int)((x - x0) * (yf - y0) / (xf - x0)) + y0;
            return (int)y;
        }
        public void EncenderDegradado(Bitmap lienzo)
        {
            double t = 0;
            double dt = 0.001;
            int maxX = 1;
            Vector v = new Vector();
            int r = 0;
            int g = 0;
            int b = 0;
             
            do
            {
                if (t <= (0.5))
                {
                    r = interpola(255, 0, t, maxX);
                    g = interpola(255, 0, t, maxX);
                    b = interpola(0, 255, t, maxX);
                }
                else
                {
                    r = interpola(0, 255, t, maxX);
                    g = 0;
                    b = interpola(255, 0, 1, maxX);
                }
                v.x0 = (x0 + (xf - x0) * t);
                v.y0 = (y0 + (yf - y0) * t);
                v.color0 = Color.FromArgb(r,g,b);
                v.Encender(lienzo);
                t = t + dt;

            } while (t <= 1);
        }
    }
}
