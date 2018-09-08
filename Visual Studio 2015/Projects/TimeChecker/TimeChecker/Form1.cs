using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<TimeControl> timeControl = new List<TimeControl>();
        private void button1_Click(object sender, EventArgs e)
        {
            TimeControl tc = new TimeControl();
            flowLayoutPanel1.Controls.Add(tc);
            tc.changeName(textBox1.Text);
            tc.changeGoal((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            foreach (TimeControl t in flowLayoutPanel1.Controls)
            {
                chart1.Series["Series1"].Points.AddXY(t.getName(),t.getTime());
            }
            
        }
    }
}
