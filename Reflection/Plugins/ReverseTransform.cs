using MyPluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    [Version(1, 1)]
    public class ReverseTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Reverse image";
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
            for (int i = 0; i < bitmap.Width; ++i)
                for (int j = 0; j < bitmap.Height / 2; ++j)
                {
                    Color color = bitmap.GetPixel(i, j);
                    bitmap.SetPixel(i, j, bitmap.GetPixel(i, bitmap.Height - j - 1));
                    bitmap.SetPixel(i, bitmap.Height - j - 1, color);
                }
            return bitmap;
        }        
    }
}
