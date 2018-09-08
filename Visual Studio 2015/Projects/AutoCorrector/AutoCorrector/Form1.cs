using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCorrector
{
    public partial class AutoCorrector : Form
    {
        public AutoCorrector()
        {
            InitializeComponent();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text ="";
            text = richTextBox1.Text;
            if(!Char.IsLetter.Text[text.Length-1])
            {

            }
        }
    }
}
