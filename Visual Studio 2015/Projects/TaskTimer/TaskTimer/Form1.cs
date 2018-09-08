using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int i = 0;
        public static List<Task> tasks = new List<Task>();
        public void Draw()
        {
            int y = 0;
            for (int i = 0; i < tasks.Count; i++)
            {
                UserControl1 uc = new UserControl1();
                uc.label1.Text = tasks[i].name;
                uc.progressBar1.Maximum = tasks[i].goaltime;
                uc.progressBar1.Value = 0;
                uc.Location = new Point(0, y);
                panel1.Controls.Add(uc);
                panel1.Refresh();
                y += 60;
            }
        }
        public static int ConvertStringToTime(string t)
        {
            int time = 0;
            string hour = t.Substring(0, 2);
            string minutes = t.Substring(3, 2);
            string seconds = t.Substring(6, 2);
            time += Int32.Parse(hour) * 3600;
            time += Int32.Parse(minutes) * 60;
            time += Int32.Parse(seconds);
            return time;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task task = new Task(i, textBox1.Text, ConvertStringToTime(textBox2.Text), 0);
            tasks.Add(task);
            i++;
            Draw();
            textBox1.Clear();
            textBox2.Clear();
        }


    }
}