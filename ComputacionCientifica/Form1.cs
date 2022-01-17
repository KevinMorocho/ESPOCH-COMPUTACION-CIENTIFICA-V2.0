using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputacionCientifica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap lienzo = new Bitmap(650, 500);
        private void pintaFondo(Color fondo) { 
            for (int i = 0; i < 650; i++) 
            { 
                for (int j = 0; j < 500; j++) 
                { 
                    lienzo.SetPixel(i, j, fondo); 
                } 
            } 
        }
        //Btn Limpiar
        private void button1_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            EspacioT.Image = lienzo;
        }
        
        //Bandera
        private void button2_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            for (int i = 0; i < 650; i++)
            {
                for (int j = 0; j < 500; j++)
                {

                    lienzo.SetPixel(i, j, Color.Red);
                    if (j >= 201)
                    {
                        lienzo.SetPixel(i, j, Color.Blue);
                    }
                    if (j >= 401)
                    {
                        lienzo.SetPixel(i, j, Color.GreenYellow);
                    }
                }
            }
            EspacioT.Image = lienzo;
        }

        //Btn Segmento
        private void button3_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            Segmento S = new Segmento();
            S.x0 = -3;
            S.xf = 5;
            S.y0 = 1;
            S.yf = 4;
            S.color0 = Color.Black;
            S.Encender(lienzo);
            EspacioT.Image = lienzo;
        }

        //BtnCircunferemcia
        private void button4_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            /*Circunferencia c = new Circunferencia();
            c.Radio = 3.0;
            c.x0 = 0;
            c.y0 = 0;
            c.color0 = Color.Blue;
            c.Encender(lienzo);
            EspacioT.Image = lienzo;
            */
            Circunferencia c = new Circunferencia();
            double x = -7;            
            c.Radio = 1.0;
            c.x0 = -7;
            c.y0 = 0;
            /*c.color0 = Color.Blue;
            c.Encender(lienzo);
            EspacioT.Refresh();
            Thread.Sleep(200);
            c.apagar(lienzo);
            EspacioT.Image = lienzo;*/
            //Animación de circunferencia
            do
            {
                c.x0 = x;
                c.y0 = Math.Sin(x);
                c.color0 = Color.Blue;
                c.Encender(lienzo);
                EspacioT.Refresh();
                Thread.Sleep(30);
                x = x + 0.4;
                c.apagar(lienzo);
                EspacioT.Image = lienzo;
            } while (x <= 7);


        }

        //Btn Interpolar
        int interpola(int y1, int y2, int x)
        {
            int x1 = 0;
            int x2 = 500;
            int y = 0;
            y = (int)((x - x1) * (y2 - y1) / (x2 - x1)) + y1;
            return y;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            for (int i = 0; i < 650; i++)
            {
                for (int j = 0; j < 500; j++)
                {

                    //lienzo.SetPixel(i, j, Color.FromArgb((int)((-0.51 * j) +255), 0, (int)(0.51*j)));
                    lienzo.SetPixel(i, j, Color.FromArgb(interpola(192,135,j),interpola(192, 206, j), interpola(192, 235, j)));
                    //lienzo.SetPixel(i, j, Color.FromArgb(interpola(59, 0, j), interpola(131, 0, j), interpola(189, 255, j)));
                    EspacioT.Image = lienzo;
                }
            }
        }

        //Btn Graficar segmento y circunferencia
        private void button6_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            Circunferencia c = new Circunferencia();
            Segmento S = new Segmento();
            c.Radio = 2.0;
            c.x0 = 4;
            c.y0 = 2.5;
            c.color0 = Color.Blue;
            c.Encender(lienzo);
            EspacioT.Image = lienzo;
            c.Radio = 1.0;
            c.x0 = -4;
            c.y0 = -2.5;
            c.color0 = Color.Blue;
            c.Encender(lienzo);
            EspacioT.Image = lienzo;
            S.x0 = -5;
            S.xf = 5.5;
            S.y0 =-3;
            S.yf = 3.5;
            S.color0 = Color.Black;
            S.Encender(lienzo);
            EspacioT.Image = lienzo;
            S.x0 = -1;
            S.xf = 1;
            S.y0 = 4;
            S.yf = -4;
            S.color0 = Color.Blue;
            S.Encender(lienzo);
            EspacioT.Image = lienzo;
            S.x0 = -5;
            S.xf = 5;
            S.y0 = 3;
            S.yf = 5;
            S.color0 = Color.Red;
            S.Encender(lienzo);
            EspacioT.Image = lienzo;
        }
        //Funcion Paleta
        Color[] paleta1 = new[]
        {
            Color.Black,
            Color.Navy,
            Color.Green,
            Color.Aqua,
            Color.Red,
            Color.Purple,
            Color.Maroon,//ojo
            Color.LightGray,
            Color.DarkGray,
            Color.Blue,
            Color.Lime,
            Color.Silver,
            Color.Teal,
            Color.Fuchsia,
            Color.Yellow,
            Color.White
        };

        //Btn Paleta
        private void button7_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            int k;
            Color[] paleta2 = new Color[16];
            for (int a = 0; a <= 15; a++)
            {
                paleta2[a] = Color.FromArgb(255, 17 * a, 0);
            }
            for (int i = 0; i < 650; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                        
                        if (i <= 325)
                        {
                            k = (i * 5 + j * 6) % 15;
                        lienzo.SetPixel(i, j, paleta2[k]);
                            EspacioT.Image = lienzo;
                        }
                        if (i > 325)
                        {
                            k = (int)(((i * 10) * (Math.Pow(Math.E, 10))) % 15);
                            lienzo.SetPixel(i, j, paleta2[k]);
                            EspacioT.Image = lienzo;
                        }

                }
            }
        }
        //Animacion Circunferencia en circulo Parcial 2
        private void button8_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            Circunferencia c = new Circunferencia();
            c.Radio = 3.0;
            c.x0 = 0;
            c.y0 = 0;
            c.color0 = Color.Blue;
            c.Encender(lienzo);

            c.Radio = 5.0;
            c.x0 = 0;
            c.y0 = 0;
            c.color0 = Color.Blue;
            c.Encender(lienzo);

            double t = 0.02;

            do
            {
                c.Radio = 0.4;
                c.x0 = 4 *Math.Sin(t);
                c.y0 = 4 *Math.Cos(t);
                c.color0 = Color.Green;
                c.Encender(lienzo);
                EspacioT.Refresh();
                Thread.Sleep(30);
                c.apagar(lienzo);
                EspacioT.Image = lienzo;
                t += 0.1;
            } while (t <= (2 * Math.PI));

            EspacioT.Image = lienzo;
        }

        //Paleta Agua
        private void button9_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            Color[] Paleta2 = new Color[16];
            int ColorT;
            for (int i = 0; i <= 15; i++)
            {
                Paleta2[i] = Color.FromArgb((int)(-17 * i + 255), (int)(-10.86 * i + 255), (int)(-8.33 * i + 255));
                //Paleta2[i] = Color.FromArgb(interpola(21,255,i), interpola(67, 255, i), interpola(96, 255, i));
            }
            for (int Sx = 0; Sx < 650; Sx++)
            {
                for (int Sy = 0; Sy < 500; Sy++)
                {
                    //ColorT = (int)(Math.Log10(Math.Sqrt(Sy / 7)) * 15);
                    //ColorT = Math.Abs(ColorT % 15);

                    ColorT = (int)(Math.Tan(Sx)*(Math.Sin(10 * Sy) ) +( Math.Pow(Sx, 3) + (Math.Pow(Sx, 2) * Sy / 10 + Math.Pow(Sy, 2) / 6))) % 15;
                    //ColorT = (int)(Math.Sqrt(ColorT*4));
                    lienzo.SetPixel(Sx, Sy, Paleta2[ColorT]);
                    EspacioT.Image = lienzo;
                }
            }
        }


        
        
        //BtnParabola
        private void Parabola_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            double x = -8;
            double dx = 0.03;
            Circunferencia c = new Circunferencia();
            c.Radio = 0.3;
            Segmento S = new Segmento();
            S.x0 = -8;
            S.xf = 8;
            S.y0 = 0;
            S.yf = 0;
            S.color0 = Color.Red;
            S.Encender(lienzo);
            S.x0 = 0;
            S.xf = 0;
            S.y0 = -6.15;
            S.yf = 6.15;
            S.color0 = Color.Red;
            S.Encender(lienzo);
            do
            {
                c.x0 = x;
                c.y0 = (64 - Math.Pow(c.x0, 2)) / 10;
                c.color0 = Color.Green;
                c.Encender(lienzo);
                x = x + dx;
                EspacioT.Refresh();
                Thread.Sleep(10);
                c.apagar(lienzo);
                EspacioT.Image = lienzo;

            } while (x <= 8);
        }

        //BtnOnda
        private void button10_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            Onda o = new Onda();
            double t = 0;
            //Sin animacion

            //Una Onda
            //o.v = 9.3;
            //o.w = 1.5;
            //o.t = t;
            //o.grafOnda(lienzo);
            //EspacioT.Image = lienzo;

            //Dos Ondas
            //o.v = 9.3;
            //o.w = 1.5;
            //o.t = 0;
            //o.interferencia(lienzo);
            //EspacioT.Image = lienzo;

            //Con animacion

            //Una 3 Onda
            do
            {
                o.v = 9.3;
                o.w = 1.5;
                o.interferencia(lienzo);
                EspacioT.Image = lienzo;
                EspacioT.Refresh();
                t = t + 0.1;
                o.t = t;
            } while (t <= 3);

            //do
            //{
            //    o.v = 9.3;
            //    o.w = 2.5;
            //    o.t = t;
            //    o.ondaMoverx2(lienzo);
            //    EspacioT.Image = lienzo;
            //    Refresh();
            //    lienzo = null;
            //    lienzo = new Bitmap(700, 500);
            //    Thread.Sleep(5);
            //    t = t + 0.01;
            //} while (t <= 4);
        }
        //btn 3D
        private void button11_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            double t = 0;
            Vector3D v3d = new Vector3D();
            do
            {
                v3d.x0 = 2 + 3 * Math.Cos(t);
                v3d.y0 = -1 + 3 * Math.Sin(t);
                v3d.z0 = 0;
                v3d.color0 = Color.Red;
                v3d.Encender(lienzo);
                EspacioT.Image = lienzo;
                t = t + 0.01;
            } while (t <= 6.3);
        }

        //BTn Hiperboloide
        private void BTNHiperboloide_Click(object sender, EventArgs e)
        {
            pintaFondo(Color.White);
            SuperficieV s = new SuperficieV();
            int tipo = 1;
            s.color0 = Color.GreenYellow;
            s.tipo = tipo;
            s.radio = 1;
            s.Encender(lienzo);
            EspacioT.Image = lienzo;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Vector3D w = new Vector3D();
            double h = 0, t;
            //do
            //{
            //    w.x0 = 1 + ((3 - h/5) * Math.Sin(h));
            //    w.y0 = -1 + ((4 - h/5) * Math.Cos(h));
            //    w.z0 = (h / 3)-2;
            //    w.color0 = Color.Red;
            //    w.Encender(lienzo);
            //    EspacioT.Image = lienzo;
            //    h = h + 0.05;
            //} while (h <= 15);
            //do
            //{
            //    t = 0;
            //    do
            //    {
            //        w.x0 = -2 + 3 * Math.Cos(t);
            //        w.y0 = h;
            //        w.z0 = 1 + 3 * Math.Sin(t);
            //        w.color0 = Color.Red;
            //        w.Encender(lienzo);
            //        EspacioT.Image = lienzo;
            //        t = t + 0.1;


            //    } while (t <= 15);
            //    h = h + 0.1;
            //} while (h <= 6.3);
            //do
            //{
            //    t = 0;
            //    do
            //    {
            //        w.x0 = -2 + 3 * Math.Cos(t);
            //        w.y0 =  1 + 3 * Math.Sin(t);
            //        w.z0 = h-3;
            //        w.color0 = Color.Red;
            //        w.Encender(lienzo);
            //        EspacioT.Image = lienzo;
            //        t = t + 0.1;
            //    } while (t <= 15);
            //    h = h + 0.1;
            //} while (h <= 6.3);
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Onda o = new Onda();
            double t = 0;
            //Sin animacion
            //o.v = 9.3;
            //o.w = 2.5;
            //o.t = 0;
            //o.grafOnda3d(lienzo);
            //EspacioT.Image = lienzo;

            //Animacion Una onda 3D
            o.v = 9.8;
            o.w = 1.5;
            do
            {
                o.t = t;
                o.grafOnda3d(lienzo);
                EspacioT.Image = lienzo;
                Refresh();
                lienzo = null;
                lienzo = new Bitmap(650, 500);
                Thread.Sleep(5);
                t = t + 0.01;
            } while (t <= 4);

            //Animacion Dos ondas 3D
            //do
            //{
            //    o.t = t;
            //    o.ondaMoverx2(lienzo);
            //    EspacioT.Image = lienzo;
            //    Refresh();
            //    lienzo = null;
            //    lienzo = new Bitmap(650, 500);
            //    Thread.Sleep(5);
            //    t = t + 0.01;
            //} while (t <= 4);


        }
    }
}
