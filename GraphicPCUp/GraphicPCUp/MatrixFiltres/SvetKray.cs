using System;
using System.Drawing;

namespace Cray
{
    class Canny_edge_detection
    {
        public Canny_edge_detection() { }

        public Bitmap edge_detection_by_Canny(Bitmap image)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            int[] threshold = new int[2] { 80, 2000 };

            int[,] gx = new int[,]
            {
              { -1, 0, 1 },
              { -2, 0, 2 },
              { -1, 0, 1 }
            };

            int[,] gy = new int[,]
            {
              { 1, 2, 1 },
              { 0, 0, 0 },
              { -1, -2, -1 }
            };

            Bitmap n = new Bitmap(image.Width, image.Height);

            int[,] allPixR = new int[image.Width, image.Height];
            int[,] allPixG = new int[image.Width, image.Height];
            int[,] allPixB = new int[image.Width, image.Height];

            for (int i = 0; i < image.Width; ++i)
            {
                for (int j = 0; j < image.Height; ++j)
                {
                    allPixR[i, j] = image.GetPixel(i, j).R;
                    allPixG[i, j] = image.GetPixel(i, j).G;
                    allPixB[i, j] = image.GetPixel(i, j).B;
                }
            }


            int[,] allPixRn = new int[image.Width, image.Height];
            int[,] allPixGn = new int[image.Width, image.Height];
            int[,] allPixBn = new int[image.Width, image.Height];


            int[,] graidientR = new int[image.Width, image.Height];
            int[,] graidientG = new int[image.Width, image.Height];
            int[,] graidientB = new int[image.Width, image.Height];

            int[,] tanR = new int[image.Width, image.Height];
            int[,] tanG = new int[image.Width, image.Height];
            int[,] tanB = new int[image.Width, image.Height];

