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
                if (GlobalVars.Basis == GlobalVars.Hex)
                {
                    int numb = Convert.ToInt32(Text, GlobalVars.Hex);                  
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
            if (GlobalVars.Basis == GlobalVars.Hex)
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
