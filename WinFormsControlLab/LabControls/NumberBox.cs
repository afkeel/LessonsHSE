using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabControls
{
    public partial class NumberBox : Form
    {
        public NumberBox()
        {
            InitializeComponent();
        }
        public NumberBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
