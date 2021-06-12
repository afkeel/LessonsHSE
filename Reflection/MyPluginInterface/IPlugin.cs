using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPluginInterface
{
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        Bitmap Transform(Bitmap app);
    }
}
