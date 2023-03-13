using System;
using System.Drawing;
using System.ComponentModel;


namespace Template
{
    abstract class Filtres
    {
        protected abstract Color calculateNewPixelColor(Bitmap naitiImage, int x, int y);
        public virtual Bitmap ProccesImage(Bitmap naitiImage, BackgroundWorker worker)
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

        /// <summary>
        /// Возвращает максимальную яркость по каждому каналу
        /// </summary>
        public void GetMax(Bitmap sourceImage, out int R, out int G, out int B, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            R = G = B = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((double)i / sourceImage.Width * MaxPercent) + add);
                if (worker.CancellationPending)
                    return;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    R = Math.Max(R, color.R);
                    G = Math.Max(G, color.G);
                    B = Math.Max(B, color.B);
                }
            }
        }

        /// <summary>
        /// Возвращает минимальную яркость по каждому каналу
        /// </summary>
        public void GetMin(Bitmap sourceImage, out int R, out int G, out int B, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            R = G = B = 255;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((double)i / sourceImage.Width * MaxPercent) + add);
                if (worker.CancellationPending)
                    return;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color color = sourceImage.GetPixel(i, j);
                    R = Math.Min(R, color.R);
                    G = Math.Min(G, color.G);
                    B = Math.Min(B, color.B);
                }
            }
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
    class MedianFilter : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int count = 0;
            int size = 7;
            kernel = new float[size, size];
            int[] arrayR = new int[size * size];
            int[] arrayG = new int[size * size];
            int[] arrayB = new int[size * size];

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            int resultR = 0;
            int resultG = 0;
            int resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    arrayR[count] = neighborColor.R;
                    arrayG[count] = neighborColor.G;
                    arrayB[count] = neighborColor.B;
                    count++;
                }
            resultR = FindMedianValue(arrayR, count);
            resultG = FindMedianValue(arrayG, count);
            resultB = FindMedianValue(arrayB, count);

            return Color.FromArgb(resultR, resultG, resultB);
        }

        int FindMedianValue(int[] arr, int count)
        {
            Array.Sort(arr);
            return arr[(int)(count / 2)];
        }
    }
    class MaxFilter : MatrixFilter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int count = 0;
            int size = 5;
            kernel = new float[size, size];
            int[] arrayR = new int[size * size];
            int[] arrayG = new int[size * size];
            int[] arrayB = new int[size * size];

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            int resultR = 0;
            int resultG = 0;
            int resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    arrayR[count] = neighborColor.R;
                    arrayG[count] = neighborColor.G;
                    arrayB[count] = neighborColor.B;
                    count++;
                }
            resultR = FindMaxnValue(arrayR, count);
            resultG = FindMaxnValue(arrayG, count);
            resultB = FindMaxnValue(arrayB, count);

            return Color.FromArgb(resultR, resultG, resultB);
        }
        int FindMaxnValue(int[] arr, int count)
        {
            Array.Sort(arr);
            return arr[count - 1];
        }
    }
    class MorphologicalFilters : Filtres
    {
        protected double[,] structuring_element = null;
        protected int n;
        protected int m;

        public MorphologicalFilters()
        {
            structuring_element = new double[,] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 } };
            n = structuring_element.GetLength(0) / 2;
            m = structuring_element.GetLength(1) / 2;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return Color.FromArgb(0, 0, 0);
        }
    }
}
