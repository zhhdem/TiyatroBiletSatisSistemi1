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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        int sayac = 0;
        System.Windows.Forms.Button oncekiButon;
        private void TiyatroGetir(ComboBox combo, string sql1, string sql2)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand(sql1, connection);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read[sql2].ToString());

            }
            connection.Close();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-NVKLLTFM\\SQLEXPRESS;Initial Catalog=proje1;Integrated Security=True");

        private void YenidenRenklendir()
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }
        private void Veritabanı_Dolu_Koltuklar()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("select *from Seans_Bilgileri where FilmAdi='" + comboBox1.Text + "' and Tarih='" + comboBox2.Text + "' and Seans='" + comboBox3.Text + "'", connection);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in panel1.Controls)
                {
                    if (item is Button)
                    {
                        if (read["KoltukNo"].ToString() == item.Text)
                        {
                            item.BackColor = Color.Red;
                        }

                    }
                }
            }
            connection.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            Bos_Koltuklar();
            TiyatroGetir(comboBox1, "Select *from Tiyatro_bilgileri", "TiyatroAdi");
            Veritabanı_Dolu_Koltuklar();
            comboBox4.Items.Add("50");
            TiyatroGetir(comboBox2, "Select  distinct Tarih from Seans_Bilgileri", "Tarih");
            TiyatroGetir(comboBox3, "Select distinct Seans from Seans_Bilgileri", "Seans");
        }

        private void Bos_Koltuklar()
        {
            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(55, 55);
                    btn.Location = new Point(j * 50 + 50, i * 50 + 50);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                    sayac++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click1;
                    btn.Leave += Btn_Leave;
                }
            }
        }

        

        private void Btn_Click1(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == Color.White)
            {
                textBox1.Text = b.Text;
            }
            b.BackColor = Color.Yellow;
            
        }
       private void Btn_Leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.White;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        DataSet1TableAdapters.Satis_BilgileriTableAdapter satis = new DataSet1TableAdapters.Satis_BilgileriTableAdapter();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            YenidenRenklendir();
            Veritabanı_Dolu_Koltuklar();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    satis.Satış_Yap(textBox1.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox2.Text, textBox3.Text, comboBox4.Text, DateTime.Now.ToString());
                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata oluştu" + hata.Message, "Uyarı");
                }
            }
            else
            {
                MessageBox.Show("Koltuk Seçimi Yapmadınız", "Uyarı");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            YenidenRenklendir();
            
            Veritabanı_Dolu_Koltuklar();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            YenidenRenklendir();
          
            Veritabanı_Dolu_Koltuklar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Kayıt Başarılı");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
    }
}
