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
    public partial class Form2 : Form
    {
        string connString = @"URI=file:C:\Users\Acer\Desktop\C#\SQLite\SQLite\bin\Debug\x64\dbase.db";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
            DataTable dt = new DataTable();
            SQLiteConnection cn = new SQLiteConnection(connString);
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from dbase", cn);
            

            SQLiteDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

            cn.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            e_id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            e_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            e_sname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            e_pid.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(connString);
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand("update dbase set ID=@id,Name=@name,Surname=@surname,Attendance=@attendance where PrimaryID=@pid", cn);

            cmd.Parameters.AddWithValue("@id", e_id.Text);
            cmd.Parameters.AddWithValue("@name", e_name.Text);
            cmd.Parameters.AddWithValue("@surname", e_sname.Text);
            cmd.Parameters.AddWithValue("@attendance", e_attendance.Text);

            cmd.Parameters.AddWithValue("@pid",int.Parse(e_pid.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated");
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();

            cn.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(connString);
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from dbase where PrimaryID=@pid", cn);


            cmd.Parameters.AddWithValue("@pid", int.Parse(e_pid.Text));

            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();

            cn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }
    }
}
