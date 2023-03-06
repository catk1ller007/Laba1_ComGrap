using System;
using System.Collections.Generic;
using System.Drawing;
using Template;

namespace Trans
{
    class transfer : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            if (x < sourceimage.Width - 100)
            {
                return sourceimage.GetPixel(x + 100, y);
            }
            else
            {
                return Color.FromArgb(0, 0, 0);
            }
        }

    }
}
