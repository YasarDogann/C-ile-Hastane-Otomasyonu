using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ozelHastanem
{
    public partial class SekreterBilgiler : Form
    {
        public SekreterBilgiler()
        {
            InitializeComponent();
        }
        private void listele()
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = " + Application.StartupPath + "\\kullanici.accdb");
            DataTable tablo = new DataTable();
            tablo.Clear();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from sekreter", baglan);
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void SekreterBilgiler_Load(object sender, EventArgs e)
        {
            label9.Visible = false;
            textBox9.Visible = false;
            button6Kaydet.Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void button1Listele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2Ekle_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != ""
                && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "" && textBox8.Text.Trim() != "")
            {
                OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = " + Application.StartupPath + "\\kullanici.accdb");
                OleDbCommand kmt = new OleDbCommand("INSERT INTO sekreter(tc,adi,soyadi,telefon,adres,yetki,brans,sifre) Values ('" + textBox1.Text + "','" + textBox2.Text + "'," +
                    "'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", baglan);
                baglan.Open();
                kmt.ExecuteNonQuery();
                baglan.Close();
                listele();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakamazsınız...");
            }
        }

        private void button3Sil_Click(object sender, EventArgs e)
        {
            DialogResult uyari;
            uyari = MessageBox.Show("Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (uyari == DialogResult.Yes)
            {
                OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = " + Application.StartupPath + "\\kullanici.accdb");
                OleDbCommand kmt = new OleDbCommand("DELETE FROM sekreter Where tc='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglan);
                baglan.Open(); kmt.ExecuteNonQuery(); baglan.Close(); listele();
            }
        }

        private void button4Guncelle_Click(object sender, EventArgs e)
        {
            button6Kaydet.Visible = true;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button6Kaydet_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != ""
               && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "" && textBox8.Text.Trim() != "")
            {
                OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = " + Application.StartupPath + "\\kullanici.accdb");
                OleDbCommand kmt = new OleDbCommand("UPDATE sekreter SET tc='" + textBox1.Text + "',adi='" + textBox2.Text + "',soyadi='" + textBox3.Text + "',telefon='" + textBox4.Text + "'," +
                    "adres='" + textBox5.Text + "',yetki='" + textBox6.Text + "',brans='" + textBox7.Text + "',sifre='" + textBox8.Text + "' where tc ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglan);
                baglan.Open(); kmt.ExecuteNonQuery(); baglan.Close(); listele();
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = ""; textBox8.Text = "";
                button6Kaydet.Visible = false;
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakamazsınız...");
            }
        }

        private void button5Arama_Click(object sender, EventArgs e)
        {
            textBox9.Visible = true;
            label9.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bashekimPaneli ac = new bashekimPaneli();
            ac.Show();
            this.Hide();
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
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Trim() == "") { listele(); }
            else
            {
                OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = " + Application.StartupPath + "\\kullanici.accdb");
                DataTable tablo = new DataTable();
                tablo.Clear();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM sekreter where tc like '%" + textBox9.Text + "%'", baglan);
                adapter.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source = " + Application.StartupPath + "\\kullanici.accdb");
            baglan.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM sekreter ", baglan);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);

            string csvFilePath = "Sekreter-Başhekim-Bilgileri.csv";
            StringBuilder stringBuilder = new StringBuilder();

            foreach (DataColumn column in tablo.Columns)
            {
                stringBuilder.Append(column.ColumnName + ",");
            }
            stringBuilder.AppendLine();


            foreach (DataRow row in tablo.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    stringBuilder.Append(item.ToString() + ",");
                }
                stringBuilder.AppendLine();
            }

            File.WriteAllText(csvFilePath, stringBuilder.ToString());
            MessageBox.Show("Çıktı başarıyla alındı ve " + csvFilePath + " dosyasına kaydedildi");
        }
    }
}
