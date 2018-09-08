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

namespace EndTerm
{
    public partial class Form1 : Form
    {
        BindingList<Link> bl = new BindingList<Link>();
       
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            dataGridView1.DataSource = bl;
            bl.AllowRemove = true;
            bl.AllowNew = true;
            bl.AllowEdit = true;
            bl.Add(new Link( "krisha", "https://krisha.kz/prodazha/kvartiry/almaty/?das[map.complex]=15", "kvartiry"));
            bl.Add(new Link( "apples", "https://apples.kz/apple-watch-1-seriya-4", "apple-watch-1-seriya-4"));
            bl.Add(new Link("vk", "https://vk.com/sbashkeyeva", "sbashkeyeva"));
            dataGridView1.Refresh();
        }

       

        private  void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            //FileStream fs = new FileStream("");
            //textBox1.Text = selectedRow.Cells[0].Value.ToString();
            //textBox2.Text = selectedRow.Cells[1].Value.ToString();
            //textBox3.Text = selectedRow.Cells[2].Value.ToString();
            

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
