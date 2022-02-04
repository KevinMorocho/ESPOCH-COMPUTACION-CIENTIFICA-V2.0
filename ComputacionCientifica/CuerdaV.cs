using System;
using System.Drawing;

namespace ComputacionCientifica
{
    class CuerdaV : Vector
    {
        public double tiempo;
        public CuerdaV() { }

        double fx(int x)
        {
            double f = (-x * (x - 8) / 3);
            return f;
        }
        int gx(int x)
        {
            int g = x;
            return g;
        }
        public void Fourier(double x, out double fou)
        {
            double an, bn, sumF = 0;
            int n = 0;

            do
            {
                n = n + 1;
                //Se aplica Formula de Simpson a continuacion ejemplo de formula
                //an = (l-0/6)* (f(0)sin(n*pi*0)+4*f(4)*sin(n*pi*4/l)+f(8)*sin(n*pi*8/l)) l=8

                an = 1.33 * (0 + 4 * fx(4) * Math.Sin(n * Math.PI * 0.5) + fx(8) * Math.Sin(n * Math.PI));
                an = an * (0.25);

                bn = 1.33 * (0 + 4 * gx(4) * Math.Sin(n * Math.PI * 0.5) + gx(8) * Math.Sin(n * Math.PI)); ;
                bn = bn * (2 / (n * Math.PI));

                sumF = sumF + (an * Math.Cos((n * Math.PI * tiempo) / 8) + bn * Math.Sin((n * Math.PI * tiempo) / 8)) * Math.Sin(n * 3.14 * x / 8);

            } while (n <= 20);

            fou = sumF;
        }
        public void GraficoFourier(Bitmap pantalla)
        {
            double x = 0;
            Vector v = new Vector();
            Segmento s = new Segmento();
            do
            {
                v.x0 = x;
                Fourier(x, out double fou);

                //if (fou <= 10.77)
                //{
                v.y0 = fou;
                v.color0 = Color.Blue;
                v.Encender(pantalla);

                s.x0 = x;
                s.y0 = fou;
                s.color0 = Color.Blue;
                s.Encender(pantalla);
                s.xf = x;
                s.yf = fou;
                //}
                //Console.WriteLine(fou);

                x = x + 0.05;
            } while (x <= 8);
        }
    }
}
