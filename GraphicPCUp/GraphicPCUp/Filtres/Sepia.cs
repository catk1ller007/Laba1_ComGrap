using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace Sepi
{
    class Sepia : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 25;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int resR = intensity + 2 * k;
            int resG = (int)(intensity + 0.5 * k);
            int resB = intensity - 1 * k;
            Color resultColor = Color.FromArgb(Clamp(resR, 0, 255),
                                               Clamp(resG, 0, 255),
                                               Clamp(resB, 0, 255));
            return resultColor;
        }

    }
}
