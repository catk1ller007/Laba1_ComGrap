using System;
using System.Drawing;
using Template;

namespace Preference
{
    class ReferenceCorrection : Filtres
    {
        Color src, dst;

        public ReferenceCorrection(Color dest, Color reference)
        {
            src = reference;
            dst = dest;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            Color sourceColor = sourceImage.GetPixel(i, j);

            double ColorR = (double)sourceColor.R * (double)dst.R / (double)src.R;
            double ColorG = (double)sourceColor.G * (double)dst.G / (double)src.G;
            double ColorB = (double)sourceColor.B * (double)dst.B / (double)src.B;

            return Color.FromArgb(Clamp((int)ColorR, 0, 255), Clamp((int)ColorG, 0, 255), Clamp((int)ColorB, 0, 255));
        }
    }
}
