using HastaTakipSistemi.Helpers;
using HastaTakipSistemi.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HastaTakipSistemi.Forms
{
    public partial class HastaEkleGuncelleForm : Form
    {
        private readonly int _hastaID;
        private readonly bool _guncelleModu;

        public HastaEkleGuncelleForm()
        {
            InitializeComponent();
            _hastaID = -1;
            _guncelleModu = false;
        }

        public HastaEkleGuncelleForm(int hastaID)
        {
            InitializeComponent();
            _hastaID = hastaID;
            _guncelleModu = true;
        }

        private void HastaEkleGuncelleForm_Load(object sender, EventArgs e)
        {
            cboCinsiyet.SelectedIndex = 0;
            cboKanGrubu.SelectedIndex = 0;
            cboDurum.SelectedIndex = 0;
            dtpDogum.MaxDate = DateTime.Today;

            if (_guncelleModu)
            {
                lblBaslik.Text = "Hasta Bilgilerini Güncelle";
                btnKaydet.Text = "Güncelle";
                txtTC.ReadOnly = true;
                txtTC.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
                MevcutBilgileriYukle();
            }
        }

        private void MevcutBilgileriYukle()
        {
            DataRow row = DatabaseHelper.HastaGetirByID(_hastaID);
            if (row == null) { this.Close(); return; }

            txtTC.Text = row["TC"].ToString();
            txtAd.Text = row["Ad"].ToString();
            txtSoyad.Text = row["Soyad"].ToString();

            if (DateTime.TryParse(row["DogumTarihi"].ToString(), out DateTime dogum))
                dtpDogum.Value = dogum;

            cboCinsiyet.SelectedIndex = row["Cinsiyet"].ToString() == "E" ? 0 : 1;
            txtTelefon.Text = row["Telefon"].ToString();

            string kan = row["KanGrubu"].ToString();
            cboKanGrubu.SelectedItem = cboKanGrubu.Items.Contains(kan) ? kan : "Bilinmiyor";

            string durum = row["Durum"].ToString();
            cboDurum.SelectedItem = cboDurum.Items.Contains(durum) ? durum : "Aktif";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            lblHata.Text = "";

            if (string.IsNullOrWhiteSpace(txtTC.Text) || txtTC.Text.Trim().Length != 11)
            {
                lblHata.Text = "TC kimlik numarası 11 hane olmalıdır.";
                txtTC.Focus();
                return;
            }

            if (!long.TryParse(txtTC.Text.Trim(), out _))
            {
                lblHata.Text = "TC kimlik numarası sadece rakamlardan oluşmalıdır.";
                txtTC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                lblHata.Text = "Ad alanı boş bırakılamaz.";
                txtAd.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                lblHata.Text = "Soyad alanı boş bırakılamaz.";
                txtSoyad.Focus();
                return;
            }

            string cinsiyet = cboCinsiyet.SelectedIndex == 0 ? "E" : "K";
            string kanGrubu = cboKanGrubu.SelectedItem.ToString() == "Bilinmiyor"
                              ? null : cboKanGrubu.SelectedItem.ToString();
            string durum = cboDurum.SelectedItem.ToString();
            string telefon = string.IsNullOrWhiteSpace(txtTelefon.Text)
                              ? null : txtTelefon.Text.Trim();

            bool basarili;

            if (!_guncelleModu)
            {
                if (DatabaseHelper.TCVarMi(txtTC.Text.Trim()))
                {
                    lblHata.Text = "Bu TC kimlik numarası zaten kayıtlı!";
                    return;
                }

                basarili = DatabaseHelper.HastaEkle(
                    txtTC.Text.Trim(), txtAd.Text.Trim(), txtSoyad.Text.Trim(),
                    dtpDogum.Value, cinsiyet, telefon, null, kanGrubu, durum);

                if (basarili)
                {
                    MessageBox.Show("Hasta başarıyla kaydedildi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    lblHata.Text = "Kayıt sırasında bir hata oluştu.";
            }
            else
            {
                basarili = DatabaseHelper.HastaGuncelle(
                    _hastaID, txtAd.Text.Trim(), txtSoyad.Text.Trim(),
                    dtpDogum.Value, cinsiyet, telefon, null, kanGrubu, durum);

                if (basarili)
                {
                    MessageBox.Show("Hasta bilgileri güncellendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    lblHata.Text = "Güncelleme sırasında bir hata oluştu.";
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
