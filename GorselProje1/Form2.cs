using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GorselProje1
{
    public partial class Form2 : Form
    {

         public static SqlConnection connection = new SqlConnection("Data Source =LAPTOP-NVKLLTFM\\SQLEXPRESS; Initial Catalog= proje1; Integrated Security=TRUE");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            string e_mail = textBox1.Text;
            string password = textBox2.Text;
            bool compare = false;
            

            connection.Open();
            SqlCommand command = new SqlCommand("Select *from TabloProje1", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (e_mail == reader["e_mail"].ToString().TrimEnd() && password == reader["password"].ToString().TrimEnd() )
                {
                    compare = true;
                    break;
                }
                else
                {
                    compare = false;
                }
            }
            connection.Close();

            if (compare)
            {
                MessageBox.Show("Başarılı Giriş Yaptınız!", "Program");
                this.Hide();
                frm4.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!", "Program");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
    }
}
