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


namespace MidTerm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         

    }
        
        public static Color c = Color.Magenta;
        Brush b = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
        Brush br = new SolidBrush(c);
        Pen p = new Pen(c);


        /*public static int cRed1 = someColor1.R;
        public static int cBlue1 = someColor1.B;
        public static int cGreen1 = someColor1.G;
        public static int cRed2 = someColor2.R;
        public static int cBlue2 = someColor2.B;
        public static int cGreen2 = someColor2.G;*/



        // int N = distance;

        public static Color color3;
        public static Color color1;
        public static Color color2;
        private void button4_Click_1(object sender, EventArgs e)
        {
            //Color color1;
            //Color color2;
            
            int cRed1 = color1.R;
            int cBlue1 = color1.B;
            int cGreen1 = color1.G;
            int cRed2 = color2.R;
            int cBlue2 = color2.B;
            int cGreen2 = color2.G;
            int cRed3 = color3.R;
            int cBlue3 = color3.B;
            int cGreen3 = color3.G;
            int distance = int.Parse(textBox1.Text);
            int average1 = Math.Abs((cRed1 - cRed2) / distance-1);
            int average2 = Math.Abs((cGreen1 - cGreen2) / distance-1);
            int average3 = Math.Abs((cBlue1 - cBlue2) / distance-1);
            int N = distance;
            int w = 0;
            int z = 0;
            int x = 0;
            int y = 0;

            Graphics g = CreateGraphics();

            //Color newcolor;
            for (int i = 21; i <= distance; i += 21)
            {
                 

                for (int j = 21; j <= distance-i; j+=21)
                {
                    if(cRed1>cRed2)
                    {
                        cRed1 -= average1;
                    }
                    if(cRed1<cRed2)
                    {
                        cRed1 += average1;
                    }
                    if (cGreen1 > cGreen2)
                    {
                        cGreen1 -= average2;
                    }
                    if (cGreen1 < cGreen2)
                    {
                        cGreen1 += average2;
                    }
                    if (cBlue1 > cBlue2)
                    {
                        cBlue1 -= average3;
                    }
                    if (cBlue1 < cBlue2)
                    {
                        cBlue1 += average3;
                    }
                    //newcolor = Color.FromArgb(cRed1, cGreen1, cBlue1);
                    
                    SolidBrush sb = new SolidBrush(color1);
                    Rectangle r = new Rectangle(i+w, j+w+z, 21, 21);
                    g.FillEllipse(sb, r);
                    //g.FillEllipse(new SolidBrush(Color.Magenta), i + x, j + x + z, N, N);

                    //color1 = Color.FromArgb(cRed2, cGreen2, cBlue2);

                }
                
                z += 21 / 2;
                cRed2 += average1;
                cBlue2 += average2;
                cGreen2 += average3;
                color1 = Color.FromArgb(cRed1, cGreen1, cBlue1);
                
                x = x + 21 / 2;
                y = y + 21 / 4;

                

            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

       
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
                color1 = colorDialog1.Color;
                button1.BackColor = color1;
               
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                color2 = colorDialog2.Color;
                button2.BackColor = color2;
               
            }
        }
   

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
               
                color3 = colorDialog3.Color;
                button3.BackColor = color3;
              
            }
        }
        string text = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text = textBox1.Text;
        }
    }
}
