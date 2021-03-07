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
    public partial class Form3 : Form
    {
        string connString = @"URI=file:C:\Users\Acer\Desktop\C#\SQLite\SQLite\bin\Debug\x64\dbase.db";

        public Form3()
        {
            InitializeComponent();
        }
       

       
        private void Button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection cn = new SQLiteConnection(connString);
            cn.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into dbase values(@id, @name, @surname, @password, null, null)", cn);
            cmd.Parameters.AddWithValue("@id", s_id.Text) ;
            cmd.Parameters.AddWithValue("@name", s_name.Text);
            cmd.Parameters.AddWithValue("@surname", s_surname.Text);
            cmd.Parameters.AddWithValue("@password", s_password.Text);

            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Successfull");
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
