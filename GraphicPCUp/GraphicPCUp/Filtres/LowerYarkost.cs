using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace LowYa
{
    class YemshenitYarkosti : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 50;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int resR = sourceColor.R - k;
            int resG = sourceColor.G - k;
            int resB = sourceColor.B - k;
            Color resultColor = Color.FromArgb(Clamp(resR, 0, 255),
                                               Clamp(resG, 0, 255),
                                               Clamp(resB, 0, 255));
            return resultColor;
        }
    }
}
