using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace Vertical
{
    class VerticalWaveFilter : Filtres
    {
        private int amplitude;
        private float frequency;

        public VerticalWaveFilter(Bitmap image, int amplitude, float frequency)
        {
            this.amplitude = amplitude;
            this.frequency = frequency;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceColor, int x, int y)
        {
            int newY = (int)(y + amplitude * Math.Sin(2 * Math.PI * x * frequency / sourceColor.Width));
            newY = Clamp(newY, 0, sourceColor.Height - 1);

            return sourceColor.GetPixel(x, newY);
        }

    }
}
