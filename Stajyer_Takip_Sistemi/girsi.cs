using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stajyer_Takip_Sistemi
{
    public partial class girsi : Form
    {
        public girsi()
        {
            InitializeComponent();
        }

        private int RastgeleSayi1;

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
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Stajyer_takip_Sistemi.mdb");



        private void Girsi_Load(object sender, EventArgs e)
        {
            groupBoxOgrGiris.Visible = false;
            groupBoxHoca.Visible = false;
            groupBoxKurum.Visible = false;
            baglanti.Open();



            Random rnd = new Random();
            int RastgeleSayi1 = rnd.Next(1111, 9999);
            LBLOgrGuvenlik.Text = RastgeleSayi1.ToString();
            LBLHocaGuvenlik.Text = RastgeleSayi1.ToString();
            LBLKurumGuvenlik.Text = RastgeleSayi1.ToString();
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            KurumGirisSecimEkerani.Visible = true;
            OgrenciGirisSecimEkerani.Visible = true;
            OgretmenGirisSecimEkerani.Visible = true;
            groupBoxHoca.Visible = false;
            groupBoxOgrGiris.Visible = false;
            groupBoxKurum.Visible = false;

        }
        ogrencimenu frm;
        HocaMenu2 frm2;
        kurummenu frm3;
        Kayit frmkayit;

        private void PictureBoxOgrenciGirisi_Click(object sender, EventArgs e)
        {
            if (LBLOgrGuvenlik.Text == textBoxDogrulamaKodu.Text)
            {
                
                OleDbCommand komut = new OleDbCommand("select * from ogrenci where ogr_no = '" + textBoxOgrNo.Text + "' and ogr_sifre = '" + textBoxOgrSifre.Text + "' ", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    if (frm == null || frm.IsDisposed)
                    {
                        frm = new ogrencimenu();
                        frm.Show();
                        this.Hide();
                    }
                    else if (!frm.Visible)
                    {
                        //frm.Visible = true;
                        frm.Visible = !frm.Visible;
                    }
                    else
                    {
                        frm.Activate();
                    }
                    frm.labelOgrenciNumarasi.Text = textBoxOgrNo.Text;

                }

                else
                {

                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Random rnd = new Random();
                    int RastgeleSayi1 = rnd.Next(1111, 9999);
                    LBLOgrGuvenlik.Text = RastgeleSayi1.ToString();
                    textclear(this);

                }
            


               
            }
            else
            {
                MessageBox.Show("Doğrulama Kodunu Yanlış Girdiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Random rnd = new Random();
                int RastgeleSayi1 = rnd.Next(1111, 9999);
                LBLOgrGuvenlik.Text = RastgeleSayi1.ToString();
                //groupBoxOgrGiris
                textBoxDogrulamaKodu.Text = null;
            }
            
        }

        private void OgrenciGirisEkrani_Click(object sender, EventArgs e)
        {
            OgretmenGirisSecimEkerani.Visible = false;
            KurumGirisSecimEkerani.Visible = false;
            groupBoxOgrGiris.Visible = true;
     

        }

        private void OgretmenGirisEkrani_Click(object sender, EventArgs e)
        {
            groupBoxHoca.Visible = true;
            KurumGirisSecimEkerani.Visible = false;
            OgrenciGirisSecimEkerani.Visible = false;

        }

        private void KurumGirisEkrani_Click(object sender, EventArgs e)
        {
            OgretmenGirisSecimEkerani.Visible = false;
            OgrenciGirisSecimEkerani.Visible = false;
            groupBoxKurum.Visible = true;
         
        }

        private void HocaGiris_Click(object sender, EventArgs e)
        {



            if (LBLHocaGuvenlik.Text == textBoxHocaDogrulama.Text)
            {
                
                OleDbCommand komut = new OleDbCommand("select * from hoca where sicil_no = '" + textBoxOgretmenSicil.Text + "' and hoca_sifre = '" + textBoxOgretmenSifre.Text + "' ", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    if (frm2 == null || frm.IsDisposed)
                    {
                        frm2 = new HocaMenu2();
                        frm2.Show();
                        this.Hide();
                    }
                    else if (!frm.Visible)
                    {
                        //frm.Visible = true;
                        frm2.Visible = !frm.Visible;
                    }
                    else
                    {
                        frm2.Activate();
                    }
                    frm2.labelSicilNo.Text = textBoxOgretmenSicil.Text;
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Random rnd = new Random();
                    int RastgeleSayi1 = rnd.Next(1111, 9999);
                    LBLHocaGuvenlik.Text = RastgeleSayi1.ToString();
                    textBoxOgretmenSicil.Text = null;
                    textBoxOgretmenSifre.Text = null;
                    textBoxHocaDogrulama.Text = null;


                }
                

            }
            else
            {
                MessageBox.Show("Doğrulama Kodunu Yanlış Girdiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Random rnd = new Random();
                int RastgeleSayi1 = rnd.Next(1111, 9999);
                LBLHocaGuvenlik.Text = RastgeleSayi1.ToString();
                textBoxHocaDogrulama.Clear();

            }


            
        }

        private void PictureBoxKurumGiris_Click(object sender, EventArgs e)
        {
            if (LBLKurumGuvenlik.Text == textBoxKurumGuvenlik.Text)
            {
                
                OleDbCommand komut = new OleDbCommand("select * from kurum where kurum_kodu = '" + textBoxKurumKodu.Text + "' and kurum_sifre = '" + textBoxKurumSifre.Text + "' ", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    if (frm3 == null || frm.IsDisposed)
                    {
                        frm3 = new kurummenu();
                        frm3.Show();
                        this.Hide();
                    }
                    else if (!frm3.Visible)
                    {
                        //frm.Visible = true;
                        frm3.Visible = !frm3.Visible;
                    }
                    else
                    {
                        frm3.Activate();
                    }
                    
                    frm3.labelKurumKodu.Text = textBoxKurumKodu.Text;
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Random rnd = new Random();
                    int RastgeleSayi1 = rnd.Next(1111, 9999);
                    LBLKurumGuvenlik.Text = RastgeleSayi1.ToString();
                    textBoxKurumKodu.Text = null;
                    textBoxKurumSifre.Text = null;
                    textBoxKurumGuvenlik.Text = null;
                }
                
            }
            else
            {
                MessageBox.Show("Doğrulama Kodunu Yanlış Girdiniz", "UYARI", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Random rnd = new Random();
                int RastgeleSayi1 = rnd.Next(1111, 9999);
                LBLKurumGuvenlik.Text = RastgeleSayi1.ToString();
                textBoxKurumGuvenlik.Text = null;
            }

        }

        private void Girsi_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
            Application.Exit();
        }

        private void GroupBoxHoca_Enter(object sender, EventArgs e)
        {

        }

        private void HocaGirisYap_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
                frmkayit = new Kayit();
                frmkayit.Show();
                
           
        }
        restart frm4;
        private void Button2_Click(object sender, EventArgs e)
        {
            frm4 = new restart();
            frm4.Show();
        }
    }
}
