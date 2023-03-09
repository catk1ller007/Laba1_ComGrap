using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace Motion
{
    class MotionBlur : MatrixFilter
    {
        public void motion(int k)
        {
            int i = 2 * k - 1;

            if (i > 5)
                i = 5;
            else if (i < 0)
                i = 5;

            if (i != 0)
            {
                kernel = new float[i, i];

                for (int e = 0; e < i; ++e)
                {
                    for (int j = 0; j < i; ++j)
                    {
                        if (e == j)
                        {
                            kernel[e, j] = (float)(1.0 / i);
                        }
                        else
                        {
                            kernel[k, j] = 0;
                        }
                    }
                }
            }
        }
        public MotionBlur()
        {
            motion(4);
        }
    }
}
