using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class MyUserControl : UserControl
    {
        
        public MyUserControl()
        {
            InitializeComponent();
            label1.Text = name;
        }
        public static MyUserControl _instance;
        public static MyUserControl Instacne
        {
            get
            {
                if (_instance == null)
                    _instance = new MyUserControl();
                return _instance;
            }
        }

        public int i = 0;
        public string name = null;
        public int spenttime = 0;
        public string ConvertTimeToString(int time)
        {
            string hour = (time / 3600).ToString();
            time %= 3600;
            string minutes = (time / 60).ToString();
            time %= 60; 
            string seconds = (time).ToString();
            string ans = hour + ":" + minutes + ":" + seconds;
            return ans;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Started");
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                spenttime++;
                label2.Text = ConvertTimeToString(spenttime);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        public void Redraw()
        {
            Panel panel = (this.Parent as Panel);
            int y = 0;
            panel.Controls.Clear();
            for (int i = 0; i < Form1.tasks.Count; i++)
            {
                MyUserControl uc = new MyUserControl();
                uc.label1.Text = Form1.tasks[i].name;
                uc.progressBar1.Maximum = Form1.tasks[i].goaltime;
                uc.progressBar1.Value = Form1.tasks[i].spenttime;
                uc.Location = new Point(0, y);
                panel.Controls.Add(uc);
                panel.Refresh();
                y += 60;
            }
        }
        public void button3_Click(object sender, EventArgs e)
        {
            name = label1.Text;
            for (int i = 0; i < Form1.tasks.Count; i++)
            {
                if (Form1.tasks[i].name == name)
                {
                    Form1.tasks.RemoveAt(i);
                }
            }
            for (int i = 0; i < Form1.tasks.Count; i++)
            {
                if (Form1.tasks[i].name == name)
                {
                    Form1.tasks.RemoveAt(i);
                }
            }
            Redraw();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            progressBar1.Value = 0;
            spenttime = 0;
        }

        private void MyUserControl_Load(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)this.Parent;
            Form1 form = (Form1)panel.Parent;
            name = label1.Text;
            MessageBox.Show(form.textBox1.Text);
            for (int i = 0; i < Form1.tasks.Count; i++)
            {
               if (Form1.tasks[i].name == name)
                 {
                     Form1.tasks[i].name = form.textBox1.Text;
                     Form1.tasks[i].goaltime = Form1.ConvertStringToTime(form.textBox2.Text);
                     progressBar1.Maximum = Form1.ConvertStringToTime(form.textBox2.Text);
                  }
             }
        Redraw();
        }
    }
}
