using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Regexp(@"^[A-Z][a-zA-Z]+$", textBox1, label6, "Name");
            Regexp(@"^([\w]+)@([\w]+)\.([\w]+)$", textBox3, label7, "Email");
            Regexp(@"^\(?\d{3}\)?[\s\-]?\d{3}\-?\d{4}$",textBox2,label5,"Phone Number");
            Regexp(@"^\d{5}(?:[-\s]\d{4})?$", textBox4, label8, "Zip Code");
            label10.Text += ReformatPhone(textBox2.Text);
        }
        static string ReformatPhone(string s)
        {
            Match m=Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
            return String.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);
        }
        public void Regexp(string pattern, TextBox tb, Label lbl,string s)
        {
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(tb.Text))
            {
                lbl.ForeColor = Color.Green;
                lbl.Text = s+" is Valid";
          
            }
            else
            {
                lbl.ForeColor = Color.Red;
                lbl.Text = s + " is Invalid";
            }
                
        }
       

       
    }
}
