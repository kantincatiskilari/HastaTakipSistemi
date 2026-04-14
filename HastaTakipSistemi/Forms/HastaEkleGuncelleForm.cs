using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HastaTakipSistemi.DAL;

namespace HastaTakipSistemi.Forms
{
    
    public class HastaEkleGuncelleForm : Form
    {
        private readonly HastaDAL _hastaDAL = new HastaDAL();
        private readonly int      _hastaID;
        private Panel panelUst;
        private Label lblBaslik;
        private Label lblTC;
        private TextBox txtTC;
        private TextBox txtAd;
        private Label lblAd;
        private TextBox txtSoyad;
        private DateTimePicker dtpDogum;
        private Label lblTelefon;
        private TextBox txtTelefon;
        private Label lblDurum;
        private ComboBox cboDurum;
        private Label lblHata;
        private Panel panelAlt;
        private Button btnKaydet;
        private Button btnIptal;
        private Label lblSoyad;
        private Label lblCinsiyet;
        private ComboBox cboCinsiyet;
        private ComboBox cboKanGrubu;
        private Label lblKanGrubu;
        private readonly bool     _guncelleModu;

        private void InitializeComponent()
        {
            this.panelUst = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblTC = new System.Windows.Forms.Label();
            this.txtTC = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblDogum = new System.Windows.Forms.Label();
            this.dtpDogum = new System.Windows.Forms.DateTimePicker();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.lblDurum = new System.Windows.Forms.Label();
            this.cboDurum = new System.Windows.Forms.ComboBox();
            this.lblHata = new System.Windows.Forms.Label();
            this.panelAlt = new System.Windows.Forms.Panel();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lblCinsiyet = new System.Windows.Forms.Label();
            this.cboCinsiyet = new System.Windows.Forms.ComboBox();
            this.cboKanGrubu = new System.Windows.Forms.ComboBox();
            this.lblKanGrubu = new System.Windows.Forms.Label();
            this.panelUst.SuspendLayout();
            this.panelAlt.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelUst.Controls.Add(this.lblBaslik);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(524, 50);
            this.panelUst.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(16, 13);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(167, 24);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Yeni Hasta Kaydı";
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTC.Location = new System.Drawing.Point(24, 68);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(100, 15);
            this.lblTC.TabIndex = 1;
            this.lblTC.Text = "TC Kimlik No *";
            // 
            // txtTC
            // 
            this.txtTC.Location = new System.Drawing.Point(24, 88);
            this.txtTC.MaxLength = 11;
            this.txtTC.Name = "txtTC";
            this.txtTC.Size = new System.Drawing.Size(480, 20);
            this.txtTC.TabIndex = 2;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(24, 130);
            this.txtAd.MaxLength = 11;
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(480, 20);
            this.txtAd.TabIndex = 4;
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.Location = new System.Drawing.Point(21, 112);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(33, 15);
            this.lblAd.TabIndex = 3;
            this.lblAd.Text = "Ad *";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(24, 176);
            this.txtSoyad.MaxLength = 11;
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(480, 20);
            this.txtSoyad.TabIndex = 6;
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyad.Location = new System.Drawing.Point(21, 158);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(56, 15);
            this.lblSoyad.TabIndex = 5;
            this.lblSoyad.Text = "Soyad *";
            // 
            // lblDogum
            // 
            this.lblDogum.AutoSize = true;
            this.lblDogum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDogum.Location = new System.Drawing.Point(20, 209);
            this.lblDogum.Name = "lblDogum";
            this.lblDogum.Size = new System.Drawing.Size(104, 15);
            this.lblDogum.TabIndex = 7;
            this.lblDogum.Text = "Doğum Tarihi *";
            // 
            // dtpDogum
            // 
            this.dtpDogum.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDogum.Location = new System.Drawing.Point(24, 237);
            this.dtpDogum.MaxDate = new System.DateTime(2026, 4, 14, 0, 0, 0, 0);
            this.dtpDogum.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtpDogum.Name = "dtpDogum";
            this.dtpDogum.Size = new System.Drawing.Size(480, 20);
            this.dtpDogum.TabIndex = 8;
            this.dtpDogum.Value = new System.DateTime(2026, 4, 14, 0, 0, 0, 0);
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTelefon.Location = new System.Drawing.Point(21, 319);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(55, 15);
            this.lblTelefon.TabIndex = 11;
            this.lblTelefon.Text = "Telefon";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(24, 337);
            this.txtTelefon.MaxLength = 15;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(480, 20);
            this.txtTelefon.TabIndex = 12;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Location = new System.Drawing.Point(20, 370);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(60, 15);
            this.lblDurum.TabIndex = 13;
            this.lblDurum.Text = "Durum *";
            // 
            // cboDurum
            // 
            this.cboDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDurum.FormattingEnabled = true;
            this.cboDurum.Items.AddRange(new object[] {
            "Aktif",
            "Yatan",
            "Acil",
            "Taburcu"});
            this.cboDurum.Location = new System.Drawing.Point(23, 388);
            this.cboDurum.Name = "cboDurum";
            this.cboDurum.Size = new System.Drawing.Size(480, 21);
            this.cboDurum.TabIndex = 15;
            // 
            // lblHata
            // 
            this.lblHata.AutoSize = true;
            this.lblHata.ForeColor = System.Drawing.Color.Crimson;
            this.lblHata.Location = new System.Drawing.Point(169, 492);
            this.lblHata.Name = "lblHata";
            this.lblHata.Size = new System.Drawing.Size(0, 13);
            this.lblHata.TabIndex = 16;
            // 
            // panelAlt
            // 
            this.panelAlt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panelAlt.Controls.Add(this.btnIptal);
            this.panelAlt.Controls.Add(this.btnKaydet);
            this.panelAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlt.Location = new System.Drawing.Point(0, 550);
            this.panelAlt.Name = "panelAlt";
            this.panelAlt.Size = new System.Drawing.Size(524, 56);
            this.panelAlt.TabIndex = 17;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(316, 12);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(110, 32);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(94, 12);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(110, 32);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblCinsiyet
            // 
            this.lblCinsiyet.AutoSize = true;
            this.lblCinsiyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCinsiyet.Location = new System.Drawing.Point(24, 414);
            this.lblCinsiyet.Name = "lblCinsiyet";
            this.lblCinsiyet.Size = new System.Drawing.Size(67, 15);
            this.lblCinsiyet.TabIndex = 9;
            this.lblCinsiyet.Text = "Cinsiyet *";
            // 
            // cboCinsiyet
            // 
            this.cboCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCinsiyet.FormattingEnabled = true;
            this.cboCinsiyet.Items.AddRange(new object[] {
            "Erkek (E)",
            "Kadın (K)"});
            this.cboCinsiyet.Location = new System.Drawing.Point(23, 432);
            this.cboCinsiyet.Name = "cboCinsiyet";
            this.cboCinsiyet.Size = new System.Drawing.Size(480, 21);
            this.cboCinsiyet.TabIndex = 10;
            // 
            // cboKanGrubu
            // 
            this.cboKanGrubu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKanGrubu.FormattingEnabled = true;
            this.cboKanGrubu.Items.AddRange(new object[] {
            "Bilinmiyor",
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "0+",
            "0-"});
            this.cboKanGrubu.Location = new System.Drawing.Point(24, 285);
            this.cboKanGrubu.Name = "cboKanGrubu";
            this.cboKanGrubu.Size = new System.Drawing.Size(480, 21);
            this.cboKanGrubu.TabIndex = 19;
            // 
            // lblKanGrubu
            // 
            this.lblKanGrubu.AutoSize = true;
            this.lblKanGrubu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKanGrubu.Location = new System.Drawing.Point(21, 267);
            this.lblKanGrubu.Name = "lblKanGrubu";
            this.lblKanGrubu.Size = new System.Drawing.Size(81, 15);
            this.lblKanGrubu.TabIndex = 18;
            this.lblKanGrubu.Text = "Kan Grubu*";
            // 
            // HastaEkleGuncelleForm
            // 
            this.ClientSize = new System.Drawing.Size(524, 606);
            this.Controls.Add(this.cboKanGrubu);
            this.Controls.Add(this.lblKanGrubu);
            this.Controls.Add(this.panelAlt);
            this.Controls.Add(this.lblHata);
            this.Controls.Add(this.cboDurum);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.cboCinsiyet);
            this.Controls.Add(this.lblCinsiyet);
            this.Controls.Add(this.dtpDogum);
            this.Controls.Add(this.lblDogum);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.txtTC);
            this.Controls.Add(this.lblTC);
            this.Controls.Add(this.panelUst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HastaEkleGuncelleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hasta Kaydı";
            this.Load += new System.EventHandler(this.HastaEkleGuncelleForm_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            this.panelAlt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label lblDogum;

        public HastaEkleGuncelleForm()
        {
            InitializeComponent();
            _hastaID = -1;
            _guncelleModu = false;
        }

        // Güncelleme modu
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
            dtpDogum.Value = new DateTime(1990, 1, 1);

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
            DataRow row = _hastaDAL.HastaGetirByID(_hastaID);
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

            // Doğrulama
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
                if (_hastaDAL.TCVarMi(txtTC.Text.Trim()))
                {
                    lblHata.Text = "Bu TC kimlik numarası zaten kayıtlı!";
                    return;
                }

                basarili = _hastaDAL.HastaEkle(
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
                basarili = _hastaDAL.HastaGuncelle(
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
