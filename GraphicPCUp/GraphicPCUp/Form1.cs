using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using LabaOneGraphics;
using Template;
using Invert;
using Sepi; 
using BLM;
using EvYya;
using LowYa;
using stek;
using Horizont;
using Vertical;
using Trans;
using Trasform;
using Blur;
using Gays;
using Sharpness;

namespace GraphicPCUp
{
    public partial class Form1 : Form
    {

        Bitmap imageOriginal;
        Bitmap imageResult;

        public Form1()
        {
            InitializeComponent();
        }


        // --------------------------------- Файл -----------------------------------------//
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image files| *.png; *.jpg; *.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageOriginal = new Bitmap(dialog.FileName);
                imageResult = imageOriginal;
            }

            pictureBox1.Image = imageOriginal;
            pictureBox1.Refresh();
        }
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageResult == null) return;

            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Images|*.png;*.bmp;*.jpg";

            ImageFormat format = ImageFormat.Png;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(dialog.FileName);

                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }

                pictureBox2.Image.Save(dialog.FileName, format);
            }
        }

        // ----------------------------- Шкала выполнения ---------------------------------//
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filtres)e.Argument).ProccesImage(imageResult, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                imageResult = newImage;
            }
        }
        private void Отмена_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox2.Image = imageResult;
                pictureBox2.Refresh();
            }
            progressBar1.Value = 0;
        }

        // ------------------------------------------------------------------------------// 
        // ---------------------------------- Фильтры -----------------------------------//
        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            //Bitmap imageResult = filter.ProccesImage(imageOriginal);
            //pictureBox2.Image = imageResult;
            //pictureBox2.Refresh();
        }
        private void черноБелоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Black_White();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void гауссToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void увеличениеЯркостиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new YvelichenitYarkosti();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void уменьшениеЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new YemshenitYarkosti();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Rezkost();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void вертикальныеВолныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new VerticalWaveFilter(imageResult, 10, (float)2);
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void горизонтальныеВолныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new HorizontalWaveFilter(imageResult, 10, (float)2);
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void глобальноеРастяжениеГистограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap sourceImage = imageOriginal;

            int srcColorminR = 255;
            int srcColormaxR = 0;
            int srcColorminG = 255;
            int srcColormaxG = 0;
            int srcColorminB = 255;
            int srcColormaxB = 0;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    if ((sourceImage.GetPixel(i, j).R) > srcColormaxR)
                        srcColormaxR = sourceImage.GetPixel(i, j).R;
                    if ((sourceImage.GetPixel(i, j).G) > srcColormaxG)
                        srcColormaxG = sourceImage.GetPixel(i, j).G;
                    if ((sourceImage.GetPixel(i, j).B) > srcColormaxB)
                        srcColormaxB = sourceImage.GetPixel(i, j).B;

                    if ((sourceImage.GetPixel(i, j).R) < srcColorminR)
                        srcColorminR = sourceImage.GetPixel(i, j).R;
                    if ((sourceImage.GetPixel(i, j).G) < srcColorminG)
                        srcColorminG = sourceImage.GetPixel(i, j).G;
                    if ((sourceImage.GetPixel(i, j).B) < srcColorminB)
                        srcColorminB = sourceImage.GetPixel(i, j).B;
                }
            }

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, globalCalculateNewPixelColor(sourceImage, i, j, srcColorminR, srcColormaxR, srcColorminG, srcColormaxG, srcColorminB, srcColormaxB));
                }
            }

            pictureBox2.Image = resultImage;
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }
        private void стеклоToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filtres filter = new Steklo();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void переносToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new transfer();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new MotionBlur();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void dilatonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Dilaton();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        // Очистка
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            imageResult = imageOriginal;
        }
       
        // Поменять местами
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageResult;
            pictureBox2.Image = null; 
        }

        // - Линейное растяжение гистограммы
        public Color globalCalculateNewPixelColor(Bitmap sourceImage, int x, int y, int srcColorminR, int srcColormaxR, int srcColorminG, int srcColormaxG, int srcColorminB, int srcColormaxB)
        {
            Color srcColor = sourceImage.GetPixel(x, y);

            int srcColorR = (255 * (srcColor.R - srcColorminR) / (srcColormaxR - srcColorminR + 1)) % 255;
            int srcColorG = (255 * (srcColor.G - srcColorminG) / (srcColormaxG - srcColorminG + 1)) % 255;
            int srcColorB = (255 * (srcColor.B - srcColorminB) / (srcColormaxB - srcColorminB + 1)) % 255;

            return Color.FromArgb(srcColorR, srcColorG, srcColorB);
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Erosion();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new turn(imageResult,0,0); 
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}




