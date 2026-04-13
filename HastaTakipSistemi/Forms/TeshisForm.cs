using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HastaTakipSistemi.DAL;
using HastaTakipSistemi.Models;

namespace HastaTakipSistemi.Forms
{
    public class TeshisForm : Form
    {
        private readonly HastaDAL _hastaDAL = new HastaDAL();
        private readonly int      _hastaID;

        private Panel       panelUst, panelAlt;
        private Label       lblBaslik, lblNot, lblIlac, lblHata;
        private RichTextBox rtbTeshisNot;
        private TextBox     txtIlac;
        private Button      btnKaydet, btnIptal;

        public TeshisForm(int hastaID)
        {
            _hastaID = hastaID;
            FormOlustur();
        }

        private void FormOlustur()
        {
            DataRow hasta = _hastaDAL.HastaGetirByID(_hastaID);
            string hastaAd = hasta != null ? $"{hasta["Ad"]} {hasta["Soyad"]}" : "Hasta";

            this.Text            = $"Teşhis Ekle — {hastaAd}";
            this.Size            = new Size(500, 440);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.BackColor       = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;

            Font fBold   = new Font("Segoe UI", 9F, FontStyle.Bold);
            Font fNormal = new Font("Segoe UI", 9F);

            panelUst = new Panel { Dock=DockStyle.Top, Height=50, BackColor=Color.FromArgb(39,174,96) };
            lblBaslik = new Label { Text=$"📝  {hastaAd} — Teşhis Notu Ekle", Font=new Font("Segoe UI",12F,FontStyle.Bold), ForeColor=Color.White, Location=new Point(14,13), Size=new Size(460,26) };
            panelUst.Controls.Add(lblBaslik);

            lblNot = new Label { Text="Teşhis / Muayene Notu *", Location=new Point(24,68), Size=new Size(440,18), Font=fBold, ForeColor=Color.FromArgb(70,70,70) };
            rtbTeshisNot = new RichTextBox { Location=new Point(24,90), Size=new Size(440,160), Font=fNormal, BorderStyle=BorderStyle.FixedSingle, ScrollBars=RichTextBoxScrollBars.Vertical };

            lblIlac = new Label { Text="Verilen İlaç / Tedavi (isteğe bağlı)", Location=new Point(24,268), Size=new Size(440,18), Font=fBold, ForeColor=Color.FromArgb(70,70,70) };
            txtIlac = new TextBox { Location=new Point(24,290), Size=new Size(440,30), Font=fNormal,  };

            lblHata = new Label { Location=new Point(24,332), Size=new Size(440,18), ForeColor=Color.Crimson, Font=fNormal };

            panelAlt = new Panel { Dock=DockStyle.Bottom, Height=56, BackColor=Color.FromArgb(245,248,252) };
            btnKaydet = new Button { Text="Kaydet", Location=new Point(270,12), Size=new Size(110,32), Font=fBold, BackColor=Color.FromArgb(39,174,96), ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnIptal  = new Button { Text="İptal",  Location=new Point(388,12), Size=new Size(90,32),  Font=fNormal, BackColor=Color.FromArgb(149,165,166), ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
            btnIptal.FlatAppearance.BorderSize  = 0;

            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click  += (s, e) => this.Close();

            panelAlt.Controls.AddRange(new Control[]{ btnKaydet, btnIptal });
            this.Controls.AddRange(new Control[]{ lblNot, rtbTeshisNot, lblIlac, txtIlac, lblHata, panelAlt, panelUst });
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            lblHata.Text = "";

            if (string.IsNullOrWhiteSpace(rtbTeshisNot.Text))
            { lblHata.Text = "Teşhis notu boş bırakılamaz."; rtbTeshisNot.Focus(); return; }

            string ilac = string.IsNullOrWhiteSpace(txtIlac.Text) ? null : txtIlac.Text.Trim();

            bool basarili = _hastaDAL.TeshisEkle(_hastaID, Oturum.PersonelID, rtbTeshisNot.Text.Trim(), ilac);

            if (basarili)
            {
                MessageBox.Show("Teşhis notu kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                lblHata.Text = "Teşhis kaydedilirken hata oluştu.";
        }
    }
}
