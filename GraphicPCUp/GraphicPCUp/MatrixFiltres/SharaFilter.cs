using System;
using Template;
using System.Drawing;

namespace Shara
{
    class SharaFilter: Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int[,] xG = new int[3, 3]
            {
                {3, 0, -3},
                { 10, 0, -10},
                { 3, 0, -3},
            };
            int[,] yG = new int[3, 3]
            {
                { 3, 10, 3},
                { 0, 0, 0},
                { -3, -10, -3},
            };

            int rX = 0, gX = 0, bX = 0;
            int rY = 0, gY = 0, bY = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int pixelX = x + j;
                    int pixelY = y + i;

                    if (pixelX < 0 || pixelX >= sourceImage.Width || pixelY < 0 || pixelY >= sourceImage.Height)
                        continue;

                    Color pixelColor = sourceImage.GetPixel(pixelX, pixelY);

                    rX += pixelColor.R * xG[i + 1, j + 1];
                    gX += pixelColor.G * xG[i + 1, j + 1];
                    bX += pixelColor.B * xG[i + 1, j + 1];

                    rY += pixelColor.R * yG[i + 1, j + 1];
                    gY += pixelColor.G * yG[i + 1, j + 1];
                    bY += pixelColor.B * yG[i + 1, j + 1];
                }
            }

            int r = (int)Math.Sqrt(rX * rX + rY * rY);
            int g = (int)Math.Sqrt(gX * gX + gY * gY);
            int b = (int)Math.Sqrt(bX * bX + bY * bY);

            return Color.FromArgb(Clamp(r, 0, 255), Clamp(g, 0, 255), Clamp(b, 0, 255));
        }
    }
}