            for (int i = 2; i < image.Width - 2; ++i)
            {
                for (int j = 2; j < image.Height - 2; ++j)
                {
                    int red = (
                              ((allPixR[i - 2, j - 2]) * 1 + (allPixR[i - 1, j - 2]) * 4 + (allPixR[i, j - 2]) * 7 + (allPixR[i + 1, j - 2]) * 4 + (allPixR[i + 2, j - 2])
                              + (allPixR[i - 2, j - 1]) * 4 + (allPixR[i - 1, j - 1]) * 16 + (allPixR[i, j - 1]) * 26 + (allPixR[i + 1, j - 1]) * 16 + (allPixR[i + 2, j - 1]) * 4
                              + (allPixR[i - 2, j]) * 7 + (allPixR[i - 1, j]) * 26 + (allPixR[i, j]) * 41 + (allPixR[i + 1, j]) * 26 + (allPixR[i + 2, j]) * 7
                              + (allPixR[i - 2, j + 1]) * 4 + (allPixR[i - 1, j + 1]) * 16 + (allPixR[i, j + 1]) * 26 + (allPixR[i + 1, j + 1]) * 16 + (allPixR[i + 2, j + 1]) * 4
                              + (allPixR[i - 2, j + 2]) * 1 + (allPixR[i - 1, j + 2]) * 4 + (allPixR[i, j + 2]) * 7 + (allPixR[i + 1, j + 2]) * 4 + (allPixR[i + 2, j + 2]) * 1) / 273
                              );

                    int green = (
                              ((allPixG[i - 2, j - 2]) * 1 + (allPixG[i - 1, j - 2]) * 4 + (allPixG[i, j - 2]) * 7 + (allPixG[i + 1, j - 2]) * 4 + (allPixG[i + 2, j - 2])
                              + (allPixG[i - 2, j - 1]) * 4 + (allPixG[i - 1, j - 1]) * 16 + (allPixG[i, j - 1]) * 26 + (allPixG[i + 1, j - 1]) * 16 + (allPixG[i + 2, j - 1]) * 4
                              + (allPixG[i - 2, j]) * 7 + (allPixG[i - 1, j]) * 26 + (allPixG[i, j]) * 41 + (allPixG[i + 1, j]) * 26 + (allPixG[i + 2, j]) * 7
                              + (allPixG[i - 2, j + 1]) * 4 + (allPixG[i - 1, j + 1]) * 16 + (allPixG[i, j + 1]) * 26 + (allPixG[i + 1, j + 1]) * 16 + (allPixG[i + 2, j + 1]) * 4
                              + (allPixG[i - 2, j + 2]) * 1 + (allPixG[i - 1, j + 2]) * 4 + (allPixG[i, j + 2]) * 7 + (allPixG[i + 1, j + 2]) * 4 + (allPixG[i + 2, j + 2]) * 1) / 273
                              );

                    int blue = (
                              ((allPixB[i - 2, j - 2]) * 1 + (allPixB[i - 1, j - 2]) * 4 + (allPixB[i, j - 2]) * 7 + (allPixB[i + 1, j - 2]) * 4 + (allPixB[i + 2, j - 2])
                              + (allPixB[i - 2, j - 1]) * 4 + (allPixB[i - 1, j - 1]) * 16 + (allPixB[i, j - 1]) * 26 + (allPixB[i + 1, j - 1]) * 16 + (allPixB[i + 2, j - 1]) * 4
                              + (allPixB[i - 2, j]) * 7 + (allPixB[i - 1, j]) * 26 + (allPixB[i, j]) * 41 + (allPixB[i + 1, j]) * 26 + (allPixB[i + 2, j]) * 7
                              + (allPixB[i - 2, j + 1]) * 4 + (allPixB[i - 1, j + 1]) * 16 + (allPixB[i, j + 1]) * 26 + (allPixB[i + 1, j + 1]) * 16 + (allPixB[i + 2, j + 1]) * 4
                              + (allPixB[i - 2, j + 2]) * 1 + (allPixB[i - 1, j + 2]) * 4 + (allPixB[i, j + 2]) * 7 + (allPixB[i + 1, j + 2]) * 4 + (allPixB[i + 2, j + 2]) * 1) / 273
                              );

                    n.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }


            for (int i = 0; i < image.Width; ++i)
            {
                for (int j = 0; j < image.Height; ++j)
                {
                    allPixRn[i, j] = n.GetPixel(i, j).R;
                    allPixGn[i, j] = n.GetPixel(i, j).G;
                    allPixBn[i, j] = n.GetPixel(i, j).B;
                }
            }

            int new_rx, new_ry;
            int new_gx, new_gy;
            int new_bx, new_by;

            int rColor;
            int gColor;
            int bColor;

            for (int i = 1; i < image.Width - 1; ++i)
            {
                for (int j = 1; j < image.Height - 1; ++j)
                {
                    new_rx = 0; new_ry = 0;
                    new_gx = 0; new_gy = 0;
                    new_bx = 0; new_by = 0;

                    rColor = 0;
                    gColor = 0;
                    bColor = 0;

                    for (int kernel_x = -1; kernel_x < 2; ++kernel_x)
                    {
                        for (int kernel_y = -1; kernel_y < 2; ++kernel_y)
                        {
                            rColor = allPixRn[i + kernel_x, j + kernel_y];
                            new_rx += gx[kernel_x + 1, kernel_y + 1] * rColor;
                            new_ry += gx[kernel_x + 1, kernel_y + 1] * rColor;

                            gColor = allPixGn[i + kernel_x, j + kernel_y];
                            new_gx += gx[kernel_x + 1, kernel_y + 1] * gColor;
                            new_gy += gx[kernel_x + 1, kernel_y + 1] * gColor;

                            bColor = allPixBn[i + kernel_x, j + kernel_y];
                            new_bx += gx[kernel_x + 1, kernel_y + 1] * bColor;
                            new_by += gx[kernel_x + 1, kernel_y + 1] * bColor;
                        }

                        graidientR[i, j] = (int)Math.Sqrt((new_rx * new_rx) + (new_ry * new_ry));
                        graidientG[i, j] = (int)Math.Sqrt((new_gx * new_gx) + (new_gy * new_gy));
                        graidientB[i, j] = (int)Math.Sqrt((new_bx * new_bx) + (new_by * new_by));

                        tang_cal((int)((Math.Atan((double)new_ry / new_rx)) * (180 / Math.PI)), tanR, i, j);
                        tang_cal((int)((Math.Atan((double)new_ry / new_rx)) * (180 / Math.PI)), tanG, i, j);
                        tang_cal((int)((Math.Atan((double)new_ry / new_rx)) * (180 / Math.PI)), tanB, i, j);
                    }
                }
            }


            int[,] allPixRs = new int[image.Width, image.Height];
            int[,] allPixGs = new int[image.Width, image.Height];
            int[,] allPixBs = new int[image.Width, image.Height];

            for (int i = 1; i < image.Width - 1; ++i)
            {
                for (int j = 1; j < image.Height - 1; ++j)
                {
                    lower_bound_cut_off_suppression(allPixRs, graidientR, tanR, i, j);
                    lower_bound_cut_off_suppression(allPixGs, graidientG, tanG, i, j);
                    lower_bound_cut_off_suppression(allPixBs, graidientB, tanB, i, j);
                }
            }

            int[,] allPixRf = new int[image.Width, image.Height];
            int[,] allPixGf = new int[image.Width, image.Height];
            int[,] allPixBf = new int[image.Width, image.Height];

            for (int i = 1; i < image.Width - 1; ++i)
            {
                for (int j = 1; j < image.Height - 1; ++j)
                {
                    if (allPixRs[i, j] > threshold[0] && allPixRs[i, j] < threshold[1])
                    {
                        allPixRf[i, j] = 1;
                    }
                    else
                    {
                        allPixRf[i, j] = 0;
                    }

                    if (allPixGs[i, j] > threshold[0] && allPixGs[i, j] < threshold[1])
                    {
                        allPixGf[i, j] = 1;
                    }
                    else
                    {
                        allPixGf[i, j] = 0;
                    }

                    if (allPixBs[i, j] > threshold[0] && allPixBs[i, j] < threshold[1])
                    {
                        allPixBf[i, j] = 1;
                    }
                    else
                    {
                        allPixBf[i, j] = 0;
                    }

                    if (allPixRf[i, j] == 1 || allPixGf[i, j] == 1 || allPixBf[i, j] == 1)
                    {
                        newImage.SetPixel(i, j, Color.Black);
                    }
                }
            }

            return newImage;
        }

