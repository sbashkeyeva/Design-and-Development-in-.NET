using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SpellCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            while (!sr.EndOfStream) words.Add(sr.ReadLine());
            
        }
        string text = "";
        List<string> words = new List<string>();
        string word = "";
        StreamReader sr = new StreamReader("words");
        List<string> boxWord = new List<string>();

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (text == richTextBox1.Text) return;
            text = richTextBox1.Text;
            int n = text.Length;
            if(text.Length == 0 ) return ;
            if (!Char.IsLetter(text[n - 1]))
            {

                for (int i = n - 2; i >= 0; i--)
                {
                    if (i == 0) { word = text.Substring(i, n - i - 1); break; }
                    if (!Char.IsLetter(text[i])) { word = text.Substring(i + 1, n - i - 2); break; }
                }
                if (word.Length == 0) return;
                if (words.Contains(word)) return;
                string changingWord = Levenshtein(word);
                if (checkBox1.Checked)
                {
                    text = text.Replace(word, changingWord);
                    richTextBox1.Text = text;
                    richTextBox1.SelectionStart = n - word.Length + changingWord.Length;
                }
                else
                {
                    //System.Windows.Forms.MessageBox.Show("+" + boxwords.Count);
                    listBox1.Items.Clear();
                    
                    if (boxWord.Count != 0)
                    {
                        for (int i = 0; i < boxWord.Count; i++)
                        {
                            listBox1.Items.Add(boxWord[i]);
                        }
                    }
                    else
                    {
                        listBox1.Items.Add(changingWord);
                    }
                    boxWord.Clear();

                    richTextBox1.SelectionStart = n - word.Length - 1;
                    richTextBox1.SelectionLength = word.Length;
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectionStart = n;
                    //richTextBox1.SelectionLength = 0;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length - word.Length - 1;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionColor = Color.Black;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //List<String> w = new List<String>();//better to use BindingList 
            //listBox1.DataSource = w;
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionColor = Color.Black;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionColor = Color.Black;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // listBox1.SelectedItem 
            string change = listBox1.SelectedItem.ToString();
            text = text.Replace(word, change);
            word = change;
            richTextBox1.Text = text;
            richTextBox1.SelectionStart = richTextBox1.Text.Length - word.Length - 1;
            richTextBox1.SelectionLength = word.Length;
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectionStart = text.Length;
        }
        public String Levenshtein(String p)
        {
            int k = 0;
            String ans = "";
            int mn = p.Length;
            while (k != words.Count)
            {
                string s = words[k];
                int[][] dp = new int[s.Length + 1][];
                for (int i = 0; i <= s.Length; i++)
                {
                    dp[i] = new int[p.Length + 2];
                    dp[i][0] = i;
                }
                for (int i = 0; i <= p.Length; i++)
                {
                    dp[0][i] = i;
                }
                for (int i = 1; i <= s.Length; i++)
                {
                    for (int j = 1; j <= p.Length; j++)
                    {
                        if (s[i - 1] == p[j - 1])
                        {
                            dp[i][j] = dp[i - 1][j - 1];
                        }
                        else
                        {
                            dp[i][j] = Math.Min(Math.Min(dp[i - 1][j] + 1, dp[i][j - 1] + 1), dp[i - 1][j - 1] + 2);
                        }
                    }
                }
                if (dp[s.Length - 1][p.Length - 1] < 3) boxWord.Add(s);
                if (mn > dp[s.Length - 1][p.Length - 1])
                {
                    ans = s;
                    mn = dp[s.Length - 1][p.Length - 1];
                }
                k++;
            }
            return ans;
        }
        /*public int min(int x, int y, int z)
        {
            int o = Math.Min(x, y);
            return Math.Min(o, z);
        }*/
        
        


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            { 
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //second way
            //  e.KeyChar
            // textBox1.SelectionStart
        }
        private void s(object sender, EventArgs e)
        {

        }
        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
