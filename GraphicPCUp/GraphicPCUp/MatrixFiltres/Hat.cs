using System.ComponentModel;
using System.Drawing;
using Template;

namespace Hatiki
{
    class BlackHat : MatrixFilter
    {
        public BlackHat()
        {
            kernel = new float[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i, j] = 1;
        }

        //копируем Close
        public override Bitmap ProccesImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            if (sourceImage == null) return sourceImage;
            Bitmap secondImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap tmp = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    secondImage.SetPixel(i, j, Color.FromArgb(calculateNewPixelColor(sourceImage, i, j).R, calculateNewPixelColor(sourceImage, i, j).G, calculateNewPixelColor(sourceImage, i, j).B));
                }
            }
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    tmp.SetPixel(i, j, Color.FromArgb(255 - secondImage.GetPixel(i, j).R, 255 - secondImage.GetPixel(i, j).G, 255 - secondImage.GetPixel(i, j).B));
                }
            }
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    secondImage.SetPixel(i, j, Color.FromArgb(calculateNewPixelColor(tmp, i, j).R, calculateNewPixelColor(tmp, i, j).G, calculateNewPixelColor(tmp, i, j).B));
                }
                worker.ReportProgress((int)((float)i / secondImage.Width * 100));
                if (worker.CancellationPending) return null;
            }
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    secondImage.SetPixel(i, j, Color.FromArgb(255 - secondImage.GetPixel(i, j).R, 255 - secondImage.GetPixel(i, j).G, 255 - secondImage.GetPixel(i, j).B));
                }
            }

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, Color.FromArgb(Clamp(secondImage.GetPixel(i, j).R - sourceImage.GetPixel(i, j).R, 0, 255), Clamp(secondImage.GetPixel(i, j).G - sourceImage.GetPixel(i, j).G, 0, 255), Clamp(secondImage.GetPixel(i, j).B - sourceImage.GetPixel(i, j).B, 0, 255)));
                }
            }
            return resultImage;

        }
    }
    class TopHat : MatrixFilter
    {
        public TopHat()
        {
            kernel = new float[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i, j] = 1;
        }

        public override Bitmap ProccesImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            if (sourceImage == null) return sourceImage;
            Bitmap secondImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Bitmap tmp = new Bitmap(sourceImage.Width, sourceImage.Height);
            //сначала делаем инверсию
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    tmp.SetPixel(i, j, Color.FromArgb(255 - sourceImage.GetPixel(i, j).R, 255 - sourceImage.GetPixel(i, j).G, 255 - sourceImage.GetPixel(i, j).B));
                }
            }

            //наращивание
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    secondImage.SetPixel(i, j, Color.FromArgb(calculateNewPixelColor(tmp, i, j).R, calculateNewPixelColor(tmp, i, j).G, calculateNewPixelColor(tmp, i, j).B));
                }
            }

            //инверсия
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    secondImage.SetPixel(i, j, Color.FromArgb(255 - secondImage.GetPixel(i, j).R, 255 - secondImage.GetPixel(i, j).G, 255 - secondImage.GetPixel(i, j).B));
                }
            }

            //
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    tmp.SetPixel(i, j, Color.FromArgb(secondImage.GetPixel(i, j).R, secondImage.GetPixel(i, j).G, secondImage.GetPixel(i, j).B));
                }
            }
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    secondImage.SetPixel(i, j, Color.FromArgb(calculateNewPixelColor(tmp, i, j).R, calculateNewPixelColor(tmp, i, j).G, calculateNewPixelColor(tmp, i, j).B));
                }
                worker.ReportProgress((int)((float)i / secondImage.Width * 100));
                if (worker.CancellationPending) return null;
            }

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, Color.FromArgb(Clamp(sourceImage.GetPixel(i, j).R - secondImage.GetPixel(i, j).R, 0, 255), Clamp(sourceImage.GetPixel(i, j).G - secondImage.GetPixel(i, j).G, 0, 255), Clamp(sourceImage.GetPixel(i, j).B - secondImage.GetPixel(i, j).B, 0, 255)));
                }
            }
            return resultImage;

        }

    }
}
