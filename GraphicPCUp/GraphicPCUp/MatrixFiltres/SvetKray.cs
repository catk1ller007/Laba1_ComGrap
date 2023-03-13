using System;
using System.Drawing;
using Template;
using Sobel;
using System.ComponentModel;

namespace Cray
{

    class BrightBorders : MatrixFilter
    {
        // MEDIAN
        protected Color NewPixelColor1(Bitmap sourceImage, int x, int y)
        {
            int count = 0;
            int size = 3;
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


        // SOBEL
        private static double[,] xSobel
        {
            get
            {
                return new double[,]
                {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
                };
            }
        }
        private static double[,] ySobel
        {
            get
            {
                return new double[,]
                {
            {  1,  2,  1 },
            {  0,  0,  0 },
            { -1, -2, -1 }
                };
            }
        }

        protected Color NewPixelColor2(Bitmap sourceImage, int x, int y)
        {

            int size = 3;
            kernel = new float[size, size]; //Не используется сетка по умолчанию, потому что алгоритм Собеля использует сразу две штуки
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            double XresR = 0, XresG = 0, XresB = 0, YresR = 0, YresG = 0, YresB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    XresR += neighborColor.R * xSobel[k + radiusX, l + radiusY];
                    XresG += neighborColor.G * xSobel[k + radiusX, l + radiusY];
                    XresB += neighborColor.B * xSobel[k + radiusX, l + radiusY];
                    YresR += neighborColor.R * ySobel[k + radiusX, l + radiusY];
                    YresG += neighborColor.G * ySobel[k + radiusX, l + radiusY];
                    YresB += neighborColor.B * ySobel[k + radiusX, l + radiusY];

                }

            int resultR, resultG, resultB;
            resultR = Clamp((int)Math.Sqrt(XresR * XresR + YresR * YresR), 0, 255);
            resultG = Clamp((int)Math.Sqrt(XresG * XresG + YresG * YresG), 0, 255);
            resultB = Clamp((int)Math.Sqrt(XresB * XresB + YresB * YresB), 0, 255);
            return Color.FromArgb(resultR, resultG, resultB);
        }


        // MAX
        protected Color NewPixelColor3(Bitmap sourceImage, int x, int y)
        {
            int count = 0;
            int size = 3;
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
            resultR = FindMaxValue(arrayR, count);
            resultG = FindMaxValue(arrayG, count);
            resultB = FindMaxValue(arrayB, count);

            return Color.FromArgb(resultR, resultG, resultB);
        }

        int FindMaxValue(int[] arr, int count)
        {
            Array.Sort(arr);
            return arr[count - 1];
        }

        public override Bitmap ProccesImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap resultImage2 = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap resultImage3 = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < resultImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 33));
                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < resultImage.Height; j++)
                {
                    resultImage3.SetPixel(i, j, NewPixelColor1(sourceImage, i, j));
                }
            }

            for (int i = 0; i < resultImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 33) + 33);
                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < resultImage.Height; j++)
                {
                    resultImage2.SetPixel(i, j, NewPixelColor2(resultImage3, i, j));
                }
            }

            for (int i = 0; i < resultImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 34) + 67);
                if (worker.CancellationPending)
                    return null;

                for (int j = 0; j < resultImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, NewPixelColor3(resultImage2, i, j));
                }
            }
            return resultImage;
        }

    }
}
