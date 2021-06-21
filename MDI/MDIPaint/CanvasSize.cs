using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{    
    public partial class CanvasSize : Form
    {
        public string TextBoxWidth
        {
            get
            {
               return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        public string TextBoxHeight
        {
            get
            {
                return textBox2.Text;
            }
            set
            {
                textBox2.Text = value;
            }
        }
        public CanvasSize()
        {
            InitializeComponent();
        }
    }
}
