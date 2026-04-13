using System;
using System.Data;
using System.Windows.Forms;
using HastaTakipSistemi.DAL;
using HastaTakipSistemi.Models;

namespace HastaTakipSistemi.Forms
{
 
    public partial class AnaMenuForm : Form
    {
        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label lblHosgeldin;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel panelIstatistik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlAktif;
        private System.Windows.Forms.Panel pnlAcil;
        private System.Windows.Forms.Panel pnlYatan;
        private System.Windows.Forms.Label lblYatanText;
        private System.Windows.Forms.Label lblYatan;
        private System.Windows.Forms.Label lblAcilText;
        private System.Windows.Forms.Label lblAcil;
        private System.Windows.Forms.Label lblAktifText;
        private System.Windows.Forms.Label lblAktif;
        private System.Windows.Forms.Panel pnlTaburcu;
        private System.Windows.Forms.Label lblTaburcuText;
        private System.Windows.Forms.Label lblTaburcu;
        private System.Windows.Forms.Panel panelButon;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnYeniHasta;
        private System.Windows.Forms.Button btnHastaListesi;
        private readonly HastaDAL _hastaDAL = new HastaDAL();

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
            DataTable istatistik = _hastaDAL.DurumIstatistik();

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

            lblAktif.Text   = aktif.ToString();
            lblYatan.Text   = yatan.ToString();
            lblTaburcu.Text = taburcu.ToString();
            lblAcil.Text    = acil.ToString();
          
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