        public void tang_cal(int atang, int[,] tang, int i, int j)
        {
            if ((atang > 0 && atang < 22.5) || (atang > 157.5 && atang < 180))
            {
                atang = 0;
                tang[i, j] = 0;
            }
            else if (atang > 22.5 && atang < 67.5)
            {
                atang = 45;
                tang[i, j] = 1;
            }
            else if (atang > 67.5 && atang < 112.5)
            {
                atang = 90;
                tang[i, j] = 2;
            }
            else if (atang > 112.5 && atang < 157.5)
            {
                atang = 135;
                tang[i, j] = 3;
            }
        }

        public void lower_bound_cut_off_suppression(int[,] all, int[,] grad, int[,] tang, int i, int j)
        {
            if (tang[i, j] == 0)
            {
                if (grad[i - 1, j] < grad[i, j] && grad[i + 1, j] < grad[i, j])
                {
                    all[i, j] = grad[i, j];
                }
                else
                {
                    all[i, j] = 0;
                }
            }

            if (tang[i, j] == 1)
            {
                if (grad[i - 1, j + 1] < grad[i, j] && grad[i + 1, j - 1] < grad[i, j])
                {
                    all[i, j] = grad[i, j];
                }
                else
                {
                    all[i, j] = 0;
                }
            }

            if (tang[i, j] == 2)
            {
                if (grad[i, j - 1] < grad[i, j] && grad[i, j + 1] < grad[i, j])
                {
                    all[i, j] = grad[i, j];
                }
                else
                {
                    all[i, j] = 0;
                }
            }

            if (tang[i, j] == 3)
            {
                if (grad[i - 1, j - 1] < grad[i, j] && grad[i + 1, j + 1] < grad[i, j])
                {
                    all[i, j] = grad[i, j];
                }
                else
                {
                    all[i, j] = 0;
                }
            }
        }
    }
}
