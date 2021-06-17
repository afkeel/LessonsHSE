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
        private string CheckText(int res)
        {
            string str = Text;
            if (res < 0)
            {
                return "0";
            }
            else if (res > 255)
            {
                return "255";
            }
            return str;
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (Text.Length!=0)
            {
                if (GlobalVars.Basis == GlobalVars.Hex)
                {
                    string str = Text;
                    int numb = Convert.ToInt32(Text, GlobalVars.Hex);
                    if (numb < 0)
                    {
                        str = "0";
                    }
                    else if (numb > 255)
                    {
                        str = "FF";
                    }
                    Color = str;
                }
                else
                {
                    if (int.TryParse(Text, out int res))
                    {
                        Color = CheckText(res);
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
