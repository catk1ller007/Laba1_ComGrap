using System.Drawing;
using Template;

namespace GRAD
{
    class Gradient : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color DilatedColor;
            Color ErosedColor;

            DilatedColor = DilcalculateNewPixelColor(sourceImage, x, y);
            ErosedColor = ErcalculateNewPixelColor(sourceImage, x, y);

            int R = Clamp(DilatedColor.R - ErosedColor.R, 0, 255);
            int G = Clamp(DilatedColor.G - ErosedColor.G, 0, 255);
            int B = Clamp(DilatedColor.B - ErosedColor.B, 0, 255);

            return Color.FromArgb(R, G, B);
        }

        public Color DilcalculateNewPixelColor(Bitmap sourceImage, int x, int y)
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

        public Color ErcalculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int[,] kernel = { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
            double MIN = 255;
            Color resultColor = sourceImage.GetPixel(x, y);

            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color sourceColor = sourceImage.GetPixel(idX, idY);
                    if ((kernel[i + 1, j + 1] != 0) && (sourceColor.GetBrightness() < MIN))
                    {
                        MIN = sourceColor.GetBrightness();
                        resultColor = sourceColor;
                    }
                }
            }

            return resultColor;
        }
    }
}
