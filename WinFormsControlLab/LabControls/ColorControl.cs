using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabControls
{
    public partial class ColorControl : UserControl
    {
        public Color ColorFromArgb { get; set; }
        public ColorControl()
        {
            InitializeComponent();
        }
        public void ColorControlFromArgb()
        {
            ColorFromArgb = 
                Color.FromArgb(colorTextBoxRed.Color, colorTextBoxGreen.Color, colorTextBoxBlue.Color);
        }
        private void colorTextBoxRed_TextChanged(object sender, EventArgs e)
        {
            ColorControlFromArgb();
        }

        private void colorTextBoxGreen_TextChanged(object sender, EventArgs e)
        {
            ColorControlFromArgb();
        }
        private void colorTextBoxBlue_TextChanged(object sender, EventArgs e)
        {
            ColorControlFromArgb();
        }
    }
}
