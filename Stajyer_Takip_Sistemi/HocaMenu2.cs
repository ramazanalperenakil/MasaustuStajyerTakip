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
    public partial class HocaMenu2 : Form
    {
        public HocaMenu2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Stajyer_takip_Sistemi.mdb");

        DataTable tablo = new DataTable();
        string Aratxt;
        int j;
        string kaynakDosya = "", kaynakDosyaIsmi = "";
        string kaynakDosya2 = "", kaynakDosyaIsmi2 = "";
        string kaynakDosya3 = "", kaynakDosyaIsmi3 = "";

        DataTable tablo2 = new DataTable();

        DataTable tablo3 = new DataTable();
        DataTable tablo4 = new DataTable();
        DataTable tablo5 = new DataTable();
        DataTable tablo6 = new DataTable();
        DataTable tablo7 = new DataTable();
        DataTable tablo8 = new DataTable();
        DataTable tablo9 = new DataTable();
        DataTable tablo10 = new DataTable();
        private void textclear(Control ctl)
        {
            textBoxOgrEkraniDanismanAdi.Text = labelHocaAdSoyad.Text;
            textBoxOgrEkraniDanismanSicil.Text = labelSicilNo.Text;
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

        private void HocaMenu2_Load(object sender, EventArgs e)
        {
            ////tabControl1.TabPages[0].BackgroundImage = Image.FromFile(@"img\arka2.png");
            //foreach (TabPage theTab in tabControl1.TabPages)
            //{
            //    Image img = Image.FromFile(@"img\arka2.png");
            //    tabControl1.TabPages[0].BackgroundImage = img;
            //    tabControl1.TabPages[1].BackgroundImage = img;
            //    tabControl1.TabPages[2].BackgroundImage = img;
            //    tabControl1.TabPages[3].BackgroundImage = img;

            //    tabControl1.TabPages[0].BackgroundImageLayout = ImageLayout.Stretch;
            //    tabControl1.TabPages[1].BackgroundImageLayout = ImageLayout.Stretch;
            //    tabControl1.TabPages[2].BackgroundImageLayout = ImageLayout.Stretch;
            //    tabControl1.TabPages[3].BackgroundImageLayout = ImageLayout.Stretch;
            //    break;



            //}
            baglanti.Open();
            timer1.Interval = 10;

            timer1.Enabled = true;

            //hocanın sicil nosundan bilgileri çektik

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM hoca where sicil_no = '" + labelSicilNo.Text + "' ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;


            dataGridView1.Visible = false;

            label4.Text = DateTime.Now.ToLongDateString();

            //textpasif(this);






        }

        private void HocaMenu2_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
            Application.Exit();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //sicil nosundan hocanın adını ve soyadını çektik
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM hoca where sicil_no = '" + labelSicilNo.Text + "' ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;

            string ad = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string soyad = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            labelHocaAdSoyad.Text = ad + " " + soyad;

            textBoxOgrEkraniDanismanAdi.Text = labelHocaAdSoyad.Text;
            textBoxOgrEkraniDanismanSicil.Text = labelSicilNo.Text;
            textBoxOgrEkraniDanismanAdi.Enabled = false;
            textBoxOgrEkraniDanismanSicil.Enabled = false;


            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            groupBoxKullaniciBilgileri.Visible = true;

            //sicil nosu giriş yapan hoccanın stajyer oğrencileerini çektik
            OleDbDataAdapter staj = new OleDbDataAdapter("SELECT * FROM stajyer where sicil_no = '" + labelSicilNo.Text + "' ", baglanti);
            DataTable tablostaj = new DataTable();
            staj.Fill(tablostaj);
            dataGridViewStajyer.DataSource = tablostaj;


            dataGridViewStajyer.Columns[0].HeaderText = "Stajyer id";
            dataGridViewStajyer.Columns[1].HeaderText = "No";
            dataGridViewStajyer.Columns[2].HeaderText = "Adı";
            dataGridViewStajyer.Columns[3].HeaderText = "Soyadı";
            dataGridViewStajyer.Columns[4].HeaderText = "Okul";
            dataGridViewStajyer.Columns[5].HeaderText = "Bölüm";
            dataGridViewStajyer.Columns[6].HeaderText = "Öğrenci Telefon";
            dataGridViewStajyer.Columns[7].HeaderText = "Not Ort.";
            dataGridViewStajyer.Columns[8].HeaderText = "Öğrenci E-Posta";
            dataGridViewStajyer.Columns[9].HeaderText = "Danışman";
            dataGridViewStajyer.Columns[10].HeaderText = "Kurum Kodu";
            dataGridViewStajyer.Columns[11].HeaderText = "Kurum Adı";
            dataGridViewStajyer.Columns[12].HeaderText = "Kurum Tel";
            dataGridViewStajyer.Columns[13].HeaderText = "Kurum E-Posta";
            dataGridViewStajyer.Columns[14].Visible = false;

            //sicil nolu giriş yapan hocanın stajyer olan öğrencilerinin staj kurumlarını çektik
            OleDbDataAdapter stajkurumlar = new OleDbDataAdapter("SELECT * FROM kurum WHERE kurum_kodu in (select kurum_kodu from stajyer where sicil_no = '" + labelSicilNo.Text + "') ", baglanti);
            DataTable tablostajKurum = new DataTable();
            stajkurumlar.Fill(tablostajKurum);
            dataGridViewStajyerlerinKurumlari.DataSource = tablostajKurum;

            dataGridViewStajyerlerinKurumlari.Columns[7].Visible = false;

            dataGridViewStajyerlerinKurumlari.Columns[0].HeaderText = "Kurum id";
            dataGridViewStajyerlerinKurumlari.Columns[1].HeaderText = "Kurum Kodu";
            dataGridViewStajyerlerinKurumlari.Columns[2].HeaderText = "Kurum Adı";
            dataGridViewStajyerlerinKurumlari.Columns[3].HeaderText = "Kurum Tel";
            dataGridViewStajyerlerinKurumlari.Columns[4].HeaderText = "Kurum E-Posta";
            dataGridViewStajyerlerinKurumlari.Columns[5].HeaderText = "Kurum Adresi";
            dataGridViewStajyerlerinKurumlari.Columns[6].HeaderText = "Kurum Sektörü";
            dataGridViewStajyerlerinKurumlari.Columns[8].HeaderText = "Kurum Tür";













            //sicil nodan giriş yapan hocanın tüm öğrencilerini çektik
            OleDbDataAdapter benimogrencilerim = new OleDbDataAdapter("SELECT * from ogrenci where sicil_no ='" + labelSicilNo.Text + "' ", baglanti);
            DataTable tablobenimogrencilerim = new DataTable();
            benimogrencilerim.Fill(tablobenimogrencilerim);
            dataGridViewBenimOgrencilerim.DataSource = tablobenimogrencilerim;




            dataGridViewBenimOgrencilerim.Columns[0].HeaderText = "id";
            dataGridViewBenimOgrencilerim.Columns[1].HeaderText = "Adı";
            dataGridViewBenimOgrencilerim.Columns[2].HeaderText = "No";
            dataGridViewBenimOgrencilerim.Columns[3].HeaderText = "Okul";
            dataGridViewBenimOgrencilerim.Columns[4].HeaderText = "Soyad";
            dataGridViewBenimOgrencilerim.Columns[5].HeaderText = "Bölüm";
            dataGridViewBenimOgrencilerim.Columns[6].HeaderText = "Fakulte";
            dataGridViewBenimOgrencilerim.Columns[7].HeaderText = "Not";
            dataGridViewBenimOgrencilerim.Columns[8].HeaderText = "Tel";
            dataGridViewBenimOgrencilerim.Columns[9].HeaderText = "Adres";
            dataGridViewBenimOgrencilerim.Columns[10].HeaderText = "E-Posta";
            dataGridViewBenimOgrencilerim.Columns[11].HeaderText = "Sicil";
            dataGridViewBenimOgrencilerim.Columns[12].HeaderText = "Şifre";
            dataGridViewBenimOgrencilerim.Columns[13].HeaderText = "CV";
            dataGridViewBenimOgrencilerim.Columns[14].HeaderText = "Resim";
            dataGridViewBenimOgrencilerim.Columns[15].HeaderText = "Soru";

            dataGridViewBenimOgrencilerim.Columns[12].Visible = false;
            dataGridViewBenimOgrencilerim.Columns[15].Visible = false;





















            //sisteme kayıtlı tüm kurumları çektik
            OleDbDataAdapter tumkurmlar = new OleDbDataAdapter("SELECT * from kurum", baglanti);
            DataTable tablotumkurumlar = new DataTable();
            tumkurmlar.Fill(tablotumkurumlar);
            dataGridViewTumKurumlar.DataSource = tablotumkurumlar;


            dataGridViewTumKurumlar.Columns[0].HeaderText = "Kurum id";
            dataGridViewTumKurumlar.Columns[1].HeaderText = "Kurum Kodu";
            dataGridViewTumKurumlar.Columns[2].HeaderText = "Kurum Adı";
            dataGridViewTumKurumlar.Columns[3].HeaderText = "Kurum Telefon";
            dataGridViewTumKurumlar.Columns[4].HeaderText = "Kurum E-Posta";
            dataGridViewTumKurumlar.Columns[5].HeaderText = "Kurum Adres";
            dataGridViewTumKurumlar.Columns[6].HeaderText = "Kurum Sektor";
            dataGridViewTumKurumlar.Columns[7].HeaderText = "Kurum Sifre";
            dataGridViewTumKurumlar.Columns[8].HeaderText = "Kurum Tur";
            dataGridViewTumKurumlar.Columns[9].HeaderText = "Kurum Resim";

            dataGridViewTumKurumlar.Columns[7].Visible = false;
            timer1.Enabled = false;




        }

        private void DataGridViewStajyer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewStajyer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //stajyer öğrenci bilgilerini texbox a yazdırıdık

            textBoxOgrNo.Text = dataGridViewStajyer.CurrentRow.Cells[1].Value.ToString();
            textBoxOgrAd.Text = dataGridViewStajyer.CurrentRow.Cells[2].Value.ToString();
            textBoxOgrSoyad.Text = dataGridViewStajyer.CurrentRow.Cells[3].Value.ToString();
            textBoxOgrOkul.Text = dataGridViewStajyer.CurrentRow.Cells[4].Value.ToString();
            textBoxOgrBolum.Text = dataGridViewStajyer.CurrentRow.Cells[5].Value.ToString();
            textBoxOgrTel.Text = dataGridViewStajyer.CurrentRow.Cells[6].Value.ToString();
            textBoxOgrOrt.Text = dataGridViewStajyer.CurrentRow.Cells[7].Value.ToString();
            textBoxOgrEmaii.Text = dataGridViewStajyer.CurrentRow.Cells[8].Value.ToString();
            textBoxOgrDanisman.Text = dataGridViewStajyer.CurrentRow.Cells[9].Value.ToString();
            textBoxKurum.Text = dataGridViewStajyer.CurrentRow.Cells[10].Value.ToString();
            textBoxKurumAdi.Text = dataGridViewStajyer.CurrentRow.Cells[11].Value.ToString();
            textBoxKurumTel.Text = dataGridViewStajyer.CurrentRow.Cells[12].Value.ToString();
            textBoxKurumEmail.Text = dataGridViewStajyer.CurrentRow.Cells[13].Value.ToString();

        }
        public void tabControl1HeaderColor(TabPage page, Color color)
        {
            BackColor = Color.Red;
        }


        private void ButtonTemizle_Click(object sender, EventArgs e)
        {
            // arama işlemi yapıldaktan sicil nodan giriş yapa hocanın tüm stajyerlerini çektik
            OleDbDataAdapter staj = new OleDbDataAdapter("SELECT * FROM stajyer where sicil_no = '" + labelSicilNo.Text + "' ", baglanti);
            DataTable tablostaj = new DataTable();
            staj.Fill(tablostaj);
            dataGridViewStajyer.DataSource = tablostaj;


            dataGridViewStajyer.Columns[0].HeaderText = "Stajyer id";
            dataGridViewStajyer.Columns[1].HeaderText = "No";
            dataGridViewStajyer.Columns[2].HeaderText = "Adı";
            dataGridViewStajyer.Columns[3].HeaderText = "Soyadı";
            dataGridViewStajyer.Columns[4].HeaderText = "Okul";
            dataGridViewStajyer.Columns[5].HeaderText = "Bölüm";
            dataGridViewStajyer.Columns[6].HeaderText = "Öğrenci Telefon";
            dataGridViewStajyer.Columns[7].HeaderText = "Not Ort.";
            dataGridViewStajyer.Columns[8].HeaderText = "Öğrenci E-Posta";
            dataGridViewStajyer.Columns[9].HeaderText = "Danışman";
            dataGridViewStajyer.Columns[10].HeaderText = "Kurum Kodu";
            dataGridViewStajyer.Columns[11].HeaderText = "Kurum Adı";
            dataGridViewStajyer.Columns[12].HeaderText = "Kurum Tel";
            dataGridViewStajyer.Columns[13].HeaderText = "Kurum E-Posta";
            dataGridViewStajyer.Columns[14].Visible = false;


        }



        private void ButtonStajyerAra_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBoxOgrNo.Text != "")
                {
                    tablo.Clear();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from stajyer where sicil_no = '" + labelSicilNo.Text + "'  and  ogr_no LIKE '%" + textBoxOgrNo.Text + "%'", baglanti);
                    adtr.Fill(tablo);
                    dataGridViewStajyer.DataSource = tablo;

                }
                else
                {
                    MessageBox.Show("Test1");
                }





                if (textBoxOgrAd.Text != "")
                {
                    tablo2.Clear();

                    OleDbDataAdapter adtr2 = new OleDbDataAdapter("SELECT * from stajyer where sicil_no = '" + labelSicilNo.Text + "'  and  ogr_ad LIKE '%" + textBoxOgrAd.Text + "%'", baglanti);
                    adtr2.Fill(tablo2);
                    dataGridViewStajyer.DataSource = tablo2;

                }
                else
                {
                    MessageBox.Show("Test2");
                }






                if (textBoxOgrSoyad.Text != "")
                {
                    tablo3.Clear();


                    OleDbDataAdapter adtr3 = new OleDbDataAdapter("SELECT * from stajyer where sicil_no = '" + labelSicilNo.Text + "'  and  ogr_soyad LIKE '%" + textBoxOgrSoyad.Text + "%'", baglanti);
                    adtr3.Fill(tablo3);
                    dataGridViewStajyer.DataSource = tablo3;

                }
                else
                {
                    MessageBox.Show("Test3");
                }



                radioButton1.Checked = false;
                radioButtonOgrAd.Checked = false;
                radioButtonOgrSoyad.Checked = false;
                //textpasif(this);

                dataGridViewStajyer.Columns[0].HeaderText = "Stajyer id";
                dataGridViewStajyer.Columns[1].HeaderText = "No";
                dataGridViewStajyer.Columns[2].HeaderText = "Adı";
                dataGridViewStajyer.Columns[3].HeaderText = "Soyadı";
                dataGridViewStajyer.Columns[4].HeaderText = "Okul";
                dataGridViewStajyer.Columns[5].HeaderText = "Bölüm";
                dataGridViewStajyer.Columns[6].HeaderText = "Öğrenci Telefon";
                dataGridViewStajyer.Columns[7].HeaderText = "Not Ort.";
                dataGridViewStajyer.Columns[8].HeaderText = "Öğrenci E-Posta";
                dataGridViewStajyer.Columns[9].HeaderText = "Danışman";
                dataGridViewStajyer.Columns[10].HeaderText = "Kurum Kodu";
                dataGridViewStajyer.Columns[11].HeaderText = "Kurum Adı";
                dataGridViewStajyer.Columns[12].HeaderText = "Kurum Tel";
                dataGridViewStajyer.Columns[13].HeaderText = "Kurum E-Posta";
                dataGridViewStajyer.Columns[14].Visible = false;




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
                //textpasif(this);
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
                // textpasif(this);
                textBoxOgrSoyad.Enabled = true;
                textBoxOgrSoyad.Focus();
            }

        }

        private void ButtonCık_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void DataGridViewStajyerlerinKurumlari_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            textBoxKurumKodu.Text = dataGridViewStajyerlerinKurumlari.CurrentRow.Cells[1].Value.ToString();
            textBoxKurumAdı.Text = dataGridViewStajyerlerinKurumlari.CurrentRow.Cells[2].Value.ToString();
            textBoxKurKurumTel.Text = dataGridViewStajyerlerinKurumlari.CurrentRow.Cells[3].Value.ToString();
            textBoxKurKurumTuruu.Text = dataGridViewStajyerlerinKurumlari.CurrentRow.Cells[8].Value.ToString();
            textBoxKurKurumEposta.Text = dataGridViewStajyerlerinKurumlari.CurrentRow.Cells[4].Value.ToString();
            textBoxKurKurumAdres.Text = dataGridViewStajyerlerinKurumlari.CurrentRow.Cells[5].Value.ToString();
            textBoxKurKurumSektoru.Text = dataGridViewStajyerlerinKurumlari.CurrentRow.Cells[6].Value.ToString();

        }

        private void ButtonKurumTümKayıtlar_Click(object sender, EventArgs e)
        {
            //sicil nolu giriş yapan hocanın stajyer olan öğrencilerinin staj kurumlarını çektik
            OleDbDataAdapter stajkurumlar = new OleDbDataAdapter("SELECT * FROM kurum WHERE kurum_kodu in (select kurum_kodu from stajyer where sicil_no = '" + labelSicilNo.Text + "') ", baglanti);
            DataTable tablostajKurum = new DataTable();
            stajkurumlar.Fill(tablostajKurum);
            dataGridViewStajyerlerinKurumlari.DataSource = tablostajKurum;

            dataGridViewStajyerlerinKurumlari.Columns[7].Visible = false;

            dataGridViewStajyerlerinKurumlari.Columns[0].HeaderText = "Kurum id";
            dataGridViewStajyerlerinKurumlari.Columns[1].HeaderText = "Kurum Kodu";
            dataGridViewStajyerlerinKurumlari.Columns[2].HeaderText = "Kurum Adı";
            dataGridViewStajyerlerinKurumlari.Columns[3].HeaderText = "Kurum Tel";
            dataGridViewStajyerlerinKurumlari.Columns[4].HeaderText = "Kurum E-Posta";
            dataGridViewStajyerlerinKurumlari.Columns[5].HeaderText = "Kurum Adresi";
            dataGridViewStajyerlerinKurumlari.Columns[6].HeaderText = "Kurum Sektörü";
            dataGridViewStajyerlerinKurumlari.Columns[8].HeaderText = "Kurum Tür";
        }

        private void RadioButtonKurumKodu_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonKurumKodu.Checked == true)
            {
                textclear(this);
                //textpasif(this);
                textBoxKurumKodu.Enabled = true;
                textBoxKurumKodu.Focus();

            }
        }

        private void RadioButtonKurumAdi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKurumAdi.Checked == true)
            {
                textclear(this);
                //textpasif(this);
                textBoxKurumAdı.Enabled = true;
                textBoxKurumAdı.Focus();

            }

        }

        private void RadioButtonKurumTur_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKurumTur.Checked == true)
            {
                textclear(this);
                // textpasif(this);
                textBoxKurKurumTuruu.Enabled = true;
                textBoxKurKurumTuruu.Focus();

            }
        }

        private void ButtonKurKurumAra_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewStajyerlerinKurumlari.Columns[7].Visible = false;

                dataGridViewStajyerlerinKurumlari.Columns[0].HeaderText = "Kurum id";
                dataGridViewStajyerlerinKurumlari.Columns[1].HeaderText = "Kurum Kodu";
                dataGridViewStajyerlerinKurumlari.Columns[2].HeaderText = "Kurum Adı";
                dataGridViewStajyerlerinKurumlari.Columns[3].HeaderText = "Kurum Tel";
                dataGridViewStajyerlerinKurumlari.Columns[4].HeaderText = "Kurum E-Posta";
                dataGridViewStajyerlerinKurumlari.Columns[5].HeaderText = "Kurum Adresi";
                dataGridViewStajyerlerinKurumlari.Columns[6].HeaderText = "Kurum Sektörü";
                dataGridViewStajyerlerinKurumlari.Columns[8].HeaderText = "Kurum Tür";


                //sicil kodu alınan öğretmenin öğrencilerinin staj yaptıgı kurumlar data grid e listelndiğinden arama işlemi data grid üzerinden yapıldı
                if (textBoxKurumKodu.Text != "")
                {
                    string Aratxt = textBoxKurumKodu.Text.Trim().ToUpper();
                    int j1 = -1;
                    for (int i = 0; i <= dataGridViewStajyerlerinKurumlari.Rows.Count - 1; i++)
                    {
                        foreach (DataGridViewRow row in dataGridViewStajyerlerinKurumlari.Rows)
                        {
                            foreach (DataGridViewCell cell in dataGridViewStajyerlerinKurumlari.Rows[i].Cells)
                            {
                                if (cell.Value != null)
                                {
                                    if (cell.Value.ToString().ToUpper() == Aratxt)
                                    {
                                        cell.Style.BackColor = Color.Yellow;
                                        j1 = 0;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (j1 == -1)
                    {
                        MessageBox.Show("Kayıt Bulunamadı");
                    }

                }
                else
                {
                    MessageBox.Show("Test4");
                }

                if (textBoxKurumAdı.Text != "")
                {
                    string Aratxt2 = textBoxKurumAdı.Text.Trim().ToUpper();
                    int j = -1;
                    for (int i = 0; i <= dataGridViewStajyerlerinKurumlari.Rows.Count - 1; i++)
                    {
                        foreach (DataGridViewRow row in dataGridViewStajyerlerinKurumlari.Rows)
                        {
                            foreach (DataGridViewCell cell in dataGridViewStajyerlerinKurumlari.Rows[i].Cells)
                            {
                                if (cell.Value != null)
                                {
                                    if (cell.Value.ToString().ToUpper() == Aratxt2)
                                    {
                                        cell.Style.BackColor = Color.Yellow;
                                        j = 0;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (j == -1)
                    {
                        MessageBox.Show("Kayıt Bulunamadı");
                    }
                }


                if (textBoxKurKurumTuruu.Text != "")
                {
                    string Aratxt3 = textBoxKurKurumTuruu.Text.Trim().ToUpper();
                    int j3 = -1;
                    for (int i = 0; i <= dataGridViewStajyerlerinKurumlari.Rows.Count - 1; i++)
                    {
                        foreach (DataGridViewRow row in dataGridViewStajyerlerinKurumlari.Rows)
                        {
                            foreach (DataGridViewCell cell in dataGridViewStajyerlerinKurumlari.Rows[i].Cells)
                            {
                                if (cell.Value != null)
                                {
                                    if (cell.Value.ToString().ToUpper() == Aratxt3)
                                    {
                                        cell.Style.BackColor = Color.Yellow;
                                        j3 = 0;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (j3 == -1)
                    {
                        MessageBox.Show("Kayıt Bulunamadı");
                    }
                }

                textclear(this);
                dataGridViewStajyerlerinKurumlari.DefaultCellStyle.SelectionBackColor = Color.White;

                dataGridViewStajyerlerinKurumlari.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            catch
            {
                MessageBox.Show("hata");

            }


        }

        private void TextBoxKurumKodu_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridViewBenimOgrencilerim_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            label27id.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[2].Value.ToString();
            textBoxOgrEkrAdi.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[1].Value.ToString();
            textBoxOgrEkrNo.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[2].Value.ToString();
            textBoxOgrEkrOkulu.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[3].Value.ToString();
            textBoxOgrEkrSoyadi.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[4].Value.ToString();
            textBoxOgrEkrBolumu.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[5].Value.ToString();
            textBoxOgrEkrFakulte.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[6].Value.ToString();
            textBoxOgrEkrNot.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[7].Value.ToString();
            textBoxOgrEkrGsm.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[8].Value.ToString();
            textBoxOgrEkrAdres.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[9].Value.ToString();
            textBoxOgrEkrEmail.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[10].Value.ToString();
            textBoxOgrEkrSifre.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[12].Value.ToString();
            textBoxOgrEkrCv.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[13].Value.ToString();
            textBoxOgrEkrResim.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[14].Value.ToString();

            pictureBoxCv.ImageLocation = dataGridViewBenimOgrencilerim.CurrentRow.Cells[13].Value.ToString();
            pictureBoxOgrenciResim.ImageLocation = dataGridViewBenimOgrencilerim.CurrentRow.Cells[14].Value.ToString();
        }

        private void ButtonOgrenciEkle_Click(object sender, EventArgs e)
        {
            try
            {

                string ekle = "insert into ogrenci(ogr_ad,ogr_soyad,ogr_no,ogr_okul,ogr_bolum,ogr_fakulte,ogr_not_ort,ogr_tel,ogr_adres,ogr_email,sicil_no,ogr_sifre,ogr_cv,ogr_resimi) values (@ograd,@ogrsoyad,@ogrno,@ogrokul,@ogrbolum,@ogrfakulte,@ogrnotort,@ogrtel,@ogradres,@ogremail,@sicilno,@ogrsifre,@ogrcv,@ogrresimi)";
                OleDbCommand komutt = new OleDbCommand(ekle, baglanti);
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

                komutt.ExecuteNonQuery();
                MessageBox.Show("Kayıt Yapıldı");
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM ogrenci where sicil_no = '" + labelSicilNo.Text + "' ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridViewBenimOgrencilerim.DataSource = tablo;

            }
            catch
            {

                MessageBox.Show("hata");
            }



        }

        private void ButtonOgrEkranTemizle_Click(object sender, EventArgs e)
        {
            pictureBoxCv.ImageLocation = null;
            pictureBoxOgrenciResim.ImageLocation = null;
            textclear(this);
            textaktif(this);

            textBoxOgrEkraniDanismanAdi.Enabled = false;
            textBoxOgrEkraniDanismanSicil.Enabled = false;
            label27id.Text = null;
            labelogrid.Text = null;
            pictureBoxCv.ImageLocation = null;
            pictureBoxOgrenciResim.ImageLocation = null;
            textBoxOgrEkraniDanismanAdi.Text = labelHocaAdSoyad.Text;
            textBoxOgrEkraniDanismanSicil.Text = labelSicilNo.Text;

        }

        private void Ogrenciİslemleri_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void ButtonTumOgrenciAra_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewBenimOgrencilerim.DataSource = null;
                radioButtonTumOgrenciSoyad.Checked = false;
                if (textBoxOgrEkrNo.Text.Trim() != "")
                {

                    tablo4.Clear();

                    OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from ogrenci where sicil_no = '" + labelSicilNo.Text + "'  and  ogr_no LIKE '%" + textBoxOgrEkrNo.Text + "%'", baglanti);
                    adtr.Fill(tablo4);

                    dataGridViewBenimOgrencilerim.DataSource = tablo4;
                    radioButtonTumOgrenciNo.Checked = false;
                    label27.Visible = false;
                }
                else
                {
                    //  MessageBox.Show("Test5");
                }

                if (textBoxOgrEkrAdi.Text.Trim() != "")
                {


                    tablo5.Clear();

                    OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from ogrenci where sicil_no = '" + labelSicilNo.Text + "'  and  ogr_ad LIKE '%" + textBoxOgrEkrAdi.Text + "%'", baglanti);
                    adtr.Fill(tablo5);

                    dataGridViewBenimOgrencilerim.DataSource = tablo5;
                    radioButtonTumOgrenciAd.Checked = false;

                    label27.Visible = false;

                }
                else
                {
                    // MessageBox.Show("Test6");
                }

                if (textBoxOgrEkrSoyadi.Text.Trim() != "")
                {
                    tablo6.Clear();

                    OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from ogrenci where sicil_no = '" + labelSicilNo.Text + "'  and  ogr_soyad LIKE '%" + textBoxOgrEkrSoyadi.Text + "%'", baglanti);
                    adtr.Fill(tablo6);
                    dataGridViewBenimOgrencilerim.DataSource = tablo6;
                    label27.Visible = false;
                }
                else
                {
                    //MessageBox.Show("Test7");
                }

                dataGridViewBenimOgrencilerim.Columns[0].HeaderText = "id";
                dataGridViewBenimOgrencilerim.Columns[1].HeaderText = "Adı";
                dataGridViewBenimOgrencilerim.Columns[2].HeaderText = "No";
                dataGridViewBenimOgrencilerim.Columns[3].HeaderText = "Okul";
                dataGridViewBenimOgrencilerim.Columns[4].HeaderText = "Soyad";
                dataGridViewBenimOgrencilerim.Columns[5].HeaderText = "Bölüm";
                dataGridViewBenimOgrencilerim.Columns[6].HeaderText = "Fakulte";
                dataGridViewBenimOgrencilerim.Columns[7].HeaderText = "Not";
                dataGridViewBenimOgrencilerim.Columns[8].HeaderText = "Tel";
                dataGridViewBenimOgrencilerim.Columns[9].HeaderText = "Adres";
                dataGridViewBenimOgrencilerim.Columns[10].HeaderText = "E-Posta";
                dataGridViewBenimOgrencilerim.Columns[11].HeaderText = "Sicil";
                dataGridViewBenimOgrencilerim.Columns[12].HeaderText = "Şifre";
                dataGridViewBenimOgrencilerim.Columns[13].HeaderText = "CV";
                dataGridViewBenimOgrencilerim.Columns[14].HeaderText = "Resim";
                dataGridViewBenimOgrencilerim.Columns[15].HeaderText = "Soru";

                dataGridViewBenimOgrencilerim.Columns[12].Visible = false;
                dataGridViewBenimOgrencilerim.Columns[15].Visible = false;

            }
            catch
            {
                MessageBox.Show("Uygun Kayıt Bulunamadı");

            }




        }

        private void RadioButtonTumOgrenciNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTumOgrenciNo.Checked == true)
            {
                pictureBoxCv.ImageLocation = null;
                pictureBoxOgrenciResim.ImageLocation = null;
                textclear(this);
                // textpasif(this);
                textBoxOgrEkrNo.Enabled = true;
                textBoxOgrEkrNo.Focus();
                dataGridViewBenimOgrencilerim.DataSource = null;
            }
            else
            {
                dataGridViewBenimOgrencilerim.DataSource = null;
            }
        }

        private void RadioButtonTumOgrenciAd_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTumOgrenciAd.Checked == true)
            {
                pictureBoxCv.ImageLocation = null;
                pictureBoxOgrenciResim.ImageLocation = null;
                textclear(this);
                // textpasif(this);
                textBoxOgrEkrAdi.Enabled = true;
                textBoxOgrEkrAdi.Focus();
                dataGridViewBenimOgrencilerim.DataSource = null;
            }
            else
            {
                dataGridViewBenimOgrencilerim.DataSource = null;
            }
        }

        private void RadioButtonTumOgrenciSoyad_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTumOgrenciSoyad.Checked == true)
            {
                pictureBoxCv.ImageLocation = null;
                pictureBoxOgrenciResim.ImageLocation = null;
                textclear(this);
                // textpasif(this);
                textBoxOgrEkrSoyadi.Enabled = true;
                textBoxOgrEkrSoyadi.Focus();
                dataGridViewBenimOgrencilerim.DataSource = null;
            }
            else
            {
                dataGridViewBenimOgrencilerim.DataSource = null;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        private void ButtonOgrFotoYukle_Click(object sender, EventArgs e)
        {
            openFileDialog2.Title = "Yüklenecek Dosyayı Seçiniz...";
            openFileDialog2.FileName = "";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakDosyaIsmi2 = textBoxOgrEkrNo.Text + "__" + openFileDialog2.SafeFileName.ToString();
                kaynakDosya2 = openFileDialog2.FileName.ToString();
                textBoxOgrEkrResim.Text = kaynakDosya;
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (labelKopyaKonum2.Text != "" && kaynakDosya2 != "")
            {
                if (File.Exists(labelKopyaKonum2.Text + "\\" + kaynakDosyaIsmi2))
                {
                    MessageBox.Show("Belirtilen klasörde " + kaynakDosyaIsmi2 + " isimli dosya zaten mevcut...", "Uyarı..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(kaynakDosya2, labelKopyaKonum2.Text + "\\" + kaynakDosyaIsmi2);
                    MessageBox.Show("Dosya Kopyalama İşlemi Başarılı", "Dosya Kopyalandı...");
                }

                textBoxOgrEkrResim.Text = @"img\ogr_resim\" + kaynakDosyaIsmi2;
                pictureBoxOgrenciResim.ImageLocation = @"img\ogr_resim\" + kaynakDosyaIsmi2;

            }
        }

        private void ButtonOgrencciguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string guncelle = "update ogrenci set ogr_ad = @ograd, ogr_soyad = ogrsoyad, ogr_no= @ogrno, ogr_okul=@ogrokul, ogr_bolum=@ogrbolum, ogr_fakulte=@ogrfakulte, ogr_not_ort=@ogrnot, ogr_tel=@ogrtel, ogr_adres=@ogradres, ogr_email=@ogremail, sicil_no=@sicil_no, ogr_sifre=@ogrsifre, ogr_cv=@ogrcv, ogr_resimi=ogrresimi where ogr_id=@ogrid";
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
                komutt.Parameters.AddWithValue("@ogrid", dataGridViewBenimOgrencilerim.CurrentRow.Cells[0].Value.ToString());


                komutt.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Tamam");
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM ogrenci where sicil_no = '" + labelSicilNo.Text + "'  ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridViewBenimOgrencilerim.DataSource = tablo;


                labelOgrenciİd.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("hata");

            }


        }

        private void DataGridViewBenimOgrencilerim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            labelOgrenciİd.Text = textBoxOgrEkrNo.Text;
        }

        private void ButtonSifreAta_Click(object sender, EventArgs e)
        {
            textBoxOgrEkrSifre.Text = "123456";
            label27.Visible = true;
            label27.Enabled = true;
        }

        private void ButtonOgrenciSil_Click(object sender, EventArgs e)
        {
            try
            {

                label37.Text = dataGridViewBenimOgrencilerim.CurrentRow.Cells[2].Value.ToString();
                DialogResult c;
                c = MessageBox.Show(dataGridViewBenimOgrencilerim.CurrentRow.Cells[1].Value.ToString() + " " + dataGridViewBenimOgrencilerim.CurrentRow.Cells[4].Value.ToString() + " " + "Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {

                    string sil = "Delete from ogrenci where ogr_id =@ogrid";

                    OleDbCommand komutt = new OleDbCommand(sil, baglanti);
                    komutt.Parameters.AddWithValue("@ogrid", dataGridViewBenimOgrencilerim.CurrentRow.Cells[0].Value.ToString());
                    komutt.ExecuteNonQuery();
                    MessageBox.Show("id = " + labelOgrenciİd.Text + " Nolu Kayıt SİLİNDİ");
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * from ogrenci where sicil_no ='" + labelSicilNo.Text + "' ", baglanti);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dataGridViewBenimOgrencilerim.DataSource = tablo;

                    string sil2 = "Delete from stajyer where ogr_no =@ogrid";

                    OleDbCommand komutsil = new OleDbCommand(sil2, baglanti);
                    komutsil.Parameters.AddWithValue("@ogrid", label37.Text);
                    komutsil.ExecuteNonQuery();

                }
            }
            catch
            {
                MessageBox.Show("hata");

            }

        }

        private void DataGridViewTumKurumlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string KurumEkle = "insert into kurum (kurum_kodu , kurum_adi , kurum_tel, kurum_eposta, kurum_adres, kurum_sektor, kurum_sifre, kurum_tur, kurum_resim) values (@kurumkodu, @kurumadi, @kurumtel,@kurumemail,@kurumadres,@kurumsektor,@kurumsifre,@kurumtur,@kurumresim)";
                OleDbCommand komutt = new OleDbCommand(KurumEkle, baglanti);
                komutt.Parameters.AddWithValue("@kurumkodu", textBoxKurumKurumKodu.Text);
                komutt.Parameters.AddWithValue("@kurumadi", textBoxKurumKurumAdi.Text);
                komutt.Parameters.AddWithValue("@kurumtel", textBoxKurumKurumTel.Text);
                komutt.Parameters.AddWithValue("@kurumemail", textBoxKurumKurumEmail.Text);
                komutt.Parameters.AddWithValue("@kurumadres", textBoxKurumKurumAdres.Text);
                komutt.Parameters.AddWithValue("@kurumsektor", textBoxKurumKurumSektor.Text);
                komutt.Parameters.AddWithValue("@kurumsifre", textBoxKurumKurumSifre.Text);
                komutt.Parameters.AddWithValue("@kurumtur", textBoxKurumKurumTur.Text);
                komutt.Parameters.AddWithValue("@kurumresim", textBoxKurumResimi.Text);
                komutt.ExecuteNonQuery();
                MessageBox.Show("Kayıt Yapıldı");
                OleDbDataAdapter tumkurmlar = new OleDbDataAdapter("SELECT * from kurum", baglanti);
                DataTable tablotumkurumlar = new DataTable();
                tumkurmlar.Fill(tablotumkurumlar);
                dataGridViewTumKurumlar.DataSource = tablotumkurumlar;

            }
            catch
            {
                MessageBox.Show("hata");

            }




        }

        private void DataGridViewStajyerlerinKurumlari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)

        {
            try
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


                MessageBox.Show("Güncelleme Tamam");
                OleDbDataAdapter tumkurmlar = new OleDbDataAdapter("SELECT * from kurum", baglanti);
                DataTable tablotumkurumlar = new DataTable();
                tumkurmlar.Fill(tablotumkurumlar);
                dataGridViewTumKurumlar.DataSource = tablotumkurumlar;

            }
            catch
            {

                MessageBox.Show("hata");
            }








        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult c;
                c = MessageBox.Show(dataGridViewTumKurumlar.CurrentRow.Cells[2].Value.ToString() + " " + "Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {

                    string kurumsil = "Delete from kurum where kurum_id =@kurumid";
                    OleDbCommand komutt = new OleDbCommand(kurumsil, baglanti);
                    komutt.Parameters.AddWithValue("@kurumid", dataGridViewTumKurumlar.CurrentRow.Cells[0].Value.ToString());
                    komutt.ExecuteNonQuery();
                    MessageBox.Show("id = " + dataGridViewTumKurumlar.CurrentRow.Cells[2].Value.ToString() + " " + " Nolu Kayıt SİLİNDİ");
                    OleDbDataAdapter tumkurmlar = new OleDbDataAdapter("SELECT * from kurum", baglanti);
                    DataTable tablotumkurumlar = new DataTable();
                    tumkurmlar.Fill(tablotumkurumlar);
                    dataGridViewTumKurumlar.DataSource = tablotumkurumlar;


                }
            }
            catch
            {
                MessageBox.Show("hata");

            }




        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textclear(this);
            textaktif(this);
            labelKurumİd.Text = null;
            pictureBoxKurum.ImageLocation = null;

        }

        private void RadioButtonKurumKurumKodu_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxKurum.ImageLocation = null;
            dataGridViewTumKurumlar.DataSource = null;
            if (radioButtonKurumKurumKodu.Checked == true)
            {
                textclear(this);
                // textpasif(this);
                textBoxKurumKurumKodu.Enabled = true;
                textBoxKurumKurumKodu.Focus();
                dataGridViewTumKurumlar.DataSource = null;

            }
        }

        private void RadioButtonKurumKurumAdi_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxKurum.ImageLocation = null;
            dataGridViewTumKurumlar.DataSource = null;
            if (radioButtonKurumKurumAdi.Checked == true)
            {
                textclear(this);
                //  textpasif(this);
                textBoxKurumKurumAdi.Enabled = true;
                dataGridViewTumKurumlar.DataSource = null;
                textBoxKurumKurumAdi.Focus();

            }

        }

        private void RadioButtonKurumKurumTuru_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxKurum.ImageLocation = null;
            dataGridViewTumKurumlar.DataSource = null;
            if (radioButtonKurumKurumTuru.Checked == true)
            {
                textclear(this);
                // textpasif(this);
                textBoxKurumKurumTur.Enabled = true;
                dataGridViewTumKurumlar.DataSource = null;
                textBoxKurumKurumTur.Focus();

            }
        }

        private void ButtonKurumAra_Click(object sender, EventArgs e)
        {
            try
            {
                radioButtonKurumKurumTuru.Checked = false;

                dataGridViewTumKurumlar.DataSource = null;
                if (textBoxKurumKurumKodu.Text.Trim() != "")
                {
                    radioButtonKurumKurumKodu.Checked = false;

                    tablo8.Clear();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from kurum where kurum_kodu LIKE   '%" + textBoxKurumKurumKodu.Text + "%'  ", baglanti);
                    adtr.Fill(tablo8);
                    dataGridViewTumKurumlar.DataSource = tablo8;

                }

                if (textBoxKurumKurumAdi.Text.Trim() != "")
                {
                    radioButtonKurumKurumAdi.Checked = false;
                    dataGridViewTumKurumlar.DataSource = null;
                    tablo9.Clear();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from kurum where kurum_adi LIKE   '%" + textBoxKurumKurumAdi.Text + "%'  ", baglanti);
                    adtr.Fill(tablo9);
                    dataGridViewTumKurumlar.DataSource = tablo9;

                }

                if (textBoxKurumKurumTur.Text.Trim() != "")
                {
                    dataGridViewTumKurumlar.DataSource = null;
                    tablo10.Clear();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("SELECT * from kurum where kurum_tur  LIKE   '%" + textBoxKurumKurumTur.Text + "%'  ", baglanti);
                    adtr.Fill(tablo10);
                    dataGridViewTumKurumlar.DataSource = tablo10;

                }

                dataGridViewTumKurumlar.Columns[0].HeaderText = "Kurum id";
                dataGridViewTumKurumlar.Columns[1].HeaderText = "Kurum Adı";
                dataGridViewTumKurumlar.Columns[2].HeaderText = "Kurum Tel";
                dataGridViewTumKurumlar.Columns[3].HeaderText = "Kurum E-Posta";
                dataGridViewTumKurumlar.Columns[4].HeaderText = "Kurum Adres";
                dataGridViewTumKurumlar.Columns[5].HeaderText = "Kurum Sektor";
                dataGridViewTumKurumlar.Columns[6].HeaderText = "Kurum Şifre";
                dataGridViewTumKurumlar.Columns[7].HeaderText = "Kurum Türü";
                dataGridViewTumKurumlar.Columns[8].HeaderText = "Kurum Resim";

                dataGridViewTumKurumlar.Columns[6].Visible = false;


            }
            catch
            {

                MessageBox.Show("hata");
            }








        }

        private void DataGridViewTumKurumlar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            labelKurumİd.Text = dataGridViewTumKurumlar.CurrentRow.Cells[0].Value.ToString();
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

        private void Label27_Click(object sender, EventArgs e)
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

        private void Label36_Click(object sender, EventArgs e)
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

        private void TextBoxOgrNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            radioButtonTumOgrenciNo.Checked = false;
            radioButtonTumOgrenciAd.Checked = false;
            radioButtonTumOgrenciSoyad.Checked = false;

            OleDbDataAdapter benimogrencilerim = new OleDbDataAdapter("SELECT * from ogrenci where sicil_no ='" + labelSicilNo.Text + "' ", baglanti);
            DataTable tablobenimogrencilerim = new DataTable();
            benimogrencilerim.Fill(tablobenimogrencilerim);
            dataGridViewBenimOgrencilerim.DataSource = tablobenimogrencilerim;
            textaktif(this);
            textBoxOgrEkraniDanismanAdi.Text = labelHocaAdSoyad.Text;
            textBoxOgrEkraniDanismanSicil.Text = labelSicilNo.Text;
            textBoxOgrEkraniDanismanAdi.Enabled = false;
            textBoxOgrEkraniDanismanSicil.Enabled = false;
            textBoxOgrEkrResim.Enabled = false;
            textBoxOgrEkrCv.Enabled = false;



        }

        private void Button6_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter tumkurmlar = new OleDbDataAdapter("SELECT * from kurum", baglanti);
            DataTable tablotumkurumlar = new DataTable();
            tumkurmlar.Fill(tablotumkurumlar);
            dataGridViewTumKurumlar.DataSource = tablotumkurumlar;


            dataGridViewTumKurumlar.Columns[0].HeaderText = "Kurum id";
            dataGridViewTumKurumlar.Columns[1].HeaderText = "Kurum Kodu";
            dataGridViewTumKurumlar.Columns[2].HeaderText = "Kurum Adı";
            dataGridViewTumKurumlar.Columns[3].HeaderText = "Kurum Telefon";
            dataGridViewTumKurumlar.Columns[4].HeaderText = "Kurum E-Posta";
            dataGridViewTumKurumlar.Columns[5].HeaderText = "Kurum Adres";
            dataGridViewTumKurumlar.Columns[6].HeaderText = "Kurum Sektor";
            dataGridViewTumKurumlar.Columns[7].HeaderText = "Kurum Sifre";
            dataGridViewTumKurumlar.Columns[8].HeaderText = "Kurum Tur";
            dataGridViewTumKurumlar.Columns[9].HeaderText = "Kurum Resim";

            dataGridViewTumKurumlar.Columns[7].Visible = false;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBoxKurumKurumSifre.Text = "123456";
        }

        private void ButtonKurumResimiYukleme_Click(object sender, EventArgs e)
        {
            openFileDialog3.Title = "Yüklenecek Dosyayı Seçiniz...";
            openFileDialog3.FileName = "";
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                kaynakDosyaIsmi3 = textBoxKurumKurumKodu.Text + "__" + openFileDialog3.SafeFileName.ToString();
                kaynakDosya3 = openFileDialog3.FileName.ToString();
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

        private void OpenFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ButtonCvYukle_Click(object sender, EventArgs e)
        {

            openFileDialog1.Title = "Yüklenecek Dosyayı Seçiniz...";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakDosyaIsmi = textBoxOgrEkrNo.Text + "__" + openFileDialog1.SafeFileName.ToString();
                kaynakDosya = openFileDialog1.FileName.ToString();
                textBoxOgrEkrCv.Text = kaynakDosya;
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

            textBoxOgrEkrCv.Text = @"img\ogr_cv\" + kaynakDosyaIsmi;
            pictureBoxCv.ImageLocation = @"img\ogr_cv\" + kaynakDosyaIsmi;





        }
    }
}

