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
using System.Diagnostics;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace FileSearcher
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //this.BackColor = Color.FromArgb(230, 230, 250);
            
              //  this.BackColor = Color.FromArgb(127, 255, 212);
            //this.ForeColor = Color.FromArgb(32, 178, 170);
            this.BackColor = Color.FromArgb(216, 191, 216);
            this.Opacity = 0.9;
            txtSearchDirectory.BackColor = Color.FromArgb(255, 250, 250);
            listBox1.BackColor = Color.FromArgb(255, 250, 250);
            txtSearchFile.BackColor = Color.FromArgb(255, 250, 250);
            button1.BackColor = Color.FromArgb(255, 250, 250);
            button2.BackColor = Color.FromArgb(255, 250, 250);
            

        }
      
        string strSearchDirectory;
        List<string> myList = new List<string>();
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //strSearchDirectory = txtSearchDirectory.Text;
            //txtSearchDirectory.ReadOnly = true;
            this.ControlBox = false;
            this.Text = String.Empty;
            //Image beat = Image.FromFile(@"\\Mac\Home\Desktop\search.png");
            // button1.Image = Image.FromFile(@"\\Mac\Home\Desktop\search.png");


            textBox1.BackColor = Color.FromArgb(255, 250, 250);
            

            listBox1.BackColor = Color.FromArgb(255, 250, 250);
            
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string epath = "";
            if(fbd.ShowDialog()==DialogResult.OK)
            {
                epath = fbd.SelectedPath;
                txtSearchDirectory.Text = epath;
            }
        }

        public List<string> Search(string direct, string reg, List<string> getList)
        {
            DirectoryInfo dir=new DirectoryInfo(direct);
            Regex rgx = new Regex(@"[\w]+");
            if (getList.Count > 3)
            {
                return getList;
            }
            try
            {
                
                foreach(var files in dir.GetFiles())
                {

                  if (Path.GetFileNameWithoutExtension(files.Name.ToLower()).Contains(reg.ToLower()))
                   {
                        if(!getList.Contains((files.Name)))
                        {
                            if (rgx.IsMatch(files.Name))
                            {
                                getList.Add(files.Name);
                                
                            }
                        }
                        myList.Add(files.FullName);
                    }
                   

                }
            }
            catch
            {
                Console.WriteLine("Oops!");
            }
            try
            {
                foreach (var dirs in dir.GetDirectories())
                {


                    if (Path.GetFileNameWithoutExtension(dirs.Name.ToLower()).Contains(reg.ToLower()))
                    {
                        if (!getList.Contains("[♨]" + dirs.Name))
                        {
                            getList.Add("[♨]" + dirs.Name);
                            myList.Add(dirs.FullName);
                        }
                        
                    }

                    Search(dirs.FullName, reg, getList);
                }
            }
            catch
            {
                Console.WriteLine("Oops!");
            }
            

          
            return getList;
        }
        public List<string> cSearch(string direct,string reg,List<string> getList)
        {
            DirectoryInfo dir = new DirectoryInfo(direct);
            Regex rgx = new Regex(@"[\w]+");
            if (getList.Count > 3)
            {
                return getList;
            }
            try
            {
                
                foreach(var files in dir.GetFiles())
                {
                    if(Path.GetFileNameWithoutExtension(files.Name.ToLower()).Contains(reg.ToLower()))
                    {
                        DateTime tm = File.GetCreationTime(files.FullName);
                        if (!getList.Contains((files.Name)))
                        {
                            if (rgx.IsMatch(files.Name) )
                            {
                                getList.Add(files.Name);
                              

                            }
                        }

                        myList.Add(files.FullName);
                    }
                    
                    /*string[] lines = File.ReadAllLines(files.FullName);
                    foreach (string s in lines.ToList())
                    {
                        if (s.ToLower().Contains(reg))
                        {

                            if (!getList.Contains(files.Name))
                                getList.Add(files.Name);
                            myList.Add(files.FullName);
                            break;

                        }
                    }*/

                }
                
            }
            catch
            {
                Console.WriteLine("Oops:(");
            }
            try
            {
                foreach (var dirs in dir.GetDirectories())
                {
                    if (Path.GetFileNameWithoutExtension(dirs.Name.ToLower()).Contains(reg.ToLower()))
                    {
                        if (!getList.Contains("[♨]" + dirs.Name))
                        {
                            getList.Add("[♨]" + dirs.Name);
                            myList.Add(dirs.FullName);
                        }
                        
                       
                    }
                    cSearch(dirs.FullName, reg, getList);
                }

            }
            catch
            {
                Console.WriteLine("Oops:(");
            }
            
            return getList;
        }
        //Dictionary<string,string> curFullpath=new Dictionary<string, string>();
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            //DirectoryInfo infoDi = new DirectoryInfo(strSearchDirectory);
            //FileInfo[] infoFi = infoDi.GetFiles();
            //FileStream fis = new FileStream(strSearchDirectory,FileMode.Open,);
            //myList.Clear();
            txtSearchFile.Text = "";
            List<string> myFileList = new List<string>();
            //Regex rege = new Regex(@"[\w]+");
            //string s = txtSearchFile.Text.ToString() ;
            //DirectoryInfo infoDi = new DirectoryInfo(@"\\Mac\Home\Desktop");
            string strSearchFile = txtSearchFile.Text.ToString();
            //string strSearchDirectory=
            //listBox1.Items.Clear();
            if(!checkBox1.Checked)
            {
                
                myFileList=Search(@"\\Mac\Home\Desktop", strSearchFile, myFileList);
            }
            if(checkBox1.Checked)
            {
                strSearchDirectory = txtSearchDirectory.Text;
               // myFileList = Search(infoDi, s, myList);
                DateTime dt1 = dateTimePicker1.Value;
                textBox1.Text = dt1.ToString("dd-mm-yyyy");
                DateTime dt2 = dateTimePicker2.Value;
                textBox2.Text = dt2.ToString("dd-mm-yyyy");
                myFileList=Search(txtSearchDirectory.Text, strSearchFile, myFileList);

            }
            listBox1.DataSource = null;
            if (myFileList.Count==0)
            {
                myFileList.Add("No result");
            }
            
            listBox1.DataSource = myFileList;
            /*foreach (FileInfo curFile in infoFi)
            {
                if (curFile.Name.ToUpper().IndexOf(strSearchFile.ToUpper()) != -1)
                {
                    listBox1.Items.Add(curFile.Name);
                    //curFullpath[curFile.Name] = curFile.FullName;

                    //Process.Start(curFullpath[curFile.FullName]);
                }
            }
            txtSearchFile.Clear();
            txtSearchFile.Focus();*/

        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //int index = listBox1.IndexFromPoint(e.Location);
            string file = listBox1.SelectedItem.ToString();
            foreach(var p in myList)
            {
                if(listBox1.SelectedItem.ToString().Contains("[♨]"))
                {
                    file = listBox1.SelectedItem.ToString().Substring(3);
                }
                if(p.Contains(file))
                {
                    Process.Start(p);
                    break;
                }
            }
            //strSearchDirectory+= file;
            //txtSearchDirectory.Text = strSearchDirectory;
           // curFullpath[file] = strSearchDirectory;
          //  Process.Start(strSearchDirectory);
            /*if(File.Exists(file))
            {
                FileInfo myFile = new FileInfo(file);
                TextReader myData = myFile.OpenText();

            }*/
            /*if (index != ListBox.NoMatches)
            {
                Process.Start(index.ToString());
                //MessageBox.Show(index.ToString());
                //Process.Start(@"\\Mac\Home\Desktop\KBTU\labs\lab4.sql");
            }*/
        }
        
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath wantedshape = new GraphicsPath();
            //[] points = new Point[] { new Point { X = 0, Y = 0 }, new Point { X = 420, Y = 20 }, new Point { X = 20, Y = 420 } };
            wantedshape.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(wantedshape);
            this.BackColor = Color.FromArgb(216, 191, 216);
        }
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           // this.BackColor = Color.FromArgb(230, 230, 250);
         //   this.TransparencyKey = Color.Turquoise;
          //  this.Opacity = 0.7;
            
        }
        /*private void checkBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((checkBox1.Checked))
            {

                panel1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
            }
            else {

                infile = false;
                label2.Visible = false;
                label3.Visible = false;
                checkBox2.Visible = true;
                panel1.Visible = false;
                checkBox1.Visible = false;
            }
        }*/

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtSearchDirectory.Text = op.FileName;
            }
            try
            {
                try
                {
                    string[] lines = File.ReadAllLines(txtSearchFile.Text);
                    foreach(string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
                catch
                {

                }
            }
            catch
            {

            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            /* foreach (string dir in Directory.GetDirectories(@"C:\\"))
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                listBox1.Items.Add(info.Name);
            }
            foreach(string file in Directory.GetFiles(@"C:\\"))
            {
                FileInfo info = new FileInfo(file);
                listBox1.Items.Add(info.Name);
            }*/
        }

        private void txtSearchFile_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchFile.Text = "";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Size = new Size(80, 25);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Size = new Size(75, 23);
            button1.Size = new Size(75, 23);
        }

        private void txtSearchFile_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Size = new Size(80, 25);
        }
    }
}
