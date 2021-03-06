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
    public partial class MainForm : Form
    {
        public static Color CurrentColor { get; set; }
        public static Tools CurrentTool { get; set; }
        public static int CurWidth = 1;      
        public MainForm()
        {
            InitializeComponent();
            CurrentColor = Color.Black;
            CurrentTool = Tools.Pen;
            txtBrushSize.Text = CurWidth.ToString();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AboutPaint();
            f.ShowDialog();
        }
        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas frmChild = new Canvas();
            frmChild.MdiParent = this;            
            frmChild.Show();            
            ((Canvas)ActiveMdiChild).CanvasWidth = frmChild.PictureBox1Width;
            ((Canvas)ActiveMdiChild).CanvasHeight = frmChild.PictureBox1Height;           
        }
        private void рисунокToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }
        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasSize cs = new CanvasSize();
            cs.TextBoxWidth = ((Canvas)ActiveMdiChild).CanvasWidth.ToString();
            cs.TextBoxHeight = ((Canvas)ActiveMdiChild).CanvasHeight.ToString();
            if (cs.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(cs.TextBoxWidth, out int w))
                    ((Canvas)ActiveMdiChild).CanvasWidth = w;
                if (int.TryParse(cs.TextBoxHeight, out int h))
                    ((Canvas)ActiveMdiChild).CanvasHeight = h;
            }
        }
        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Red;
        }
        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Blue;
        }
        private void зелёныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Green;
        }
        private void другойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                CurrentColor = cd.Color;
        }
        private void txtBrushSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurWidth = int.Parse(txtBrushSize.Text);
            }
            catch
            {
                MessageBox.Show("Значение должн быть целым числом.", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Canvas frmChild = new Canvas(dlg.FileName);
                frmChild.MdiParent = this;
                frmChild.Show();
                frmChild.PathFileName = dlg.FileName;
            }   
        }
        private void файлToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
            сохранитьКакToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).Save();
        }
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).SaveAs();
        }
        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void пероToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTool = Tools.Pen;
            пероToolStripMenuItem.Checked = true;
            окружностьToolStripMenuItem.Checked = false;
        }
        private void окружностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTool = Tools.Circle;
            пероToolStripMenuItem.Checked = false;
            окружностьToolStripMenuItem.Checked = true;
        }
    }
}
