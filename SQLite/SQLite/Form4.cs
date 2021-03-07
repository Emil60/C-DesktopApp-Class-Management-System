using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLite
{
    public partial class Form4 : Form
    {
        string n;
        public Form4(string id)
        {
            InitializeComponent();
            
            n = id;
        }
        string connString = @"URI=file:C:\Users\Acer\Desktop\C#\SQLite\SQLite\bin\Debug\x64\db.db";
        string connStringm = @"URI=file:C:\Users\Acer\Desktop\C#\SQLite\SQLite\bin\Debug\x64\mdb.db";
        string connStringn = @"URI=file:C:\Users\Acer\Desktop\C#\SQLite\SQLite\bin\Debug\x64\dbase.db";

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(connString);
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from db", cn);


            SQLiteDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            cn.Close();
            SQLiteConnection cnn = new SQLiteConnection(connStringn);
            cnn.Open();
            DataTable dtt = new DataTable();
            SQLiteCommand cd = new SQLiteCommand("select * from dbase where ID=@id", cnn);
            cd.Parameters.AddWithValue("@id", n);
            SQLiteDataReader readerr = cd.ExecuteReader();
            dtt.Load(readerr);
            string s = dtt.Rows[0][1].ToString();
            label3.Text = s;
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f4 = new Form1();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(connStringm);
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into mdb values( @name, @message)", cn);
            cmd.Parameters.AddWithValue("@name", label3.Text);
            cmd.Parameters.AddWithValue("@message", richTextBox1.Text);

            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Successfull");
        }
    }
}
