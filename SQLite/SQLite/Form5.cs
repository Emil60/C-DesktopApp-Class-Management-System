using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQLite
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string connString = @"URI=file:C:\Users\Acer\Desktop\C#\SQLite\SQLite\bin\Debug\x64\mdb.db";

        private void Form5_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(connString);
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from mdb", cn);


            SQLiteDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;


            cn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
