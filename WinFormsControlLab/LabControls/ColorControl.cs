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
        private Color colorFromAgb;
        public Color ColorFromArgb 
        {
            get
            {
                return colorFromAgb;
            }
            set
            {
                colorFromAgb = value;
                int R = ColorFromArgb.R;
                int G = ColorFromArgb.G;
                int B = ColorFromArgb.B;
                colorTextBoxR.Text = R.ToString();
                colorTextBoxG.Text = G.ToString();
                colorTextBoxB.Text = B.ToString();
            }
        }
        public ColorControl()
        {
            InitializeComponent();           
        }
        public void ColorControlFromArgb()
        {
            ColorFromArgb = 
                Color.FromArgb(colorTextBoxR.Color, colorTextBoxG.Color, colorTextBoxB.Color);
        }
        private void colorTextBoxR_TextChanged(object sender, EventArgs e)
        {
            ColorControlFromArgb();
            pictureBox1.Invalidate();
        }
        private void colorTextBoxG_TextChanged(object sender, EventArgs e)
        {
            ColorControlFromArgb();
            pictureBox1.Invalidate();
        }
        private void colorTextBoxB_TextChanged(object sender, EventArgs e)
        {
            ColorControlFromArgb();
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(ColorFromArgb);
            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            e.Graphics.FillRectangle(blueBrush, rect);
        }     
    }
}
