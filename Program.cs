using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graphDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomGeneration.Generator Generator = new RandomGeneration.Generator();
            System.Drawing.Bitmap Bitmap;
            for (int i = 0; i <= 10; i++)
            {
                Bitmap = Generator.ProductImage();
                Bitmap.Save("Z:\\Graphs\\Graph00"+i+".bmp");
            }
        }
    }
}
