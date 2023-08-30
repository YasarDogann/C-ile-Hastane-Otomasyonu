using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ozelHastanem
{
    public partial class bashekimPaneli : Form
    {
        public bashekimPaneli()
        {
            InitializeComponent();
        }

        private void bashekimPaneli_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "//resim//" + kullaniciGiris.tc + ".jpg");
            }
            catch
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "//resim//images.jpg");
            }
            label9.Text = kullaniciGiris.tc;
            label10.Text = kullaniciGiris.adi;
            label11.Text = kullaniciGiris.soyadi;
            label12.Text = kullaniciGiris.telefon;
            label13.Text = kullaniciGiris.adres;
            label14.Text = kullaniciGiris.brans;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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
                label4.ForeColor = Color.WhiteSmoke;
                label5.ForeColor = Color.WhiteSmoke;
                label6.ForeColor = Color.WhiteSmoke;
                label7.ForeColor = Color.WhiteSmoke;
                label8.ForeColor = Color.WhiteSmoke;
                label9.ForeColor = Color.WhiteSmoke;
                label10.ForeColor = Color.WhiteSmoke;
                label11.ForeColor = Color.WhiteSmoke;
                label12.ForeColor = Color.WhiteSmoke;
                label13.ForeColor = Color.WhiteSmoke;
                label14.ForeColor = Color.WhiteSmoke;
                label15.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                label1.ForeColor = Color.DimGray;
                label2.ForeColor = Color.DimGray;
                label3.ForeColor = Color.DimGray;
                label4.ForeColor = Color.DimGray;
                label5.ForeColor = Color.DimGray;
                label6.ForeColor = Color.DimGray;
                label7.ForeColor = Color.DimGray;
                label8.ForeColor = Color.DimGray;
                label9.ForeColor = Color.DimGray;
                label10.ForeColor = Color.DimGray;
                label11.ForeColor = Color.DimGray;
                label12.ForeColor = Color.DimGray;
                label13.ForeColor = Color.DimGray;
                label14.ForeColor = Color.DimGray;
                label15.ForeColor = Color.DimGray;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorBilgiler ac = new DoktorBilgiler();
            ac.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SekreterBilgiler ac = new SekreterBilgiler();
            ac.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult uyari;
            uyari = MessageBox.Show("Çıkmak İstediğinize Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (uyari == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kullaniciGiris ac = new kullaniciGiris();
            ac.Show();
            this.Hide();    
        }
    }
}
