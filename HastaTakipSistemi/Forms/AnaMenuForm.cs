using System;
using System.Data;
using System.Windows.Forms;
using HastaTakipSistemi.Helpers;
using HastaTakipSistemi.Models;

namespace HastaTakipSistemi.Forms
{
 
    public partial class AnaMenuForm : Form
    {
       

        public AnaMenuForm()
        {
            InitializeComponent();
        }

        private void AnaMenuForm_Load(object sender, EventArgs e)
        {
         
            lblHosgeldin.Text = $"Hoş geldiniz, {Oturum.AdSoyad}  ({Oturum.GorevUnvani})";
            lblTarih.Text     = DateTime.Now.ToString("dddd, dd MMMM yyyy  HH:mm");

            IstatistikGuncelle();
        }

        private void IstatistikGuncelle()
        {
            DataTable istatistik = DatabaseHelper.DurumIstatistik();

            int aktif = 0, yatan = 0, taburcu = 0, acil = 0;

            foreach (DataRow row in istatistik.Rows)
            {
                string durum = row["Durum"].ToString();
                int    sayi  = Convert.ToInt32(row["Sayi"]);

                switch (durum)
                {
                    case "Aktif":   
                        aktif = sayi; 
                        break;
                    case "Yatan":   
                        yatan = sayi; 
                        break;
                    case "Taburcu": 
                        taburcu = sayi; 
                        break;
                    case "Acil":    
                        acil = sayi; 
                        break;
                }
            }

            lblAktif.Text = aktif.ToString();
            lblYatan.Text = yatan.ToString();
            lblTaburcu.Text = taburcu.ToString();
            lblAcil.Text = acil.ToString();
          
        }

        private void btnHastaListesi_Click(object sender, EventArgs e)
        {
            HastaForm hastaForm = new HastaForm();
            hastaForm.ShowDialog();
            IstatistikGuncelle(); 
        }

        private void btnYeniHasta_Click(object sender, EventArgs e)
        {
            HastaEkleGuncelleForm ekleForm = new HastaEkleGuncelleForm();
            ekleForm.ShowDialog();
            IstatistikGuncelle();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Çıkmak istediğinizden emin misiniz?",
                "Çıkış",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Oturum.Temizle();
                Application.Exit();
            }
        }

       
    }
}
