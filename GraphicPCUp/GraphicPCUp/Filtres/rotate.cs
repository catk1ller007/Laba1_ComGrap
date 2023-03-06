using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace Trasform
{
    class turn : Filtres
    {
        private int indexX;
        private int indexY;

        public turn(Bitmap image, int indexX, int indexY)
        {
            this.indexX = indexX;
            this.indexY = indexY;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            int newX = 0;
            int newY = 0;

            double gradus = 45.0;
            double radian = gradus * Math.PI / 180;

            newX = (int)((indexX - x) * Math.Cos(radian) - (indexY - y) * Math.Sin(radian) + x);
            newY = (int)((indexX - x) * Math.Sin(radian) + (indexY - y) * Math.Cos(radian) + y);
            //for (int i = 0; i < sourceimage.Width; i++)
            //{
            //    for (int j = 0; j < sourceimage.Height; j++)
            //    {
            //        newX = (int)((i - x) * Math.Cos(gradus) - (j - y) * Math.Sin(gradus) + x);
            //        newY = (int)((i - x) * Math.Sin(gradus) + (j - y) * Math.Cos(gradus) + y);
            //    }
            //}
            newX = Clamp(newX, 0, sourceimage.Width - 1);
            newY = Clamp(newY, 0, sourceimage.Width - 1);

            return sourceimage.GetPixel(newX, newY);
        }
    }
}
