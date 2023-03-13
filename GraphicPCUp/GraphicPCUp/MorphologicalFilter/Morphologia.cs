using System;
using System.ComponentModel;
using System.Drawing;
using Template;

namespace LabaOneGraphics
{
    class MorphologicalDilationFilter : MorphologicalFilters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int maxR = 0;
            int maxG = 0;
            int maxB = 0;
            for (int i = -n; i <= n; i++)
            {
                for (int j = -m; j <= m; j++)
                {
                    int xx = x + i;
                    int yy = y + j;
                    if (structuring_element[i + n, j + m] == 1 && xx >= 0 && yy >= 0 && xx < sourceImage.Width && yy < sourceImage.Height)
                    {
                        Color color = sourceImage.GetPixel(xx, yy);
                        maxR = Math.Max(maxR, color.R);
                        maxG = Math.Max(maxG, color.G);
                        maxB = Math.Max(maxB, color.B);
                    }
                }
            }
            return Color.FromArgb(maxR, maxG, maxB);
        }
    }
    class MorphologicalErosionFilter : MorphologicalFilters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int minR = 255;
            int minG = 255;
            int minB = 255;
            for (int i = -n; i <= n; i++)
            {
                for (int j = -m; j <= m; j++)
                {
                    int xx = x + i;
                    int yy = y + j;
                    if (structuring_element[i + n, j + m] == 1 && xx >= 0 && yy >= 0 && xx < sourceImage.Width && yy < sourceImage.Height)
                    {
                        Color color = sourceImage.GetPixel(xx, yy);
                        minR = Math.Min(minR, color.R);
                        minG = Math.Min(minG, color.G);
                        minB = Math.Min(minB, color.B);
                    }
                }
            }
            return Color.FromArgb(minR, minG, minB);
        }
    }
    class MorphologicalOpeningFilter : MorphologicalFilters
    {
        public override Bitmap ProccesImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Filtres tmp = new MorphologicalErosionFilter();
            Filtres tmp2 = new MorphologicalDilationFilter();
            return tmp2.ProccesImage(tmp.ProccesImage(sourceImage, worker), worker);
        }
    }
    class MorphologicalClosingFilter : MorphologicalFilters
    {
        public override Bitmap ProccesImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Filtres tmp = new MorphologicalDilationFilter();
            Filtres tmp2 = new MorphologicalErosionFilter();
            return tmp2.ProccesImage(tmp.ProccesImage(sourceImage, worker), worker);
        }
    }
    class MorphologicalTopHatFilter : MorphologicalFilters
    {
        public override Bitmap ProccesImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Filtres filter = new MorphologicalClosingFilter();
            Bitmap closingImage = filter.ProccesImage(sourceImage, worker);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((double)i / resultImage.Width * 50) + 50);
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    Color color_closing = closingImage.GetPixel(i, j);
                    resultImage.SetPixel(i, j, Color.FromArgb(
                        Clamp(-color.R + color_closing.R, 0, 255),
                        Clamp(-color.G + color_closing.G, 0, 255),
                        Clamp(-color.B + color_closing.B, 0, 255)));
                }
            }
            return resultImage;
        }
    }
    class MorphologicalBlackHatFilter : MorphologicalFilters
    {
        public override Bitmap ProccesImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Filtres filter = new MorphologicalErosionFilter();
            Bitmap openImage = filter.ProccesImage(sourceImage, worker);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((double)i / resultImage.Width * 50) + 50);
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    Color color_open = openImage.GetPixel(i, j);
                    resultImage.SetPixel(i, j, Color.FromArgb(
                        Clamp(color.R - color_open.R, 0, 255),
                        Clamp(color.G - color_open.G, 0, 255),
                        Clamp(color.B - color_open.B, 0, 255)));
                }
            }
            return resultImage;
        }
    }
    class MorphologicalGradFilter : MorphologicalFilters
    {
        public override Bitmap ProccesImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            Filtres Erosion = new MorphologicalErosionFilter();
            Bitmap ErosionImage = Erosion.ProccesImage(sourceImage, worker);

            Filtres Dilation = new MorphologicalDilationFilter();
            Bitmap DilationImage = Dilation.ProccesImage(sourceImage, worker);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((double)i / resultImage.Width * 34) + 66);
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color colorErosion = ErosionImage.GetPixel(i, j);
                    Color colorDilation = DilationImage.GetPixel(i, j);
                    resultImage.SetPixel(i, j, Color.FromArgb(
                        Clamp(-colorErosion.R + colorDilation.R, 0, 255),
                        Clamp(-colorErosion.G + colorDilation.G, 0, 255),
                        Clamp(-colorErosion.B + colorDilation.B, 0, 255)));
                }
            }
            return resultImage;
        }
    }
}
