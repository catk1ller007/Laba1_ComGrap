using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;
using GraphicPCUp;
namespace Invert
{
    class InvertFilter : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap naitiImage, int x, int y)
        {
            Color naitiColor = naitiImage.GetPixel(x, y);

            Color resultColor = Color.FromArgb(255 - naitiColor.R, 255 - naitiColor.G, 255 - naitiColor.B);

            return resultColor;
        }
    }
}
