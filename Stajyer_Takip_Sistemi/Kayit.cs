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

namespace Stajyer_Takip_Sistemi
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int RastgeleSayi1;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (
               textBoxSicilNo.Text == "" || textBoxAdınız.Text == "" || textBoxSoyadınız.Text == "" || textBoxTelofon.Text == "" || textBoxEposta.Text == "" || textBoxBolum.Text == "" || textBoxAlan.Text == "" || textBoxFotograf.Text == "" || textBoxSifre.Text == "" || textBoxSifreTekrar.Text == "" || comboBoxGuvenlikSorusu.Text == "" || textBoxGuvenlikCevabı.Text == "" || textBoxDogrulamaKodu.Text == ""
               )





                {
                    MessageBox.Show("Boş Alan Olamaz");
                    int RastgeleSayi1 = rnd.Next(1111, 9999);
                    label13.Text = RastgeleSayi1.ToString();
                    textBoxDogrulamaKodu.Text = "";

                }
                if (textBoxSifre.Text != textBoxSifreTekrar.Text)
                {
                    MessageBox.Show("Şifreler Uyuşmuyor");
                    int RastgeleSayi1 = rnd.Next(1111, 9999);
                    label13.Text = RastgeleSayi1.ToString();
                    textBoxDogrulamaKodu.Text = "";
                }
                if (label13.Text != textBoxDogrulamaKodu.Text)
                {
                    MessageBox.Show("Doğrulama Kodu Hatalı");
                    int RastgeleSayi1 = rnd.Next(1111, 9999);
                    label13.Text = RastgeleSayi1.ToString();
                    textBoxDogrulamaKodu.Text = "";
                }
                else
                {

                    baglanti.Open();
                    string ekle = "insert into hoca(sicil_no,hoca_adi,hoca_soyadi,hoca_tel,hoca_eposta,hoca_sifre,hoca_bolum,hoca_alan,hoca_resim,soru) values (@sicilno,@hocaadi,@hocasoyadi,@hocatel,@hocaemail,@hocasifre,@hocabolum,@hocaalan,@hocaresim,@soru)";
                    OleDbCommand komutt = new OleDbCommand(ekle, baglanti);
                    komutt.Parameters.AddWithValue("@sicilno", textBoxSicilNo.Text);
                    komutt.Parameters.AddWithValue("@hocaadi", textBoxAdınız.Text);
                    komutt.Parameters.AddWithValue("@hocasoyadi", textBoxSoyadınız.Text);
                    komutt.Parameters.AddWithValue("@hocatel", textBoxTelofon.Text);
                    komutt.Parameters.AddWithValue("@hocaemail", textBoxEposta.Text);
                    komutt.Parameters.AddWithValue("@hocasifre", textBoxSifre.Text);
                    komutt.Parameters.AddWithValue("@hocabolum", textBoxBolum.Text);
                    komutt.Parameters.AddWithValue("@hocaalan", textBoxAlan.Text);
                    komutt.Parameters.AddWithValue("@hocaresim", textBoxFotograf.Text);

                    komutt.Parameters.AddWithValue("@soru", textBoxGuvenlikCevabı.Text);


                    komutt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Yapıldı");

                    baglanti.Close();



                }
            }
            catch 
            {

                MessageBox.Show("hata");
            }
           
           
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Stajyer_takip_Sistemi.mdb");

        private void Kayit_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int RastgeleSayi1 = rnd.Next(1111, 9999);
            label13.Text = RastgeleSayi1.ToString();


            OleDbCommand komut = new OleDbCommand();
            komut.CommandText = "SELECT Güvenlik_Sorulari from GuvenlikSorulari";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxGuvenlikSorusu.Items.Add(dr["Güvenlik_Sorulari"]);
            }

            baglanti.Close();

        }
        string kaynakDosya2 = "", kaynakDosyaIsmi2 = "";
        private void ButtonOgrFotoYukle_Click(object sender, EventArgs e)
        {
            openFileDialog2.Title = "Yüklenecek Dosyayı Seçiniz...";
            openFileDialog2.FileName = "";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakDosyaIsmi2 = textBoxSicilNo.Text + "__" + openFileDialog2.SafeFileName.ToString();
                kaynakDosya2 = openFileDialog2.FileName.ToString();
                textBoxFotograf.Text = kaynakDosya2;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (label15.Text != "" && kaynakDosya2 != "")
            {
                if (File.Exists(label15.Text + "\\" + kaynakDosyaIsmi2))
                {
                    MessageBox.Show("Belirtilen klasörde " + kaynakDosyaIsmi2 + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(kaynakDosya2, label15.Text + "\\" + kaynakDosyaIsmi2);
                    MessageBox.Show("Dosya Kopyalama İşlemi Başarılı", "Dosya Kopyalandı...");
                }

                textBoxFotograf.Text = @"img\hoca_resim\" + kaynakDosyaIsmi2;
                pictureBoxOgrenciResim.ImageLocation = @"img\hoca_resim\" + kaynakDosyaIsmi2;

            }
        }
    }
}
