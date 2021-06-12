using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyControl
{
    public partial class Circle : Control
    {
        public Circle()
        {
            InitializeComponent();
        }

        public Circle(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private Color color = Color.Black;
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), ClientRectangle());
        }

    }
}
