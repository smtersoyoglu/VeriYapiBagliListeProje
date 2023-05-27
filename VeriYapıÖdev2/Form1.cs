using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriYapıÖdev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class ürünler
        {
            public int kod;
            public string ad;
            public double fiyat;
            public ürünler sonraki;
            public ürünler önceki;
            

            public ürünler (int kod , string ad, double fiyat)
            {
                this.kod = kod;
                this.ad = ad;  
                this.fiyat = fiyat;
                this.önceki = null;
                this.sonraki = null;
            }
        }

        private ürünler ilk;
        private ürünler son;

        public Boolean bosMu()
        {
            return ilk == null;
        }

        public void sonaEkle (int kod, string ad, double fiyat)
        {
            ürünler yeniDugum = new ürünler(kod, ad, fiyat);
            if (bosMu())
                ilk = yeniDugum;
            else
                son.sonraki = yeniDugum;

            yeniDugum.önceki = son;
            son = yeniDugum;            
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkle1.Text== "" || txtEkle2.Text == "" || txtEkle3.Text == "" )
            {
                MessageBox.Show("Lütfen Ürünün Kodunu, Adını ve Fiyatını Giriniz. Boş Geçilemez !");
            }
            else
            {
                int kod = Convert.ToInt32(txtEkle1.Text);
                string ad = txtEkle2.Text;
                double fiyat = Convert.ToDouble(txtEkle3.Text); 
                sonaEkle (kod, ad, fiyat);
                txtEkle1.Clear();
                txtEkle2.Clear();
                txtEkle3.Clear();
            }

        }
        public void ürünYazdir()
        {
            dataGridView1.Rows.Clear();

        } 
    }
}
