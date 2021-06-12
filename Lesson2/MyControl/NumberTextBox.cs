using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyControl
{
    public partial class NumberTextBox : Component
    {
        public NumberTextBox()
        {
            InitializeComponent();
        }

        public NumberTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }        
    }
}
