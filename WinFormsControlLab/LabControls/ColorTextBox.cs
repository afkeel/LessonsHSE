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
        private string color;
        public int radioButton = 10;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Text = color;         
            }
        }
        public ColorTextBox()
        {
            InitializeComponent();
        }
        public ColorTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        private string CheckVal(int res, string str)
        {
            if (res < 0)
            {
                return "0";
            }
            else if (res > 255)
            {
                return str;
            }
            return Text;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (Text.Length!=0)
            {
                if (radioButton == 16)
                {
                    int numb = Convert.ToInt32(Text, 16);                  
                    Color = CheckVal(numb, "FF");
                }
                else
                {
                    if (int.TryParse(Text, out int res))
                    {
                        Color = CheckVal(res, "255");
                    }
                }
            }
            else
            {
                Color = "0";
            }
            base.OnTextChanged(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (radioButton == 16)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    char ch = char.ToLower(e.KeyChar);
                    if (ch < 'a' || ch > 'f')
                    {
                        e.Handled = true;
                    }  
                }
                base.OnKeyPress(e);
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
                base.OnKeyPress(e);
            }           
        }
    }
}
