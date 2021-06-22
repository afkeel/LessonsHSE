using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIPaint
{
    public partial class Canvas : Form
    {
        private Bitmap bmp;
        private int oldX, oldY;
        public int PictureBox1Width
        {
            get
            {
                return pictureBox1.Width;
            }
        }
        public int PictureBox1Height
        {
            get
            {
                return pictureBox1.Height;
            }
        }
        public Canvas()
        {
            InitializeComponent();
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            pictureBox1.Image = bmp;       
        }        
        public Canvas(string FileName)
        {
            InitializeComponent();
            bmp = new Bitmap(FileName);            
            pictureBox1.Width = bmp.Width;
            pictureBox1.Height = bmp.Height;
            pictureBox1.Image = bmp;
        }
        public void Save(string fp)
        {
            var newBitmap = new Bitmap(bmp);
            bmp.Dispose();
            newBitmap.Save(fp);
            bmp = newBitmap;
        }        
        public string SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg";
            ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(dlg.FileName, ff[dlg.FilterIndex - 1]);
            }
            return dlg.FileName;
        }
        public int CanvasWidth
        {
            get
            {
                return pictureBox1.Width;
            }
            set
            {
                pictureBox1.Width = value;
                Bitmap tbmp = new Bitmap(value, pictureBox1.Width);
                Graphics g = Graphics.FromImage(tbmp);
                g.Clear(Color.White);
                g.DrawImage(bmp, new Point(0, 0));
                bmp = tbmp;
                pictureBox1.Image = bmp;
            }
        }
        public int CanvasHeight
        {
            get
            {
                return pictureBox1.Height;
            }
            set
            {
                pictureBox1.Height = value;
                Bitmap tbmp = new Bitmap(pictureBox1.Width, value);
                Graphics g = Graphics.FromImage(tbmp);
                g.Clear(Color.White);
                g.DrawImage(bmp, new Point(0, 0));
                bmp = tbmp;
                pictureBox1.Image = bmp;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Graphics g = Graphics.FromImage(bmp);
                    //Graphics g = pictureBox1.CreateGraphics();
                    g.DrawLine(new Pen(MainForm.CurColor, MainForm.CurWidth), oldX, oldY, e.X, e.Y);
                    oldX = e.X;
                    oldY = e.Y;
                    pictureBox1.Invalidate();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            oldX = e.X;
            oldY = e.Y;
        } 
    }
}
