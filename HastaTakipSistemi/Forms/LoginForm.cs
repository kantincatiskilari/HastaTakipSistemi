using System;
using System.Data;
using System.Windows.Forms;
using HastaTakipSistemi.DAL;
using HastaTakipSistemi.Models;

namespace HastaTakipSistemi.Forms
{
   
    public partial class LoginForm : Form
    {
        private Panel panelUst;
        private Label lblAltBaslik;
        private Label lblBaslik;
        private Label lblKullanici;
        private TextBox txtKullanici;
        private TextBox txtSifre;
        private Label lblSifre;
        private Button btnGiris;
        private Label lblHata;
        private readonly PersonelDAL _personelDAL = new PersonelDAL();

        public LoginForm()
        {
            InitializeComponent();
            BaglantiKontrol();
        }

   
        private void BaglantiKontrol()
        {
            if (!DatabaseHelper.BaglantiTest())
            {
                lblHata.Text      = "Veritabanına bağlanılamadı!";
                btnGiris.Enabled  = false;
                MessageBox.Show(
                    "SQL Server'a bağlantı kurulamadı.\n\n" +
                    "Lütfen DatabaseHelper.cs dosyasındaki\n" +
                    "ConnectionString değerini kontrol edin.",
                    "Bağlantı Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

     
        private void btnGiris_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GirisYap();
        }

        private void GirisYap()
        {
            lblHata.Text = "";

            
            if (string.IsNullOrWhiteSpace(txtKullanici.Text))
            {
                lblHata.Text = "Kullanıcı adı boş bırakılamaz.";
                txtKullanici.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                lblHata.Text = "Şifre boş bırakılamaz.";
                txtSifre.Focus();
                return;
            }

           
            DataRow personel = _personelDAL.GirisDogrula(txtKullanici.Text, txtSifre.Text);

            if (personel != null)
            {
               
                Oturum.PersonelID   = Convert.ToInt32(personel["PersonelID"]);
                Oturum.KullaniciAdi = personel["KullaniciAdi"].ToString();
                Oturum.AdSoyad      = personel["AdSoyad"].ToString();
                Oturum.GorevUnvani  = personel["GorevUnvani"].ToString();
                Oturum.GirisDurumu  = true;

                
                AnaMenuForm menu = new AnaMenuForm();
                menu.Show();
                this.Hide();
            }
            else
            {
                lblHata.Text    = "Kullanıcı adı veya şifre hatalı.";
                txtSifre.Clear();
                txtSifre.Focus();
            }
        }
    }
}
