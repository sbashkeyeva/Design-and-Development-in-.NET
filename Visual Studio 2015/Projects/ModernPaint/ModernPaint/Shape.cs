using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ModernPaint
{
    public partial class Shape : UserControl
    {
        public Shape()
        {
            InitializeComponent();
        }
        public enum ShapeType{CIRCLE, RECTANGLE,TRIANGLE};
        public ShapeType shape;
        public GraphicsPath path;
        public void make()
        {
            path = new GraphicsPath();
            switch (shape)
            {
                case ShapeType.RECTANGLE:
                    path.AddRectangle(this.ClientRectangle);
                    break;
            }
            this.Region = new Region(path);
                
        }
        public ShapeType Type
        {
           get
            {
                return shape;
            }
            set
            {
                shape = value;
                make();
            }
          }

    }
}
