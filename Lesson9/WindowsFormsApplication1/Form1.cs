using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Thread.CurrentThread.Name = "Main";
            //progressBar1.Maximum = 1000000;
            Thread t1 = new Thread(LongOperation);
            t1.Name = "LongOperation";
            t1.Priority = ThreadPriority.AboveNormal;
            t1.Start(Color.Red);

            Thread t2 = new Thread(LongOperation);
            t2.Name = "LongOperation";
            t2.Priority = ThreadPriority.BelowNormal;
            t2.Start(Color.Green);

            Thread t3 = new Thread(LongOperation);
            t3.Name = "LongOperation";
            t3.Priority = ThreadPriority.Normal;
            t3.Start(Color.Blue);
        }
        //private void LongOperation()
        //{
        //    bool b = true;            
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        for (int j = 0; j < 10000; j++)
        //            b = !b;
        //        Invoke((Action)delegate() { progressBar1.Value += 1; });                
        //    }
        //    MessageBox.Show("Done");
        //}
        Random rnd = new Random();
        bool stop = false;
        object obj = new object();
        private void LongOperation(object color)
        {
            stop = false;
            Color c = (Color)color;
            var g = CreateGraphics();
            while (!stop)
            {
                lock(obj)
                {
                    g.FillEllipse(new SolidBrush(c), rnd.Next(ClientSize.Width),
                    rnd.Next(ClientSize.Height), 10, 10);
                }              
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            stop = true;
        }
    }
}
