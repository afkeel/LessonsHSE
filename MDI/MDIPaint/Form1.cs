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
        public static Color CurColor = Color.Black;
        public static int CurWidth = 1;
        public MainForm()
        {
            InitializeComponent();
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
    }
}
