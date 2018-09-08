using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public static Color c = Color.Magenta;
        Brush b = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
        Brush br = new SolidBrush(c);
        Pen p = new Pen(c);
        
        
        /*private void DrawEllipseRectangle(PaintEventArgs e)
        {
        
            Pen blackPen = new Pen(Color.Black, 3);

          
            Rectangle rect = new Rectangle(0, 0, 200, 100);

            e.Graphics.DrawEllipse(blackPen, rect);
        }*/
        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /* Graphics g = e.Graphics;
             Pen blackPen = new Pen(Color.Black, 3);
             Rectangle rect = new Rectangle(0, 0, 200, 100);
             g.DrawEllipse(blackPen, rect);
             g.Dispose();*/
            Graphics g = e.Graphics;
            g.FillRectangle(b, 0, 0, 21, 21);
            g.DrawEllipse(p, 0, 0, 21, 21);
            g.FillEllipse(br, 0, 0, 21, 21);
            //GraphicsPath path = new GraphicsPath();
            //path.AddEllipse(0, 0, 210, 210);
            //this.Region = new Region(path);
            drawTriangle(e, 50, 50, 70);
            

        }
        public void drawTriangle(PaintEventArgs e, int x, int y, int distance)
        {
            float angle = 0;

            SolidBrush brs = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.Magenta);
            PointF[] p = new PointF[3];

            p[0].X = x;

            p[0].Y = y;

            p[1].X = (float)(x + distance * Math.Cos(angle));

            p[1].Y = (float)(y + distance * Math.Sin(angle));

            p[2].X = (float)(x + distance * Math.Cos(angle + Math.PI / 3));

            p[2].Y = (float)(y + distance * Math.Sin(angle + Math.PI / 3));
            List<Point> points = new List<Point>() { };

            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 12; k++)
                {
                    points.Add(new Point(j * 10, k * 12));

                }
            }
            /*Ellipse[] ellipsePoints = new Ellipse[120];

            for (int j = 0; j < 120; j++)
            {
                ellipsePoints[j] = new Ellipse() { Width = 2, Height = 2, Fill = Brushes.Red };

                MainCanvas.Children.Add(ellipsePoints[j]);
            }

            for (int i = 0; i < points.Count; i++)
            {
                Canvas.SetLeft(ellipsePoints[i], points[i].X - ellipsePoints[i].Width / 2);
                Canvas.SetTop(ellipsePoints[i], points[i].Y - ellipsePoints[i].Height / 2);
            }*/
            e.Graphics.DrawPolygon(pen, p);

        }
    }
}
