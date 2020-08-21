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
    public partial class ogrencimenu : Form
    {
        public ogrencimenu()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Stajyer_takip_Sistemi.mdb");
        DataTable tablo = new DataTable();
        string kaynakDosya = "", kaynakDosyaIsmi = "";
        string kaynakDosya2 = "", kaynakDosyaIsmi2 = "";
        string kaynakDosya3 = "", kaynakDosyaIsmi3 = "";
        private void textclear(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                if (item.Controls.Count > 0)
                {
                    textclear(item);
                }
            }
        }


        private void textpasif(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
                if (item.Controls.Count > 0)
                {
                    textpasif(item);
                }
            }
        }
        private void textaktif(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true; ;
                }
                if (item.Controls.Count > 0)
                {
                    textaktif(item);
                }
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            baglanti.Open(); //oğrenci nodan öğrenci ad soyad çektik
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM ogrenci where ogr_no = '" + labelOgrenciNumarasi.Text + "' ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            string ad = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string soyadad = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            labelOgrenciİsim.Text = ad + " " + soyadad;
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            pictureBox2.ImageLocation = dataGridView1.CurrentRow.Cells[13].Value.ToString();


            textBoxOgrAd.Text    = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxOgrNo.Text    =dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxOgrOkul.Text  = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxOgrSoyad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxOgrBolum.Text =dataGridView1.CurrentRow.Cells[5].Value.ToString();
           // dataGridView1.CurrentRow.Cells[6].Value.ToString();
           textBoxOgrOrt.Text   =  dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBoxOgrTel.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
           // dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBoxOgrEmaii.Text =  dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBoxOgrDanisman.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            //dataGridView1.CurrentRow.Cells[13].Value.ToString();
            //dataGridView1.CurrentRow.Cells[14].Value.ToString();


            OleDbCommand komut = new OleDbCommand();
            komut.CommandText = "SELECT kurum_adi from kurum";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxKurumAdi.Items.Add(dr["kurum_adi"]);
            }

            baglanti.Close();

            textBoxCV.Text = pictureBox2.ImageLocation;

            textBoxOgrEkrAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxOgrEkrNo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxOgrEkrOkulu.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxOgrEkrSoyadi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxOgrEkrBolumu.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBoxOgrEkrFakulte.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBoxOgrEkrNot.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBoxOgrEkrGsm.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBoxOgrEkrAdres.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBoxOgrEkrEmail.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBoxOgrEkraniDanismanSicil.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBoxOgrEkrSifre.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBoxOgrEkrCv.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBoxOgrEkrResim.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            textBoxOgrEkraniDanismanAdi.Text = textBoxDanismanAdi.Text;

            pictureBoxCv.ImageLocation = textBoxOgrEkrCv.Text;
            pictureBoxOgrenciResim.ImageLocation = textBoxOgrEkrResim.Text;

            baglanti.Open(); //oğrenci nodan öğrenci ad soyad çektik
            OleDbDataAdapter dakayitlimi = new OleDbDataAdapter("SELECT * FROM stajyer where ogr_no = '" + labelOgrenciNumarasi.Text + "' ", baglanti);
            DataTable tablokayitlimi = new DataTable();
            dakayitlimi.Fill(tablokayitlimi);
            dataGridView3.DataSource = tablokayitlimi;
            baglanti.Close();



            timer1.Enabled = false;
            

            
            if (dataGridView3.Rows[0].Cells[1].Value != null)
            {
                buttonstajYeriKaydet.Enabled = false;
                textBoxKurum.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString();
                comboBoxKurumAdi.Text = dataGridView3.CurrentRow.Cells[11].Value.ToString();
                textBoxKurumTel.Text = dataGridView3.CurrentRow.Cells[12].Value.ToString();
                textBoxKurumEmail.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString();
                MessageBox.Show("Kayıt İşleminizi Daha Önce Gerçekleştirdiniz. İptal Etmek İçin STAJ İPTAL Seçeneğini Seçiniz", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonCvGuncelle.Enabled = false;
                comboBoxKurumAdi.Enabled = false;
            }
            else
            {
                buttonStajİptal.Enabled = false;
                label7.Visible = false;
            }




            label7.Text = "Staj Yapacağınız Kurum : " + " " + comboBoxKurumAdi.Text;



        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Ogrencimenu_Load(object sender, EventArgs e)
        {
            //foreach (TabPage theTab in tabControl1.TabPages)
            //{
            //    Image img = Image.FromFile(@"img\arka2.png");
            //    tabControl1.TabPages[0].BackgroundImage = img;
            //    tabControl1.TabPages[1].BackgroundImage = img;
                

            //    tabControl1.TabPages[0].BackgroundImageLayout = ImageLayout.Stretch;
            //    tabControl1.TabPages[1].BackgroundImageLayout = ImageLayout.Stretch;
               


            //}
            timer1.Interval = 10;
            timer1.Enabled = true;
            baglanti.Open();

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM ogrenci where ogr_no = '" + labelOgrenciNumarasi.Text + "' ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

          // dataGridView1.Visible = false;
            label4.Text = DateTime.Now.ToLongDateString();

            //textpasif(this);
            textBoxOgrEkraniDanismanAdi.Enabled = false;
            textBoxOgrEkraniDanismanSicil.Enabled = false;
            
        }

        private void Ogrencimenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void TextBoxOgrDanisman_TextChanged(object sender, EventArgs e)
        {
            string sorgu = "SELECT hoca_adi  FROM hoca where sicil_no = '" + textBoxOgrDanisman.Text + "'";
            string deger;
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            deger = (string)komut.ExecuteScalar();
            baglanti.Close();
            //textBoxDanismanAdi.Text = deger;

            string sorgu2 = "SELECT hoca_soyadi  FROM hoca where sicil_no = '" + textBoxOgrDanisman.Text + "'";
            string deger2;
            OleDbCommand komut2 = new OleDbCommand(sorgu2, baglanti);
            baglanti.Open();
            deger2 = (string)komut2.ExecuteScalar();
            baglanti.Close();
            //textBoxDanismanAdi.Text = deger2;

            textBoxDanismanAdi.Text = deger + " " + deger2;

        }

        private void ComboBoxKurumAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu = "SELECT kurum_kodu  FROM kurum where kurum_adi = '" + comboBoxKurumAdi.Text + "'";
            string deger;
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            deger = (string)komut.ExecuteScalar();
            baglanti.Close();
            textBoxKurum.Text = deger;

            string sorgutel = "SELECT kurum_tel  FROM kurum where kurum_adi = '" + comboBoxKurumAdi.Text + "'";
            string degertel;
            OleDbCommand komuttel = new OleDbCommand(sorgutel, baglanti);
            baglanti.Open();
            degertel = (string)komuttel.ExecuteScalar();
            baglanti.Close();
            textBoxKurumTel.Text = degertel;

            string sorguposta = "SELECT kurum_eposta  FROM kurum where kurum_adi = '" + comboBoxKurumAdi.Text + "'";
            string degerposta;
            OleDbCommand komutposta = new OleDbCommand(sorguposta, baglanti);
            baglanti.Open();
            degerposta = (string)komutposta.ExecuteScalar();
            baglanti.Close();
            textBoxKurumEmail.Text = degerposta;

        }

   

        private void ButtonstajYeriKaydet_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show(comboBoxKurumAdi.Text + " " + "Kurumuna Kayıt Yaptırmak İstiyormusunu?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                string ekle = "insert into stajyer(ogr_no,ogr_ad,ogr_soyad,ogr_okul,ogr_bolum,ogr_tel,ogr_not,ogr_email,ogr_hoca,kurum_kodu,kurum_adi,kurum_tel,kurum_email,sicil_no,ogr_cv,ogr_resim) values (@ogrno,@ograd,@ogrsoyad,@ogrokul,@ogrbolum,@ogrtel,@ogrnotort,@ogremail,@ogrhoca,@kurumkodu,@kurumadi,@kurumtel,@kurumemail,@sicilno,@ogrcv,@ogrresim)";
                OleDbCommand komutt = new OleDbCommand(ekle, baglanti);
                komutt.Parameters.AddWithValue("@ogrno", textBoxOgrNo.Text);
                komutt.Parameters.AddWithValue("@ograd", textBoxOgrAd.Text);
                komutt.Parameters.AddWithValue("@ogrsoyad", textBoxOgrSoyad.Text);
                komutt.Parameters.AddWithValue("@ogrokul", textBoxOgrOkul.Text);
                komutt.Parameters.AddWithValue("@ogrbolum", textBoxOgrBolum.Text);
                komutt.Parameters.AddWithValue("@ogrtel", textBoxOgrTel.Text);
                komutt.Parameters.AddWithValue("@ogrnotort", textBoxOgrOrt.Text);
                komutt.Parameters.AddWithValue("@ogremail", textBoxOgrEmaii.Text);
                komutt.Parameters.AddWithValue("@ogrhoca", textBoxDanismanAdi.Text);
                komutt.Parameters.AddWithValue("@kurumkodu", textBoxKurum.Text);
                komutt.Parameters.AddWithValue("@kurumadi", comboBoxKurumAdi.Text);
                komutt.Parameters.AddWithValue("@kurumtel", textBoxKurumTel.Text);
                komutt.Parameters.AddWithValue("@kurumemail", this.textBoxKurumEmail.Text);
                komutt.Parameters.AddWithValue("@sicilno", textBoxOgrDanisman.Text);
                komutt.Parameters.AddWithValue("@ogrcv", textBoxCV.Text);
                komutt.Parameters.AddWithValue("@ogrresim", pictureBox1.ImageLocation);

                komutt.ExecuteNonQuery();
                MessageBox.Show("Kayıt Yapıldı");
                
                buttonstajYeriKaydet.Enabled = false;
                buttonStajİptal.Enabled = true;

                dataGridView3.DataSource = null;
                OleDbDataAdapter dakayitlimi = new OleDbDataAdapter("SELECT * FROM stajyer where ogr_no = '" + labelOgrenciNumarasi.Text + "' ", baglanti);
                DataTable tablokayitlimi = new DataTable();
                dakayitlimi.Fill(tablokayitlimi);
                dataGridView3.DataSource = tablokayitlimi;

                baglanti.Close();
                label7.Visible = true;
                label7.Text = "Staj Yapacağınız Kurum : " + " " + comboBoxKurumAdi.Text;
            }
            else
            {
                MessageBox.Show("İşlem Yapılmadı");
            }
        }

        private void ButtonOgrencciguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string guncelle = "update ogrenci set ogr_ad = @ograd, ogr_soyad =@ogrsoyad, ogr_no= @ogrno, ogr_okul=@ogrokul, ogr_bolum=@ogrbolum, ogr_fakulte=@ogrfakulte, ogr_not_ort=@ogrnot, ogr_tel=@ogrtel, ogr_adres=@ogradres, ogr_email=@ogremail, sicil_no=@sicil_no, ogr_sifre=@ogrsifre, ogr_cv=@ogrcv, ogr_resimi=ogrresimi where ogr_no=@ogrno";
                OleDbCommand komutt = new OleDbCommand(guncelle, baglanti);
                komutt.Parameters.AddWithValue("@ograd", textBoxOgrEkrAdi.Text);
                komutt.Parameters.AddWithValue("@ogrsoyad", textBoxOgrEkrSoyadi.Text);
                komutt.Parameters.AddWithValue("@ogrno", textBoxOgrEkrNo.Text);
                komutt.Parameters.AddWithValue("@ogrokul", textBoxOgrEkrOkulu.Text);
                komutt.Parameters.AddWithValue("@ogrbolum", textBoxOgrEkrBolumu.Text);
                komutt.Parameters.AddWithValue("@ogrfakulte", textBoxOgrEkrFakulte.Text);
                komutt.Parameters.AddWithValue("@ogrnotort", textBoxOgrEkrNot.Text);
                komutt.Parameters.AddWithValue("@ogrtel", textBoxOgrEkrGsm.Text);
                komutt.Parameters.AddWithValue("@ogradres", textBoxOgrEkrAdres.Text);
                komutt.Parameters.AddWithValue("@ogremail", textBoxOgrEkrEmail.Text);
                komutt.Parameters.AddWithValue("@sicilno", textBoxOgrEkraniDanismanSicil.Text);
                komutt.Parameters.AddWithValue("@ogrsifre", textBoxOgrEkrSifre.Text);
                komutt.Parameters.AddWithValue("@ogrcv", textBoxOgrEkrCv.Text);
                komutt.Parameters.AddWithValue("@ogrresimi", textBoxOgrEkrResim.Text);
                komutt.Parameters.AddWithValue("@ogrno", labelOgrenciNumarasi.Text);
                komutt.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();

                string guncelle2 = "update stajyer set ogr_no=@ogrno, ogr_ad = @ograd,ogr_soyad =@ogrsoyad,ogr_okul = @ogrokul,ogr_bolum = @ogrbolum, ogr_tel = @ogrtel,ogr_not = @ogrnot,ogr_email = @ogremail,ogr_hoca=@ogrhoca, kurum_kodu=@kurumkodu,kurum_adi=@kurumadi, kurum_tel=@kurumtel, kurum_email=@kurumemail,sicil_no = @sicil_no, ogr_cv = @ogrcv,ogr_resim =@ogrresimi   where ogr_no=@ogrno";
                OleDbCommand komut2t = new OleDbCommand(guncelle2, baglanti);
                komut2t.Parameters.AddWithValue("@ogrno", textBoxOgrEkrNo.Text);
                komut2t.Parameters.AddWithValue("@ograd", textBoxOgrEkrAdi.Text);
                komut2t.Parameters.AddWithValue("@ogrsoyad", textBoxOgrEkrSoyadi.Text);
                komut2t.Parameters.AddWithValue("@ogrokul", textBoxOgrEkrOkulu.Text);
                komut2t.Parameters.AddWithValue("@ogrbolum", textBoxOgrEkrBolumu.Text);
                komut2t.Parameters.AddWithValue("@ogrtel", textBoxOgrEkrGsm.Text);
                komut2t.Parameters.AddWithValue("@ogrnot", textBoxOgrEkrNot.Text);
                komut2t.Parameters.AddWithValue("@ogremail", textBoxOgrEkrEmail.Text);
                komut2t.Parameters.AddWithValue("@ogrhoca", textBoxOgrEkraniDanismanAdi.Text);
                komut2t.Parameters.AddWithValue("@kurumkodu", textBoxKurum.Text);
                komut2t.Parameters.AddWithValue("@kurumadi", comboBoxKurumAdi.Text);
                komut2t.Parameters.AddWithValue("@kurumtel", textBoxKurumTel.Text);
                komut2t.Parameters.AddWithValue("@kurumemail", textBoxKurumEmail.Text);
                komut2t.Parameters.AddWithValue("@sicilno", textBoxOgrEkraniDanismanSicil.Text);
                komut2t.Parameters.AddWithValue("@ogrcv", textBoxOgrEkrCv.Text);
                komut2t.Parameters.AddWithValue("@ogrresimi", textBoxOgrEkrResim.Text);
                komut2t.Parameters.AddWithValue("@ogrno", labelOgrenciNumarasi.Text);

                komut2t.ExecuteNonQuery();

                baglanti.Close();


                MessageBox.Show("Güncelleme Tamam Uygulama 5 Saniye İçerisinde Oturumunuzu Kapatacaktır.");
                timer2.Enabled = true;

            }
            catch 
            {
                MessageBox.Show("hata");

            }
           

           

        }

        private void ComboBoxKurumAdi_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sorgu = "SELECT kurum_kodu  FROM kurum where kurum_adi = '" + comboBoxKurumAdi.Text + "'";
            string deger;
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            deger = (string)komut.ExecuteScalar();
            baglanti.Close();
            textBoxKurum.Text = deger;

            string sorgutel = "SELECT kurum_tel  FROM kurum where kurum_adi = '" + comboBoxKurumAdi.Text + "'";
            string degertel;
            OleDbCommand komuttel = new OleDbCommand(sorgutel, baglanti);
            baglanti.Open();
            degertel = (string)komuttel.ExecuteScalar();
            baglanti.Close();
            textBoxKurumTel.Text = degertel;

            string sorguposta = "SELECT kurum_eposta  FROM kurum where kurum_adi = '" + comboBoxKurumAdi.Text + "'";
            string degerposta;
            OleDbCommand komutposta = new OleDbCommand(sorguposta, baglanti);
            baglanti.Open();
            degerposta = (string)komutposta.ExecuteScalar();
            baglanti.Close();
            textBoxKurumEmail.Text = degerposta;
        }

        private void TextBoxOgrDanisman_TextChanged_1(object sender, EventArgs e)
        {
            string sorgu = "SELECT hoca_adi  FROM hoca where sicil_no = '" + textBoxOgrDanisman.Text + "'";
            string deger;
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            deger = (string)komut.ExecuteScalar();
            baglanti.Close();
            //textBoxDanismanAdi.Text = deger;

            string sorgu2 = "SELECT hoca_soyadi  FROM hoca where sicil_no = '" + textBoxOgrDanisman.Text + "'";
            string deger2;
            OleDbCommand komut2 = new OleDbCommand(sorgu2, baglanti);
            baglanti.Open();
            deger2 = (string)komut2.ExecuteScalar();
            baglanti.Close();
            //textBoxDanismanAdi.Text = deger2;

            textBoxDanismanAdi.Text = deger + " " + deger2;
        }

        private void ButtonStajİptal_Click(object sender, EventArgs e)
        {
            if (comboBoxKurumAdi.Text!=null)
            {
                DialogResult c;
                c = MessageBox.Show(comboBoxKurumAdi.Text + " " + "İsimli Kurumdan Staj İşleminizi İptal Etmek İstiyormusunuz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    baglanti.Open();
                    string kurumsil = "Delete from stajyer where ogr_no =@ogrno";
                    OleDbCommand komutt = new OleDbCommand(kurumsil, baglanti);
                    komutt.Parameters.AddWithValue("@ogrno", labelOgrenciNumarasi.Text);
                    komutt.ExecuteNonQuery();
                    MessageBox.Show("Staj İşlemi İptal Edildi");
                    dataGridView3.DataSource = null;
                    OleDbDataAdapter dakayitlimi = new OleDbDataAdapter("SELECT * FROM stajyer where ogr_no = '" + labelOgrenciNumarasi.Text + "' ", baglanti);
                    DataTable tablokayitlimi = new DataTable();
                    dakayitlimi.Fill(tablokayitlimi);
                    dataGridView3.DataSource = tablokayitlimi;

                    baglanti.Close();

                    buttonStajİptal.Enabled = false;
                    buttonstajYeriKaydet.Enabled = true;
                    comboBoxKurumAdi.Text = null;
                    comboBoxKurumAdi.Enabled = true;
                    label7.Visible = false;
                    buttonCvGuncelle.Enabled = true;

                }
            }
            else
            {
                MessageBox.Show("Kurum Seç");
            }
            
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Application.Restart();
            timer2.Enabled = false;
        }

        private void GroupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void ButtonCık_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            if (textBoxOgrEkrSifre.PasswordChar == '*')
            {

                textBoxOgrEkrSifre.PasswordChar = '\0';
            }
            else
            {
                textBoxOgrEkrSifre.PasswordChar = '*';
            }
        }

        private void ButtonOgrFotoYukle_Click(object sender, EventArgs e)
        {
            openFileDialog3.Title = "Yüklenecek Dosyayı Seçiniz...";
            openFileDialog3.FileName = "";
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                kaynakDosyaIsmi3 = textBoxOgrEkrNo.Text + "__" + openFileDialog3.SafeFileName.ToString();
                kaynakDosya3 = openFileDialog3.FileName.ToString();
                textBoxOgrEkrResim.Text = kaynakDosya3;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (labelKopyaKonum2.Text != "" && kaynakDosya3 != "")
            {
                if (File.Exists(labelKopyaKonum2.Text + "\\" + kaynakDosyaIsmi3))
                {
                    MessageBox.Show("Belirtilen klasörde " + kaynakDosyaIsmi3 + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(kaynakDosya3, labelKopyaKonum2.Text + "\\" + kaynakDosyaIsmi3);
                    MessageBox.Show("Dosya Kopyalama İşlemi Başarılı", "Dosya Kopyalandı...");
                }

                textBoxOgrEkrResim.Text = @"img\ogr_resim\" + kaynakDosyaIsmi3;
                pictureBoxOgrenciResim.ImageLocation = @"img\ogr_resim\" + kaynakDosyaIsmi3;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
        }

        private void ButtonCvYukle_Click(object sender, EventArgs e)
        {
            openFileDialog2.Title = "Yüklenecek Dosyayı Seçiniz...";
            openFileDialog2.FileName = "";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakDosyaIsmi2 = labelOgrenciNumarasi.Text + "__" + openFileDialog2.SafeFileName.ToString();
                kaynakDosya2 = openFileDialog2.FileName.ToString();
                textBoxCV.Text = kaynakDosya2;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (labelKopyaKonum.Text != "" && kaynakDosya2 != "")
            {
                if (File.Exists(labelKopyaKonum.Text + "\\" + kaynakDosyaIsmi2))
                {
                    MessageBox.Show("Belirtilen klasörde " + kaynakDosyaIsmi2 + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(kaynakDosya2, labelKopyaKonum.Text + "\\" + kaynakDosyaIsmi2);
                    MessageBox.Show("Dosya Kopyalama İşlemi Başarılı", "Dosya Kopyalandı...");
                }

            }

            textBoxOgrEkrCv.Text = @"img\ogr_cv\" + kaynakDosyaIsmi2;
            pictureBoxCv.ImageLocation = @"img\ogr_cv\" + kaynakDosyaIsmi2;
        }

        private void ButtonCvGuncelle_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Yüklenecek Dosyayı Seçiniz...";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakDosyaIsmi = labelOgrenciNumarasi.Text + "__" + openFileDialog1.SafeFileName.ToString();
                kaynakDosya = openFileDialog1.FileName.ToString();
                textBoxCV.Text = kaynakDosya;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (labelKopyaKonum.Text != "" && kaynakDosya != "")
            {
                if (File.Exists(labelKopyaKonum.Text + "\\" + kaynakDosyaIsmi))
                {
                    MessageBox.Show("Belirtilen klasörde " + kaynakDosyaIsmi + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(kaynakDosya, labelKopyaKonum.Text + "\\" + kaynakDosyaIsmi);
                    MessageBox.Show("Dosya Kopyalama İşlemi Başarılı", "Dosya Kopyalandı...");
                }

            }

            textBoxCV.Text = @"img\ogr_cv\" + kaynakDosyaIsmi;
            pictureBox2.ImageLocation = @"img\ogr_cv\" + kaynakDosyaIsmi;

            baglanti.Open();
            string guncelle = "update ogrenci set ogr_cv=@ogrcv where ogr_no=@ogrno";
            OleDbCommand komutt = new OleDbCommand(guncelle, baglanti);

            komutt.Parameters.AddWithValue("@ogrcv", textBoxCV.Text);

            komutt.Parameters.AddWithValue("@ogrno", labelOgrenciNumarasi.Text);


            komutt.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Tamam");
            baglanti.Close();


            textBoxOgrEkrCv.Text = textBoxCV.Text;

            pictureBoxCv.ImageLocation = textBoxOgrEkrCv.Text;
        }
    }
    
}
