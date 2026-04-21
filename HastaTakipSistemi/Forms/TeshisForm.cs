using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HastaTakipSistemi.Helpers;
using HastaTakipSistemi.Models;

namespace HastaTakipSistemi.Forms
{
    public partial class TeshisForm : Form
    {
        private readonly int _hastaID;

        public TeshisForm(int hastaID)
        {
            InitializeComponent();
            _hastaID = hastaID;
        }

        private void TeshisForm_Load(object sender, EventArgs e)
        {
            DataRow hasta = DatabaseHelper.HastaGetirByID(_hastaID);
            if (hasta != null)
                lblBaslik.Text = $"{hasta["Ad"]} {hasta["Soyad"]} — Teşhis Notu Ekle";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            lblHata.Text = "";

            if (string.IsNullOrWhiteSpace(rtbTeshisNot.Text))
            {
                lblHata.Text = "Teşhis notu boş bırakılamaz.";
                rtbTeshisNot.Focus();
                return;
            }

            string ilac = string.IsNullOrWhiteSpace(txtIlac.Text)
                          ? null : txtIlac.Text.Trim();

            bool basarili = DatabaseHelper.TeshisEkle(
                _hastaID, Oturum.PersonelID, rtbTeshisNot.Text.Trim(), ilac);

            if (basarili)
            {
                MessageBox.Show("Teşhis notu kaydedildi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                lblHata.Text = "Teşhis kaydedilirken bir hata oluştu.";
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
