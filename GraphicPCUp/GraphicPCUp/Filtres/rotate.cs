using System;
using System.Drawing;
using Template;

namespace Trasform
{
    class turn : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = (int)((x) * Math.Cos((10 * (Math.PI)) / 180) - (y) * Math.Sin((10 * (Math.PI)) / 180));
            int newY = (int)((x) * Math.Sin((10 * (Math.PI)) / 180) + (y) * Math.Cos((10 * (Math.PI)) / 180));

            newX = Clamp(newX, 0, sourceImage.Width - 1);
            newY = Clamp(newY, 0, sourceImage.Height - 1);

            if (!(newX != sourceImage.Width - 1 && newY != sourceImage.Height - 1))
            {
                return Color.Black;
            }

            if (newX == 0)
            {
                return Color.Black;
            }

            return sourceImage.GetPixel(newX, newY);
        }
    }
}
