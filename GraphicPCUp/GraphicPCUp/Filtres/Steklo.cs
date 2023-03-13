using System;
using System.Drawing;
using Template;

namespace stek
{
    class Steklo : Filtres
    {
        private readonly Random _random;

        public Steklo()
        {
            _random = new Random();
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 5;
            int radius = k / 2;

            int newX = Clamp(x + (_random.Next(-radius, radius + 1)), 0, sourceImage.Width - 1);
            int newY = Clamp(y + (_random.Next(-radius, radius + 1)), 0, sourceImage.Height - 1);

            return sourceImage.GetPixel(newX, newY);
        }
    }
}
