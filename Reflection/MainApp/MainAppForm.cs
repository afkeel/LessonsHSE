using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyPluginInterface;

namespace MainApp
{
    public partial class MainAppForm : Form
    {
        private Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        public MainAppForm()
        {
            InitializeComponent();
            FindPlugins();
            CreatePluginsMenu();
        }
        void FindPlugins()
        {
            // папка с плагинами
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;
            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("MyPluginInterface.IPlugin");
                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }
        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
            pictureBox1.Image = plugin.Transform((Bitmap)pictureBox1.Image);

            VersionAttribute atr = 
                (VersionAttribute)Attribute.GetCustomAttribute(plugin.GetType(), typeof(VersionAttribute));
            string atrStr = "Version: 1.0";
            if (atr!=null)
            {
                atrStr = $"Version: {atr.Major}.{atr.Minor}";
            }
            label1.Text = $"Name: {plugin.Name}, Author: {plugin.Author}, {atrStr}";            
        }
        private void CreatePluginsMenu()
        {
            foreach (var p in plugins)
            {
                var item = filtersToolStripMenuItem.DropDownItems.Add(p.Value.Name);
                item.Click += OnPluginClick;
            }
        }
    }
}
