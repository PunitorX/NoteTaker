using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaker
{
    public partial class Form1 : Form
    {

        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Notes", typeof(string));

            dataGridView1.DataSource = table;

            dataGridView1.Columns["Notes"].Visible = false;
            dataGridView1.Columns["Title"].Width = 220;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtNotes.Clear();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtNotes.Text);

            txtTitle.Clear();
            txtNotes.Clear();
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            if(index > -1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtNotes.Text = table.Rows[index].ItemArray[1].ToString();

            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            table.Rows[index].Delete();
        }
    }
}
