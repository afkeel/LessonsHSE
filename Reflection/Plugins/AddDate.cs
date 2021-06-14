using MyPluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    class AddDate : IPlugin
    {
        public string Name
        {
            get
            {
                return "Add date";
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
            string str = DateTime.Now.ToShortDateString();
            Graphics gr = Graphics.FromImage(bitmap);
            gr.DrawString(str,
            new Font("Arial", 13, FontStyle.Bold),
            new SolidBrush(Color.Red), bitmap.Width-100, bitmap.Height-30);
            return bitmap;
        }
    }
}
