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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Seans_BilgileriTableAdapter tiyatroseansi = new DataSet1TableAdapters.Seans_BilgileriTableAdapter();
        public static SqlConnection connection = new SqlConnection("Data Source =LAPTOP-NVKLLTFM\\SQLEXPRESS; Initial Catalog= proje1; Integrated Security=TRUE");
        private void Form8_Load(object sender, EventArgs e)
        {
            TiyatroGoster(comboBox1, "select *from Tiyatro_Bilgileri", "TiyatroAdi");
        }

        private void TiyatroGoster(ComboBox combo, string sql, string sql2)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand(sql, connection);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                combo.Items.Add(read[sql2].ToString());
            }
            connection.Close();
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.ShowDialog();
        }

        string seans = "";

        private void RadioButtonSeciliyse()
        {
            if (radioButton1.Checked == true) seans = radioButton1.Text;
            else if (radioButton2.Checked == true) seans = radioButton2.Text;
            else if (radioButton3.Checked == true) seans = radioButton3.Text;
            else if (radioButton4.Checked == true) seans = radioButton4.Text;
            else if (radioButton5.Checked == true) seans = radioButton5.Text;
            else if (radioButton6.Checked == true) seans = radioButton6.Text;
            else if (radioButton7.Checked == true) seans = radioButton7.Text;
            else if (radioButton8.Checked == true) seans = radioButton8.Text;
            else if (radioButton9.Checked == true) seans = radioButton9.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RadioButtonSeciliyse();
            if (seans != "")
            {
                
                tiyatroseansi.SeansEkleme(comboBox1.Text,dateTimePicker1.Text,seans);
                MessageBox.Show("Seans Ekleme İşlemi Başarılı","Kayıt");
            }
            else if (seans == "")
            {
                MessageBox.Show("Lütfen Seans Seçiniz", "Uyarı");
            }

            comboBox1.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach(Control item3 in groupBox1.Controls)
            {
                item3.Enabled = true;

            }
            
            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (yeni == bugün)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortDateString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;

                    }
                }

                Karsilastir();
            }
            else if (yeni > bugün)
            {
                Karsilastir();
            }
            else if (yeni < bugün)
            {
                MessageBox.Show("Geriye Dönük İşlem Yapılamaz", "Uyarı");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void Karsilastir()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("select *from Seans_Bilgileri where Tarih = '" + dateTimePicker1 + "' ",connection);
            komut.Connection = connection;

            SqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                foreach (Control item2 in groupBox1.Controls)
                {
                    if (read["seans"].ToString() == item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            connection.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
