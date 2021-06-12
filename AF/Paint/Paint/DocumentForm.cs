using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class DocumentForm : Form
    {
        private int x, y;
        /// <summary>
        /// Битовая карта
        /// </summary>
        /// 
        private Bitmap bmp;
        private Bitmap bmpTemp;
        public DocumentForm()
        {
            InitializeComponent();
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            pictureBox1.Image = bmp;
        }
        public DocumentForm(Bitmap bmp)
        {
            InitializeComponent();
            this.bmp = bmp;
        }
        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var g = Graphics.FromImage(bmp);
                var pen = new Pen(MainForm.CurrentColor);
                switch (MainForm.CurrentTool)
                {
                    case Tools.Pen:
                        g.DrawLine(pen, x, y, e.X, e.Y);
                        x = e.X;
                        y = e.Y;
                        break;
                    case Tools.Circle:
                        bmpTemp = (Bitmap)bmp.Clone();
                        g = Graphics.FromImage(bmpTemp);
                        g.DrawEllipse(pen, new Rectangle(x,y, e.X-x,e.Y-y));
                        pictureBox1.Image = bmpTemp;                      
                        break;
                    default:
                        break;
                }                
                
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
        private void DocumentForm_MouseUp(object sender, MouseEventArgs e)
        {
            switch (MainForm.CurrentTool)
            {
                case Tools.Circle:
                    bmp = bmpTemp;
                    break;
            }
        }
        public void SaveAs(string path)
        {
            bmp.Save(path);
        }

    }
    
}
