using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //button1.Click +=
            //    delegate (object sender, EventArgs e)
            //    {
            //        MessageBox.Show("!");
            //    };
            var msg = "Test";
            button1.Click += (sender, e)=>MessageBox.Show(msg);

        }
    }
}
