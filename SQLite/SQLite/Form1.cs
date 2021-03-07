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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connString = @"URI=file:C:\Users\Acer\Desktop\C#\SQLite\SQLite\bin\Debug\x64\dbase.db";
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(connString);
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from dbase where ID=@id and Password=@password",cn);
            cmd.Parameters.AddWithValue("@id", textBox2.Text);
            cmd.Parameters.AddWithValue("@password", textBox1.Text);

            SQLiteDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            if(dt.Rows.Count > 0 && textBox1.Text=="cavid" && textBox2.Text=="2")
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else if(dt.Rows.Count > 0)
            {

                Form4 form4 = new Form4(textBox2.Text);
                form4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Denied");
            }

            cn.Close();
        }
    }
}
