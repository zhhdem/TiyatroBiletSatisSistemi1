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
    public partial class Form3 : Form
    {
        SqlConnection connection = Form2.connection;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            textBox5.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                textBox1.BackColor = Color.Yellow;
                textBox2.BackColor = Color.Yellow;
                maskedTextBox1.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                textBox5.BackColor = Color.Yellow;
                MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz!");
            }
            else if(textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Girdiğiniz Şifreler Uyuşmuyor!");
            }
            else
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert Into TabloProje1(name_surname,e_mail,phone_number,password,re_password) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", connection); 
                command.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
                connection.Close();
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
