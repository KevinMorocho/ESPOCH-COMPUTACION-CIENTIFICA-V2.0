using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputacionCientifica
{
    class Segmento3D:Vector3D
    {
        public double xf { get; set; }
        public double yf { get; set; }
        public double zf { get; set; }

        public override void Encender(Bitmap lienzo)
        {
            double t = 0;
            double dt = 0.001;
            Vector3D v = new Vector3D();

            do
            {
                v.x0 = (x0 * (1 - t)) + (xf * t);
                v.y0 = (y0 * (1 - t)) + (yf * t);
                v.z0 = (z0 * (1 - t)) + (zf * t);
                v.color0 = color0;
                v.Encender(lienzo);
                t = t + dt;

            } while (t <= 1);
        }
    }
}
