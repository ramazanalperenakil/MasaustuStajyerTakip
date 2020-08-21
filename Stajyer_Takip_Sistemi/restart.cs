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
    public partial class restart : Form
    {
        public restart()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Stajyer_takip_Sistemi.mdb");
        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (label5.Text == textBoxGuvenlikKoodu.Text)
                {

                    string sorgu = "Select soru from hoca where sicil_no =@id";
                    OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@id", textBoxId.Text);
                    string deger;
                    deger = (string)komut.ExecuteScalar();

                    label8.Text = deger;
                    if (label8.Text != "")
                    {
                        if (label8.Text == textBoxCevabi.Text)
                        {
                            string ogrencisifreguncelle = "update ogrenci set ogr_sifre=@ogrsifre where ogr_no=@ogrno";

                            OleDbCommand komuttogr = new OleDbCommand(ogrencisifreguncelle, baglanti);
                            komuttogr.Parameters.AddWithValue("@ogrsifre", textBoxYeniSifre.Text);
                            komuttogr.Parameters.AddWithValue("@ogrno", textBoxId.Text);

                            komuttogr.ExecuteNonQuery();
                            MessageBox.Show("Şifreniz Başarıyla Güncellenmiştir.");
                        }

                    }


                }
            }
            catch 
            {

                MessageBox.Show("hata");
            }
           

        }

        private void Restart_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int RastgeleSayi1 = rnd.Next(1111, 9999);
            label5.Text = RastgeleSayi1.ToString();

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.CommandText = "SELECT Güvenlik_Sorulari from GuvenlikSorulari";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            OleDbDataReader dr;
           
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Güvenlik_Sorulari"]);
            }

        }

        private void Restart_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
        }
    }
}
