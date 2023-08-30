﻿using System;
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
    public partial class doktorPaneli : Form
    {
        public doktorPaneli()
        {
            InitializeComponent();
        }

        private void doktorPaneli_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            HastaDoktorBilgi ac = new HastaDoktorBilgi();
            ac.Show();
            this.Hide();
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
    }
}
