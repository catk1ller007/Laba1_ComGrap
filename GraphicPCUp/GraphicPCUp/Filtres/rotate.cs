using System;
using System.Drawing;
using Template;

namespace Trasform
{
    class turn : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int x0 = sourceImage.Width / 2;
            int y0=sourceImage.Height / 2;

            int newX = (int)((x-x0) * Math.Cos((45 * (Math.PI)) / 180) - (y-y0) * Math.Sin((45 * (Math.PI)) / 180)+ x0);
            int newY = (int)((x-x0) * Math.Sin((45 * (Math.PI)) / 180) + (y-y0) * Math.Cos((45 * (Math.PI)) / 180)+y0);

            newX = Clamp(newX, 0, sourceImage.Width - 1);
            newY = Clamp(newY, 0, sourceImage.Height - 1);

            if (!(newX != sourceImage.Width - 1 && newY != sourceImage.Height - 1))
            {
                return Color.Black;
            }

            if (newX == 0 || newY == 0)
            {
                return Color.Black;
            }

            return sourceImage.GetPixel(newX, newY);
        }
    }
}
