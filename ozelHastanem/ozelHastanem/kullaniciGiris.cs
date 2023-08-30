using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Reflection.Emit;

namespace ozelHastanem
{
    public partial class kullaniciGiris : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = kullanici.accdb");
        public static string tc, adi, soyadi, telefon, adres, yetki, brans;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rjToggleButton1.Checked)
            {
                this.BackColor = Color.DimGray;
                label1.ForeColor = Color.WhiteSmoke;
                label2.ForeColor = Color.WhiteSmoke;
                label3.ForeColor = Color.WhiteSmoke;
               
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                label1.ForeColor = Color.DimGray;
                label2.ForeColor = Color.DimGray;
                label3.ForeColor = Color.DimGray;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult uyari;
            uyari = MessageBox.Show("Çıkmak İstediğinize Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (uyari == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void kullaniciGiris_Load(object sender, EventArgs e)
        {

        }

        bool drmkontrol = false;
        public kullaniciGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand bashekim_sorgu = new OleDbCommand("select * from bashekim", baglanti);
            OleDbDataReader bashekim_oku = bashekim_sorgu.ExecuteReader();
            OleDbCommand doktor_sorgu = new OleDbCommand("select * from doktor", baglanti);
            OleDbDataReader doktor_oku = doktor_sorgu.ExecuteReader();
            OleDbCommand sekreter_sorgu = new OleDbCommand("select * from sekreter", baglanti);
            OleDbDataReader sekreter_oku = sekreter_sorgu.ExecuteReader();
            
            

            while (bashekim_oku.Read() == true)
            {
                if (bashekim_oku["adi"].ToString() == textBox1.Text && bashekim_oku["sifre"].ToString() == textBox2.Text && bashekim_oku["yetki"].ToString() == "Başhekim")
                {
                    drmkontrol = true;
                    tc = bashekim_oku.GetValue(0).ToString();
                    adi = bashekim_oku.GetValue(1).ToString();
                    soyadi = bashekim_oku.GetValue(2).ToString();
                    telefon = bashekim_oku.GetValue(3).ToString();
                    adres = bashekim_oku.GetValue(4).ToString();
                    yetki = bashekim_oku.GetValue(5).ToString();
                    brans = bashekim_oku.GetValue(6).ToString();
                    bashekimPaneli ac = new bashekimPaneli();
                    ac.Show();
                    this.Hide();
                    break;
                } 
            }
            while (doktor_oku.Read() == true)
            {
                if (doktor_oku["adi"].ToString() == textBox1.Text && doktor_oku["sifre"].ToString() == textBox2.Text && doktor_oku["yetki"].ToString() == "Doktor")
                {
                    drmkontrol = true;
                    tc = doktor_oku.GetValue(0).ToString();
                    adi = doktor_oku.GetValue(1).ToString();
                    soyadi = doktor_oku.GetValue(2).ToString();
                    telefon = doktor_oku.GetValue(3).ToString();
                    adres = doktor_oku.GetValue(4).ToString();
                    yetki = doktor_oku.GetValue(5).ToString();
                    brans = doktor_oku.GetValue(6).ToString();
                    doktorPaneli ac = new doktorPaneli();
                    ac.Show();
                    this.Hide();
                    break;
                }
            }
            while (sekreter_oku.Read() == true) {
                if (sekreter_oku["adi"].ToString() == textBox1.Text && sekreter_oku["sifre"].ToString() == textBox2.Text && sekreter_oku["yetki"].ToString() == "Tıbbi Sekreter")
                {
                    drmkontrol = true;
                    tc = sekreter_oku.GetValue(0).ToString();
                    adi = sekreter_oku.GetValue(1).ToString();
                    soyadi = sekreter_oku.GetValue(2).ToString();
                    telefon = sekreter_oku.GetValue(3).ToString();
                    adres = sekreter_oku.GetValue(4).ToString();
                    yetki = sekreter_oku.GetValue(5).ToString();
                    brans = sekreter_oku.GetValue(6).ToString();
                    sekreterPaneli ac = new sekreterPaneli();
                    ac.Show();
                    this.Hide();
                    break;
                }
            }
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş geçilemez!");
            }
            else if (drmkontrol == false)
            {
                MessageBox.Show("Böyle bir kullanıcı veri tabanında kayıtlı değildir");
            }
            baglanti.Close();


        }       
    }
}

