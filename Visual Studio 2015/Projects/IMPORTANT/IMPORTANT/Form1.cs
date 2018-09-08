using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Samples
{
    public partial class CircleForm : Form
    {
        private List<Circles> m_Circles = new List<Circles>();
        private int count;

        public CircleForm()
        {
            InitializeComponent();
            int radius;
            for (int i = 0; i < 8; i++)
            {
                Color col = Color.Black;
                radius = 20 * (i + 1);
                if (i == 3)
                    col = Color.Red;

                m_Circles.Add(new Circles(new Point(180, 180), radius, col, 2, false));
            }

           
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            foreach (Circles tCircle in m_Circles)
            {
                if (tCircle.IsVisible)
                    tCircle.Paint(e.Graphics);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count > 0)
                m_Circles[count - 1].IsVisible = false;
            else
                m_Circles[7].IsVisible = false;

            m_Circles[count++].IsVisible = true;
            if (count > 7)
            {
                count = 0;
            }
            this.Refresh();
        }

        private void CircleForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Circles
    {
        public Point Location = new Point(0, 0);
        public int Radius = 5;
        public Color BorderColor = Color.Red;
        public int BorderWidth = 5;
        public bool IsVisible = true;

        public Circles(Point loc, int rad, Color bc, int bw, bool visible)
        {
            Location = loc;
            Radius = rad;
            BorderColor = bc;
            BorderWidth = bw;
            IsVisible = visible;
        }

        public void Paint(Graphics g)
        {
            g.DrawEllipse(new Pen(BorderColor, BorderWidth), Location.X - Radius, Location.Y - Radius, Radius * 2, Radius * 2);
        }
    }

}
