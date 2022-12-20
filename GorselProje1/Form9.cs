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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        
        public static SqlConnection connection = new SqlConnection("Data Source =LAPTOP-NVKLLTFM\\SQLEXPRESS; Initial Catalog= proje1; Integrated Security=TRUE");
        DataTable tablo = new DataTable();
        private void SeansListesi(string sql)
        {
            connection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(sql, connection);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            connection.Close();

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("select *from Seans_Bilgileri where tarih like '" + dateTimePicker1.Text + "'");
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("select *from Seans_Bilgileri where tarih like '" + dateTimePicker1.Text + "'");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            SeansListesi("select *from Seans_Bilgileri");
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.ShowDialog();
        }
    }
}
