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
    public partial class kurummenu : Form
    {
        public kurummenu()
        {
            InitializeComponent();
        }
        int buyumeMiktari = 100;

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Stajyer_takip_Sistemi.mdb");
        DataTable tablo = new DataTable();
        DataTable tablostara = new DataTable();
        DataTable tablostara2 = new DataTable();
        DataTable tablostara3 = new DataTable();
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

        private void Kurummenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            baglanti.Close();


        }

        private void Kurummenu_Load(object sender, EventArgs e)
        {
            //foreach (TabPage theTab in tabControl1.TabPages)
            //{
            //    Image img = Image.FromFile(@"img\arka2.png");
            //    tabControl1.TabPages[0].BackgroundImage = img;
            //    tabControl1.TabPages[1].BackgroundImage = img;
                

            //    tabControl1.TabPages[0].BackgroundImageLayout = ImageLayout.Stretch;
            //    tabControl1.TabPages[1].BackgroundImageLayout = ImageLayout.Stretch;
                
            //    break;



            //}
            baglanti.Open();
            timer1.Interval = 10;
            timer1.Enabled = true;
            

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM kurum where kurum_kodu = '" + labelKurumKodu.Text + "' ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
          
           
            dataGridView1.Visible = false;
            label4.Text = DateTime.Now.ToLongDateString();
            this.dataGridViewKurumumdakiStajyerler.DefaultCellStyle.Font = new Font("Times New Roman", 12);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //kurum kodlu giriştenn kurum adını çektik
            //sicil nosundan hocanın adını ve soyadını çektik
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM kurum where kurum_kodu = '" + labelKurumKodu.Text + "' ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
           
            string ad = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            labellabelKurumAdi.Text = ad;
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[9].Value.ToString();


            //kurum kodundan girişli stajyerleri çektik
            OleDbDataAdapter stajyer = new OleDbDataAdapter("SELECT * FROM stajyer where kurum_kodu = '" + labelKurumKodu.Text + "' ", baglanti);
            DataTable tablostajyer = new DataTable();
            stajyer.Fill(tablostajyer);
            dataGridViewKurumumdakiStajyerler.DataSource = tablostajyer;
            

            
            OleDbDataAdapter tumkurmlar = new OleDbDataAdapter("SELECT * from kurum where kurum_kodu = '" + labelKurumKodu.Text + "' ", baglanti);
            DataTable tablotumkurumlar = new DataTable();
            tumkurmlar.Fill(tablotumkurumlar);
            dataGridViewTumKurumlar.DataSource = tablotumkurumlar;

           

            timer1.Enabled = false;
        }

        private void ButtonCık_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
        }

        private void DataGridViewKurumumdakiStajyerler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewKurumumdakiStajyerler_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBoxOgrNo.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[1].Value.ToString();
            textBoxOgrAd.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[2].Value.ToString();
            textBoxOgrSoyad.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[3].Value.ToString();
            textBoxOgrOkul.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[4].Value.ToString();
            textBoxOgrBolum.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[5].Value.ToString();
            textBoxOgrTel.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[6].Value.ToString();
            textBoxOgrOrt.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[7].Value.ToString();
            textBoxOgrEmaii.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[8].Value.ToString();
            textBoxOgrDanisman.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[9].Value.ToString();
          //  textBoxKurum.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[10].Value.ToString();
            textBoxKurumAdi.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[11].Value.ToString();
           // textBoxKurumTel.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[12].Value.ToString();
           // textBoxKurumEmail.Text = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[13].Value.ToString();
            pictureBox2.ImageLocation = dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[16].Value.ToString();
        }

        private void ButtonTemizle_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewKurumumdakiStajyerler.DataSource = null; ;
                //kurum kodundan girişli stajyerleri çektik
                OleDbDataAdapter stajyer = new OleDbDataAdapter("SELECT * FROM stajyer where kurum_kodu = '" + labelKurumKodu.Text + "' ", baglanti);
                DataTable tablostajyer = new DataTable();
                stajyer.Fill(tablostajyer);
                dataGridViewKurumumdakiStajyerler.DataSource = tablostajyer;

                dataGridViewKurumumdakiStajyerler.Columns[0].HeaderText = "Stajyer id";
                dataGridViewKurumumdakiStajyerler.Columns[1].HeaderText = "No";
                dataGridViewKurumumdakiStajyerler.Columns[2].HeaderText = "Adı";
                dataGridViewKurumumdakiStajyerler.Columns[3].HeaderText = "Soyadı";
                dataGridViewKurumumdakiStajyerler.Columns[4].HeaderText = "Okul";
                dataGridViewKurumumdakiStajyerler.Columns[5].HeaderText = "Bölüm";
                dataGridViewKurumumdakiStajyerler.Columns[6].HeaderText = "Öğrenci Telefon";
                dataGridViewKurumumdakiStajyerler.Columns[7].HeaderText = "Not Ort.";
                dataGridViewKurumumdakiStajyerler.Columns[8].HeaderText = "Öğrenci E-Posta";
                dataGridViewKurumumdakiStajyerler.Columns[9].HeaderText = "Danışman";
                dataGridViewKurumumdakiStajyerler.Columns[10].HeaderText = "Kurum Kodu";
                dataGridViewKurumumdakiStajyerler.Columns[11].HeaderText = "Kurum Adı";
                dataGridViewKurumumdakiStajyerler.Columns[12].HeaderText = "Kurum Tel";
                dataGridViewKurumumdakiStajyerler.Columns[13].HeaderText = "Kurum E-Posta";
                dataGridViewKurumumdakiStajyerler.Columns[14].Visible = false;
            }
            catch 
            {

                MessageBox.Show("hata");
            }
           

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textclear(this);
               // textpasif(this);
                textBoxOgrNo.Enabled = true;
                textBoxOgrNo.Focus();
            }
        }

        private void RadioButtonOgrAd_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOgrAd.Checked == true)
            {
                textclear(this);
               // textpasif(this);
                textBoxOgrAd.Enabled = true;
                textBoxOgrAd.Focus();
            }
        }

        private void RadioButtonOgrSoyad_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOgrSoyad.Checked == true)
            {
                textclear(this);
                //textpasif(this);
                textBoxOgrSoyad.Enabled = true;
                textBoxOgrSoyad.Focus();
            }
        }

        private void ButtonStajyerAra_Click(object sender, EventArgs e)
        {

            textaktif(this);
            radioButtonOgrSoyad.Checked = false;
            if (textBoxOgrNo.Text != "")
            {
                dataGridViewKurumumdakiStajyerler.DataSource = null;
                tablostara.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from stajyer where kurum_kodu = '" + labelKurumKodu.Text + "'  and  ogr_no LIKE '%" + textBoxOgrNo.Text + "%'", baglanti);
                adtr.Fill(tablostara);
                dataGridViewKurumumdakiStajyerler.DataSource = tablostara;
               
            }


            if (textBoxOgrAd.Text != "")
            {
                dataGridViewKurumumdakiStajyerler.DataSource = null;
                tablostara2.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from stajyer where kurum_kodu = '" + labelKurumKodu.Text + "'  and  ogr_ad LIKE '%" + textBoxOgrAd.Text + "%'", baglanti);
                adtr.Fill(tablostara2);
                dataGridViewKurumumdakiStajyerler.DataSource = tablostara2;
                radioButton1.Checked = false;
            }

            if (textBoxOgrSoyad.Text != "")
            {
                dataGridViewKurumumdakiStajyerler.DataSource = null;
                tablostara3.Clear();

                OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from stajyer where kurum_kodu = '" + labelKurumKodu.Text + "'  and  ogr_soyad LIKE '%" + textBoxOgrSoyad.Text + "%'", baglanti);
                adtr.Fill(tablostara3);
                dataGridViewKurumumdakiStajyerler.DataSource = tablostara3;
                radioButtonOgrAd.Checked = false;

            }

           
            

            dataGridViewKurumumdakiStajyerler.Columns[0].HeaderText = "Stajyer id";
            dataGridViewKurumumdakiStajyerler.Columns[1].HeaderText = "No";
            dataGridViewKurumumdakiStajyerler.Columns[2].HeaderText = "Adı";
            dataGridViewKurumumdakiStajyerler.Columns[3].HeaderText = "Soyadı";
            dataGridViewKurumumdakiStajyerler.Columns[4].HeaderText = "Okul";
            dataGridViewKurumumdakiStajyerler.Columns[5].HeaderText = "Bölüm";
            dataGridViewKurumumdakiStajyerler.Columns[6].HeaderText = "Öğrenci Telefon";
            dataGridViewKurumumdakiStajyerler.Columns[7].HeaderText = "Not Ort.";
            dataGridViewKurumumdakiStajyerler.Columns[8].HeaderText = "Öğrenci E-Posta";
            dataGridViewKurumumdakiStajyerler.Columns[9].HeaderText = "Danışman";
            dataGridViewKurumumdakiStajyerler.Columns[10].HeaderText = "Kurum Kodu";
            dataGridViewKurumumdakiStajyerler.Columns[11].HeaderText = "Kurum Adı";
            dataGridViewKurumumdakiStajyerler.Columns[12].HeaderText = "Kurum Tel";
            dataGridViewKurumumdakiStajyerler.Columns[13].HeaderText = "Kurum E-Posta";
            dataGridViewKurumumdakiStajyerler.Columns[14].Visible = false;
        }


        private void DataGridViewTumKurumlar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBoxKurumKurumKodu.Text = dataGridViewTumKurumlar.CurrentRow.Cells[1].Value.ToString();
            textBoxKurumKurumAdi.Text = dataGridViewTumKurumlar.CurrentRow.Cells[2].Value.ToString();
            textBoxKurumKurumTel.Text = dataGridViewTumKurumlar.CurrentRow.Cells[3].Value.ToString();
            textBoxKurumKurumEmail.Text = dataGridViewTumKurumlar.CurrentRow.Cells[4].Value.ToString();
            textBoxKurumKurumAdres.Text = dataGridViewTumKurumlar.CurrentRow.Cells[5].Value.ToString();
            textBoxKurumKurumSektor.Text = dataGridViewTumKurumlar.CurrentRow.Cells[6].Value.ToString();
            textBoxKurumKurumSifre.Text = dataGridViewTumKurumlar.CurrentRow.Cells[7].Value.ToString();
            textBoxKurumKurumTur.Text = dataGridViewTumKurumlar.CurrentRow.Cells[8].Value.ToString();
            textBoxKurumResimi.Text = dataGridViewTumKurumlar.CurrentRow.Cells[9].Value.ToString();
            pictureBoxKurum.ImageLocation = textBoxKurumResimi.Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            string kurumguncelle = "update kurum set kurum_kodu=@kurumkodu,kurum_adi=@kurumadi,kurum_tel=@kurumtel,kurum_eposta=@kurumeposta,kurum_adres=@kurumadres,    kurum_sektor=@kurumsektor,kurum_sifre=@kurumsifre,kurum_tur=@kurumtur,kurum_resim=@kurumresim where kurum_id=@kurumid";
            OleDbCommand komutt = new OleDbCommand(kurumguncelle, baglanti);
            komutt.Parameters.AddWithValue("@kurumkodu", textBoxKurumKurumKodu.Text);
            komutt.Parameters.AddWithValue("@kurumadi", textBoxKurumKurumAdi.Text);
            komutt.Parameters.AddWithValue("@kurumtel", textBoxKurumKurumTel.Text);
            komutt.Parameters.AddWithValue("@kurumemail", textBoxKurumKurumEmail.Text);
            komutt.Parameters.AddWithValue("@kurumadres", textBoxKurumKurumAdres.Text);
            komutt.Parameters.AddWithValue("@kurumsektor", textBoxKurumKurumSektor.Text);
            komutt.Parameters.AddWithValue("@kurumsifre", textBoxKurumKurumSifre.Text);
            komutt.Parameters.AddWithValue("@kurumtur", textBoxKurumKurumTur.Text);
            komutt.Parameters.AddWithValue("@kurumresim", textBoxKurumResimi.Text);
            komutt.Parameters.AddWithValue("@kurumid", dataGridViewTumKurumlar.CurrentRow.Cells[0].Value.ToString());
            komutt.ExecuteNonQuery();
            string kurumguncellestajyer1 = "update stajyer set kurum_tel=@kurumtel where kurum_kodu=@kurumkodu";
            OleDbCommand komutst1 = new OleDbCommand(kurumguncellestajyer1, baglanti);
            komutst1.Parameters.AddWithValue("@kurumtel", textBoxKurumKurumTel.Text);
            komutst1.Parameters.AddWithValue("@kurumkodu", textBoxKurumKurumKodu.Text);
            komutst1.ExecuteNonQuery();

            string kurumguncellestajyer2 = "update stajyer set kurum_adi=@kurumadi where kurum_kodu=@kurumkodu";
            OleDbCommand komutst2 = new OleDbCommand(kurumguncellestajyer2, baglanti);
            komutst2.Parameters.AddWithValue("@kurumadi", textBoxKurumKurumAdi.Text);
            komutst2.Parameters.AddWithValue("@kurumkodu", textBoxKurumKurumKodu.Text);
            komutst2.ExecuteNonQuery();




            string kurumguncellestajyer3 = "update stajyer set kurum_email=@kurumemail where kurum_kodu=@kurumkodu";
            OleDbCommand komutst3 = new OleDbCommand(kurumguncellestajyer3, baglanti);
            komutst3.Parameters.AddWithValue("@kurumemail", textBoxKurumKurumEmail.Text);
            komutst3.Parameters.AddWithValue("@kurumkodu", textBoxKurumKurumKodu.Text);
            komutst3.ExecuteNonQuery();

            MessageBox.Show("Güncelleme Tamam");
            OleDbDataAdapter tumkurmlar = new OleDbDataAdapter("SELECT * from kurum where kurum_kodu = '" + labelKurumKodu.Text + "' ", baglanti);
            DataTable tablotumkurumlar = new DataTable();
            tumkurmlar.Fill(tablotumkurumlar);
            dataGridViewTumKurumlar.DataSource = tablotumkurumlar;

           




        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_MouseHover(object sender, EventArgs e)
        {
            //pictureBox2.Left -= buyumeMiktari / 2;
            //pictureBox2.Top -= buyumeMiktari / 2;
            //pictureBox2.Width += buyumeMiktari;
            //pictureBox2.Height += buyumeMiktari;
        }

        private void PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            //pictureBox2.Left += buyumeMiktari / 2;
            //pictureBox2.Top += buyumeMiktari / 2;
            //pictureBox2.Width -= buyumeMiktari;
            //pictureBox2.Height -= buyumeMiktari;
        }

        private void ButtonCvGoruntule_Click(object sender, EventArgs e)
        {
            CV yenipencere = new CV();
            yenipencere.Show();
            yenipencere.pictureBox1.ImageLocation= dataGridViewKurumumdakiStajyerler.CurrentRow.Cells[15].Value.ToString();

        }

        private void LabelOgrDanışman_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LabelOgrNot_Click(object sender, EventArgs e)
        {

        }

        private void LabelOgrEmail_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxOgrEmaii_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            if (textBoxKurumKurumSifre.PasswordChar == '*')
            {

                textBoxKurumKurumSifre.PasswordChar = '\0';
            }
            else
            {
                textBoxKurumKurumSifre.PasswordChar = '*';
            }
        }

      
        private void ButtonKurumResimiYukleme_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Yüklenecek Dosyayı Seçiniz...";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakDosyaIsmi3 = textBoxKurumKurumKodu.Text + "__" + openFileDialog1.SafeFileName.ToString();
                kaynakDosya3 = openFileDialog1.FileName.ToString();
                textBoxKurumResimi.Text = kaynakDosya3;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (labelKurumResim.Text != "" && kaynakDosya3 != "")
            {
                if (File.Exists(labelKurumResim.Text + "\\" + kaynakDosyaIsmi3))
                {
                    MessageBox.Show("Belirtilen klasörde " + kaynakDosyaIsmi3 + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(kaynakDosya3, labelKurumResim.Text + "\\" + kaynakDosyaIsmi3);
                    MessageBox.Show("Dosya Kopyalama İşlemi Başarılı", "Dosya Kopyalandı...");
                }

            }

            textBoxKurumResimi.Text = @"img\kurum_resim\" + kaynakDosyaIsmi3;
            pictureBoxKurum.ImageLocation = @"img\kurum_resim\" + kaynakDosyaIsmi3;

        }
    }
}
