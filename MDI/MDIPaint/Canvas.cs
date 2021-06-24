using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        private string pathFileName;
        private bool canvasChanged = false;
        public string PathFileName
        {
            set
            {
                pathFileName = value;
            }
        }
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
            using (var fs = new FileStream(FileName, FileMode.Open))
            {
                try
                {
                    var tbmp = new Bitmap(fs);
                    bmp = tbmp;
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an error opening the image file.");
                }
            }
            pictureBox1.Image = bmp;
        }
        public void Save()
        {
            if (pathFileName != null)
            {
                try
                {
                    bmp.Save(pathFileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error!");
                }
                canvasChanged = false;
            }  
            else
                SaveAs();
            
        }        
        public void SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {                
                switch (dlg.FilterIndex)
                {
                    case 1:
                        bmp.Save(dlg.FileName, ImageFormat.Jpeg);
                        break;
                    case 2:
                        bmp.Save(dlg.FileName, ImageFormat.Bmp);
                        break;
                    case 3:
                        bmp.Save(dlg.FileName, ImageFormat.Gif);
                        break;
                }
            }
            pathFileName = dlg.FileName;
            canvasChanged = false;
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
                    canvasChanged = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void Canvas_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (canvasChanged)
            {
                var result = MessageBox.Show(
                    "Сохранить изменения в файле?",
                    ((Canvas)sender).MdiParent.Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    Save();
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            oldX = e.X;
            oldY = e.Y;
        } 
    }
}
