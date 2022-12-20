using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GorselProje1
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Satis_BilgileriTableAdapter satislistesi = new DataSet1TableAdapters.Satis_BilgileriTableAdapter();
        private void Form11_Load(object sender, EventArgs e)
        {
            ToplamUcretHesapla();
        }

        private void ToplamUcretHesapla()
        {
            int ucrettoplami = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ucrettoplami += Convert.ToInt32(dataGridView1.Rows[i].Cells["Ucret"].Value);
            }

            label1.Text = "Toplam Satış=" + ucrettoplami + "TL";
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislistesi.SatışListesi2();
            ToplamUcretHesapla();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.ShowDialog();
        }
    }
}
