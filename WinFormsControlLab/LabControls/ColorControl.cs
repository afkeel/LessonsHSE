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
        private void colorTextBoxR_TextChanged(object sender, EventArgs e)
        {            
            pictureBox1.Invalidate();
        }
        private void colorTextBoxG_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void colorTextBoxB_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void ColorConvertRGB(out int r, out int g, out int b)
        {
            r = Convert.ToInt32(colorTextBoxR.Color, colorTextBoxR.radioButton);
            g = Convert.ToInt32(colorTextBoxG.Color, colorTextBoxG.radioButton);
            b = Convert.ToInt32(colorTextBoxB.Color, colorTextBoxB.radioButton);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ColorConvertRGB(out int R, out int G, out int B);
            SolidBrush blueBrush =
                new SolidBrush(Color.FromArgb(R,G,B));
            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            e.Graphics.FillRectangle(blueBrush, rect);
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            ColorConvertRGB(out int R, out int G, out int B);
            colorTextBoxR.radioButton = 10;
            colorTextBoxB.radioButton = 10;
            colorTextBoxG.radioButton = 10;
            colorTextBoxR.Text = R.ToString();
            colorTextBoxG.Text = G.ToString();
            colorTextBoxB.Text = B.ToString();
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            colorTextBoxR.radioButton = 16;
            colorTextBoxB.radioButton = 16;
            colorTextBoxG.radioButton = 16;
            colorTextBoxR.Text = string.Format("{0:X}", int.Parse(colorTextBoxR.Color));
            colorTextBoxG.Text = string.Format("{0:X}", int.Parse(colorTextBoxG.Color));
            colorTextBoxB.Text = string.Format("{0:X}", int.Parse(colorTextBoxB.Color));
        }
    }
}
