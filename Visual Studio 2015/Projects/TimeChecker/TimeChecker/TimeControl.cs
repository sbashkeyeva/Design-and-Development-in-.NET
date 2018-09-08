using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TimeChecker
{
    public partial class TimeControl : UserControl
    {
        public TimeControl()
        {
            InitializeComponent();
        }
        int goalSeconds,seconds=0;
        public void changeGoal(int hours,int minutes)
        {
            goalSeconds = hours * 3600 + minutes * 60;
            TimeSpan time = TimeSpan.FromSeconds(goalSeconds);
            string str = time.ToString(@"hh\:mm\:ss");
            label2.Text = str;
            progressBar1.Maximum = goalSeconds;
            //TimeSpan ts
        }
        public void changeName(string s)
        {
            label1.Text = s;
        }
        public void changeTime(int s)
        {
            TimeSpan time = TimeSpan.FromSeconds(s);
            string str = time.ToString(@"hh\:mm\:ss");
            label3.Text = str;
        }
        public string getName()
        {
            return label1.Text;
        }
        public int getTime()
        {
            return seconds;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            seconds = 0;
            progressBar1.Value = 0;
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            seconds++;
            changeTime(seconds);
            progressBar1.Value++;
            if(progressBar1.Value==progressBar1.Maximum)
            {
                SystemSounds.Beep.Play();
                timer1.Stop();
            }
        }
    }
}
