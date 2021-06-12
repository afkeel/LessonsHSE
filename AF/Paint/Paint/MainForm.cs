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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CurrentColor = Color.Black;
            CurrentTool = Tools.Pen;
        }
        /// <summary>
        /// Текущий цвет
        /// </summary>
        public static Color CurrentColor { get; set; }
        public static Tools CurrentTool { get; set; }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new DocumentForm();
            f.MdiParent = this;
            f.Show();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AboutBoxForm();
            f.ShowDialog();
        }
        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Red;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Blue;
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Green;
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            var d = new ColorDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                CurrentColor = d.Color;
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            CurrentTool = Tools.Pen;
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            CurrentTool = Tools.Circle;
        }

        private void toolStripLabel3_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = ActiveMdiChild as DocumentForm;
            if (d != null)
            {
                var dlg = new SaveFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                    d.SaveAs(dlg.FileName);
                {

                }

            }
        }
    }
}
