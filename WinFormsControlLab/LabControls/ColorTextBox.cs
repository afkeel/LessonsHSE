using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabControls
{
    public partial class ColorTextBox : TextBox
    {
        public int Color { get; set; }
        public ColorTextBox()
        {
            InitializeComponent();
        }
        public ColorTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (int.TryParse(Text, out int res))
            {
                if (res < 0)
                {
                    res = 0;
                    Text = "0";
                }
                else if (res > 255)
                {
                    res = 255;
                    Text = "255";
                }
                this.Color = res;
            }     
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl((e.KeyChar)))
                e.Handled = true;
            base.OnKeyPress(e);
        }
    }
}
