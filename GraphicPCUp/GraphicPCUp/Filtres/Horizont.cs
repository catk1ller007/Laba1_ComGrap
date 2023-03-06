using System;
using System.Drawing;
using Template;

namespace Horizont
{
    class HorizontalWaveFilter : Filtres
    {
        private int amplitude;
        private float frequency;

        public HorizontalWaveFilter(Bitmap image, int amplitude, float frequency)
        {
            this.amplitude = amplitude;
            this.frequency = frequency;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceColor, int x, int y)
        {
            int newX = (int)(x + amplitude * Math.Sin(2 * Math.PI * y * frequency / 60));
            newX = Clamp(newX, 0, sourceColor.Width - 1);

            return sourceColor.GetPixel(newX, y);
        }
    }
}
