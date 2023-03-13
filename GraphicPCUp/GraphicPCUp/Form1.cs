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
using Motion;
using Sobel;
using Erosia;
using Dilat;
using Priwit;
using Shara;
using Cray;
using Tisnenie;
using Lin;
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
        private void стеклоToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filtres filter = new Steklo();
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
        private void переносToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new transfer();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void поворотToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new turn();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        //-------------------- Матричные фильтры ----------------------//
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
        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Rezkost();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new MotionBlur();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void приToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new PrewittFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void щараToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new SharaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void светКрайToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filtres = new BrightBorders();
            backgroundWorker1.RunWorkerAsync(filtres);
        }
        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Embossing();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        //-------------------- Глобальные фильтры ----------------------//
        private void глобальноеРастяжениеГистограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new LinearStretching();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        //-------------------- Мат морфология фильтр ----------------------//
        private void dilatonToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filtres filter = new MorphologicalDilationFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void erosionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filtres filter = new MorphologicalErosionFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new MorphologicalOpeningFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new MorphologicalClosingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void topHatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new MorphologicalTopHatFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void blackHatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new MorphologicalBlackHatFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new MorphologicalGradFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        

        // -------------------------Кнопки-------------------------//
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
    }
}
