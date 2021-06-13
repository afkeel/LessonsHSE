using MyPluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    class ColorToGray : IPlugin
    {
        public string Name
        {
            get
            {
                return "Color to gray image";
            }
        }
        public string Author
        {
            get
            {
                return "AFKeel";
            }
        }
        public Bitmap Transform(Bitmap bitmap)
        {
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;
                    int avg = (r + g + b) / 3;
                    newBitmap.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                }
            }
            return newBitmap;
        }
    }
}
