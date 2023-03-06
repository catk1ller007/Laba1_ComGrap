using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace Template
{
    abstract class Filtres
    {
        protected abstract Color calculateNewPixelColor(Bitmap naitiImage, int x, int y);
        public Bitmap ProccesImage(Bitmap naitiImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(naitiImage.Width, naitiImage.Height);

            for (int i = 0; i < naitiImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));

                if (worker.CancellationPending)
                {
                    return null;
                }
                for (int j = 0; j < naitiImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(naitiImage, i, j));
                }
            }

            return resultImage;
        }
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }

            return value;
        }
    }
    class MatrixFilter : Filtres
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }
        protected override Color calculateNewPixelColor(Bitmap naitiImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, naitiImage.Width - 1);
                    int idY = Clamp(y + l, 0, naitiImage.Height - 1);
                    Color neighborColor = naitiImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255), Clamp((int)resultB, 0, 255));
        }
    }
}
