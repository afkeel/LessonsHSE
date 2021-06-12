using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2_1
{
    public partial class FileControl : UserControl
    {
        public event EventHandler<EventArgs> FileChanged;
        public string FileName
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                OnFileChanged();
            }
        }
        protected void OnFileChanged()
        {
            if (FileNameChanged != null)
                FileNameChanged(this, new EventArgs());
        }
            
        public FileControl()
        {
            InitializeComponent();
        }

        private void FileControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var dlg = new OpenFileDialog();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    textBox1.Text = dlg.FileName;
            //}
            MessageBox.Show(FileControl.FileName)
        }
    }
}