namespace LabaOneGraphics
{
    class SobelFilter : MatrixFilter
    {
        public void SobelX()
        {
            int sizeX = 3;
            int sizeY = 3;
            int[,] kernelX = new int[3, 3] {
            {-1,0,1},
            {-2,0,2},
            {-1,0,1},
            };

            int[,] kernelY = new int[3, 3] {
            {-1,-2,-1},
            {0,0,0},
            {1,2,1},
            };
        }

    }
    class MotionBlur : MatrixFilter
    {
        public MotionBlur()
        {
            int sizeX = 100;
            int sizeY = 100;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i == j)
                    {
                        kernel[i, j] = 1 / sizeX;
                    }
                    else { kernel[i, j] = 0; }
                }
            }
        }
        //public MotionBlur()
        //{
        //    int sizeX = 100;
        //    int sizeY = 100;
        //    kernel = new float[sizeX, sizeY];
        //    for (int i = 0; i < sizeX; i++){
        //        for (int j = 0; j < sizeY; j++)
        //        {
        //            if (i == j)
        //            {
        //                kernel[i, j] = 1 / sizeX;
        //            }
        //        }
        //    }
        //}

    }
    abstract class MorphologiFilters : MatrixFilter
        {
            protected int size = 3;
            protected int rad = 1;
            protected Color white = Color.FromArgb(255, 255, 255);
            protected Color black = Color.FromArgb(0, 0, 0);

            protected int[,] kernel = new int[3, 3] {
            {1,1,1},
            {1,1,1},
            {1,1,1},
            };

            protected MorphologiFilters() { }
            public MorphologiFilters(int[,] kernel)
            {
                this.kernel = kernel;
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

            abstract protected bool getCond(Bitmap sourceImage, int i, int j);
            abstract protected void setPixels(Bitmap sourceImage, Bitmap resultImage, int i, int j);
            abstract protected Bitmap setStartImage(Bitmap sourceImage);

            public Bitmap ProcessImage(Bitmap sourceImage, BackgroundWorker worker)
            {
                Bitmap resultImage = new Bitmap(setStartImage(sourceImage));

                for (int i = rad; i < sourceImage.Width - rad; i++)
                {
                    for (int j = rad; j < sourceImage.Height - rad; j++)
                    {
                        worker.ReportProgress((int)((float)i / resultImage.Width + 100));

                        if (worker.CancellationPending)
                        {
                            return null;
                        }
                        if (getCond(sourceImage, i, j))
                        {
                            setPixels(sourceImage, resultImage, i, j);
                        }
                    }
                }
                return resultImage;
            }

        }
    class Dilaton : MorphologiFilters
        {
            public Dilaton()
            {

            }

            protected override Bitmap setStartImage(Bitmap sourceImage)
            {
                return sourceImage;
            }

            protected override bool getCond(Bitmap sourceImage, int i, int j)
            {
                bool cond = false;
                if (sourceImage.GetPixel(i, j).R == 255)
                {
                    cond = true;
                }
                return cond;
            }

            protected override void setPixels(Bitmap sourceImage, Bitmap resultImage, int i, int j)
            {
                for (int k = i - rad; k < i + rad + 1; k++)
                {
                    for (int l = i - rad; l < i + rad + 1; l++)
                    {
                        resultImage.SetPixel(k, l, white);
                    }
                }
            }


        }
    class Erosion : MorphologiFilters
        {
            public Erosion()
            {

            }

            protected override Bitmap setStartImage(Bitmap sourceImage)
            {
                Bitmap newImage = new Bitmap(sourceImage.Height, sourceImage.Width);
                for (int i = 0; i < sourceImage.Width; i++)
                {
                    for (int j = 0; j < sourceImage.Height; j++)
                    {
                        newImage.SetPixel(i, j, black);
                    }
                }
                return newImage;
            }

            protected override bool getCond(Bitmap sourceImage, int i, int j)
            {
                bool cond = true;

                for (int k = i - rad; k < i + rad + 1; k++)
                {
                    for (int l = j - rad; l < j + rad + 1; l++)
                    {
                        if ((sourceImage.GetPixel(k, l).R == 255 && kernel[k - i + rad, j - i + rad] == 1) || (sourceImage.GetPixel(k, l).R == 0 && kernel[k - i + rad, j - i + rad] == 0))
                        {

                        }
                        else
                        {
                            cond = false;
                            break;
                        }
                    }
                    if (!cond)
                    {
                        break;
                    }
                }
                return cond;
            }

            protected override void setPixels(Bitmap sourceImage, Bitmap resultImage, int i, int j)
            {
                resultImage.SetPixel(i, j, white);
            }
            protected override Color calculateNewPixelColor(Bitmap naitiImage, int x, int y)
            {
                return naitiImage.GetPixel(x, y);
            }
        }
}




//public int koef = 30;
//protected override Color calculateNewPixelColor(Bitmap srcImage, int x, int y)
//{
//    int newX = Clamp(x + (int)(srcImage.Width * koef / 100), 0, srcImage.Width - 1);
//    int newY = y;
//    return srcImage.GetPixel(newX, newY);
//}
//protected override Color calculateNewPixelColor(Bitmap sourceColor, int x, int y)
//{
//    int newX = x + 100;
//    //newX = Clamp(newX, 0, sourceColor.Width - 1);
//    if (newX > sourceColor.Width - 100)
//    {
//        return Color.FromArgb(190, 190, 190);
//    }
//    return sourceColor.GetPixel(newX, y);
//}