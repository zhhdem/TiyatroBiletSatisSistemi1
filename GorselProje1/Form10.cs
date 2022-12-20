using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GorselProje1
{
    public partial class Form10 : Form
    {
        public static SqlConnection connection = new SqlConnection("Data Source =LAPTOP-NVKLLTFM\\SQLEXPRESS; Initial Catalog= proje1; Integrated Security=TRUE");
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            string personel_id  = maskedTextBox1.Text;
            string password = textBox1.Text;
            bool compare = false;

            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Personel_Giris", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (personel_id == reader["personel_id"].ToString().TrimEnd() && password == reader["password"].ToString().TrimEnd())
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
                frm7.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!", "Program");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
        }
    }
    }

