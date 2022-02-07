using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputacionCientifica
{
    class Onda:Vector
    {
        public double m=0.5,t,v,w, w1, w2,x, y, z, z1, z2, z3,z4,z5,z6,z7,z8,z9,z10,z11,z12,z13,z14,z15,z16,z17,z18,z19,z20,z21; 
        public int color;
        public Color c;
        public Color[] Paleta = new Color[16];
        public Onda()
        {
            Paleta[0] = Color.Black;
            Paleta[1] = Color.Navy;
            Paleta[2] = Color.Green;
            Paleta[3] = Color.Aqua;
            Paleta[4] = Color.Red;
            Paleta[5] = Color.Purple;
            Paleta[6] = Color.Maroon;
            Paleta[7] = Color.LightGray;
            Paleta[8] = Color.DarkGray;
            Paleta[9] = Color.Blue;
            Paleta[10] = Color.Lime;
            Paleta[11] = Color.Silver;
            Paleta[12] = Color.Teal;
            Paleta[13] = Color.Fuchsia;
            Paleta[14] = Color.Yellow;
            Paleta[15] = Color.White;

            //for (int k = 0; k < 16; k++)
            //{
            //    int r = Convert.ToInt32(0);
            //    int g = Convert.ToInt32(17 * k);
            //    int b = Convert.ToInt32((10.34 * k) + 100);
            //    Paleta[k] = Color.FromArgb(r, g, b);
            //}
        }

        public void grafOnda(Bitmap pantalla)
        {

            double aux;
            for (int i = 0; i < 650; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    transforma(i, j, out x, out y);
                    aux = w * (Math.Sqrt(x * x + y * y)) - v * t;
                    z = Math.Sin(aux) + 1;
                    color = (int)(Math.Round(z * 7.5));
                    c = Paleta[color];
                    pantalla.SetPixel(i, j, c);
                }
            }
        }

        //Interferencia 2 Ondas
        public void interferencia2(Bitmap pantalla)
        {
            
            int i, j, colorO;
            z = 0;
            for (i = 0; i < 650; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    z = 0;
                    Procesos.transforma(i, j, out x, out y);
                    for (int k = -10; k < 11; k++)
                    {
                        z1 = w * (Math.Sqrt((x + k) * (x + k) + (y - 0) * (y - 0))) - v * t;
                        z1 = Math.Sin(z1) + 1;
                        z += z1;
                    }
                    colorO = (int)((11 + z) % 15);
                    c = Paleta[colorO];
                    pantalla.SetPixel(i, j, c);

                }

            }
        }
        public void interferencia(Bitmap pantalla)
        {
            int i, j, colorO;

            for (i = 0; i < 650; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    Procesos.transforma(i, j, out x, out y);
                    z1 = w * (Math.Sqrt((x + 4) * (x + 4) + (y - 0) * (y - 0))) - v * t;
                    z2 = w * (Math.Sqrt((x - 1) * (x - 1) + (y -0) * (y - 0))) - v * t;
                    z3 = w * (Math.Sqrt((x + 1.5) * (x + 1.5) + (y - 4.33) * (y - 4.33))) - v * t;//tercera onda...

                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;
                    z3 = Math.Sin(z3) + 1;

                    z = z1 + z2 + z3; //
                    colorO = (int)(z * 1.75);
                    c = Paleta[colorO];
                    pantalla.SetPixel(i, j, c);


                }

            }
        }
        public void grafOnda3d(Bitmap pantalla)
        {
            Vector3D v3d = new Vector3D();
            x = -7;
            do
            {
                y = -5;
                do
                {
                    v3d.x0 = x;
                    v3d.y0 = y;
                    z = w * (Math.Sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0))) - v * t;
                    z = 0.5 * Math.Sin(z);
                    v3d.z0 = z;
                    v3d.color0 = Color.DarkGreen;
                    v3d.Encender(pantalla);
                    y = y + 0.1;
                } while (y <= 5);
                x = x + 0.1;
            } while (x <= 7);

        }
        public void ondaMoverx2(Bitmap bitmap)
        {
            Vector3D v3d = new Vector3D();
            double p, p2, z, z0,p3,z1;

            x = -7;
            do
            {
                y = -6;
                do
                {
                    v3d.x0 = x;
                    v3d.y0 = y;

                    p = w * (Math.Sqrt((x + 4) * (x + 4) + (y - 0) * (y - 0))) - v * t;
                    z = 0.5 * Math.Sin(p);

                    p2 = w * (Math.Sqrt((x -1) * (x -1) + (y +0) * (y +0))) - v * t;
                    z0 = 0.5 * Math.Sin(p2);

                    p3 = w * (Math.Sqrt((x + 1.5) * (x + 1.5) + (y - 4.33) * (y -4.33))) - v * t;
                    z1 = 0.5 * Math.Sin(p2);
                    v3d.z0 = z + z0+z1;
                    v3d.color0 = Color.DarkGreen; ;
                    v3d.Encender(bitmap);

                    y = y + 0.09;
                } while (y <= 6);
                x = x + 0.09;
            } while (x <= 7);

        }
    }
}
