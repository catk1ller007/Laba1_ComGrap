using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace Dilat
{
    class Dilation : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int[,] kernel = { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
            double MAX = 0;
            Color resultColor = sourceImage.GetPixel(x, y);
            for (int j = -1; j <= 1; j++)
            {

                for (int i = -1; i <= 1; i++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color sourceColor = sourceImage.GetPixel(idX, idY);
                    if ((kernel[i + 1, j + 1] != 0) && (sourceColor.GetBrightness() > MAX))
                    {
                        MAX = sourceColor.GetBrightness();
                        resultColor = sourceColor;
                    }
                }
            }
            return resultColor;
        }
    }
}
