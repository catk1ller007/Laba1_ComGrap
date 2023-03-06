using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace Sharpness
{ 
    class Rezkost : MatrixFilter
    {
        public Rezkost()
        {
            const int sizeX = 3;
            const int sizeY = 3;
            kernel = new float[sizeX, sizeY] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };

        }
    }
}
