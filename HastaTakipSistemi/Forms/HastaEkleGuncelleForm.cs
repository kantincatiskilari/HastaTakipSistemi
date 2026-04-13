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
        private readonly bool     _guncelleModu;

      
        private Panel       panelUst, panelForm, panelAlt;
        private Label       lblBaslik;
        private Label       lblTC, lblAd, lblSoyad, lblDogum, lblCinsiyet;
        private Label       lblTelefon, lblAdres, lblKanGrubu, lblDurum;
        private TextBox     txtTC, txtAd, txtSoyad, txtTelefon, txtAdres;
        private DateTimePicker dtpDogum;
        private ComboBox    cboCinsiyet, cboKanGrubu, cboDurum;
        private Button      btnKaydet, btnIptal;
        private Label       lblHata;

        
        public HastaEkleGuncelleForm()
        {
            _hastaID      = -1;
            _guncelleModu = false;
            FormOlustur();
        }

        
        public HastaEkleGuncelleForm(int hastaID)
        {
            _hastaID      = hastaID;
            _guncelleModu = true;
            FormOlustur();
            MevcutBilgileriYukle();
        }

        private void FormOlustur()
        {
            this.Text            = _guncelleModu ? "Hasta Güncelle" : "Yeni Hasta Kayıt";
            this.Size            = new Size(540, 620);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.BackColor       = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;

            Font fBold   = new Font("Segoe UI", 9F, FontStyle.Bold);
            Font fNormal = new Font("Segoe UI", 9F);

            
            panelUst = new Panel { Dock=DockStyle.Top, Height=50, BackColor=Color.FromArgb(41,128,185) };
            lblBaslik = new Label
            {
                Text      = _guncelleModu ? "✏  Hasta Bilgilerini Güncelle" : "➕  Yeni Hasta Kaydı",
                Font      = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                Location  = new Point(16, 12),
                Size      = new Size(500, 28)
            };
            panelUst.Controls.Add(lblBaslik);

          
            panelForm = new Panel
            {
                Dock    = DockStyle.Fill,
                Padding = new Padding(24, 16, 24, 10)
            };

            int satir = 0;
            Control Alan(string baslik, Control kontrol)
            {
                int y = 8 + satir * 72;
                Label lbl = new Label { Text=baslik, Location=new Point(24, y), Size=new Size(240, 18), Font=fBold, ForeColor=Color.FromArgb(70,70,70) };
                kontrol.Location = new Point(24, y+20);
                kontrol.Size     = new Size(480, 30);
                kontrol.Font     = fNormal;
                panelForm.Controls.Add(lbl);
                panelForm.Controls.Add(kontrol);
                satir++;
                return kontrol;
            }

            txtTC     = new TextBox { MaxLength=11 };
            txtAd     = new TextBox { };
            txtSoyad  = new TextBox { };
            dtpDogum  = new DateTimePicker { Format=DateTimePickerFormat.Short, MaxDate=DateTime.Today, Value=new DateTime(1990,1,1) };
            txtTelefon= new TextBox { MaxLength=15, };

            cboCinsiyet = new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList };
            cboCinsiyet.Items.AddRange(new[]{"Erkek (E)","Kadın (K)"});
            cboCinsiyet.SelectedIndex = 0;

            cboKanGrubu = new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList };
            cboKanGrubu.Items.AddRange(new[]{"Bilinmiyor","A+","A-","B+","B-","AB+","AB-","0+","0-"});
            cboKanGrubu.SelectedIndex = 0;

            cboDurum = new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList };
            cboDurum.Items.AddRange(new[]{"Aktif","Yatan","Acil","Taburcu"});
            cboDurum.SelectedIndex = 0;

            txtAdres = new TextBox {  Multiline=false };

            Alan("TC Kimlik No *", txtTC);
            Alan("Ad *",           txtAd);
            Alan("Soyad *",        txtSoyad);
            Alan("Doğum Tarihi *", dtpDogum);
            Alan("Cinsiyet *",     cboCinsiyet);
            Alan("Telefon",        txtTelefon);
            Alan("Kan Grubu",      cboKanGrubu);
            Alan("Durum *",        cboDurum);


            if (_guncelleModu)
            {
                txtTC.ReadOnly  = true;
                txtTC.BackColor = Color.FromArgb(236, 240, 241);
            }

            lblHata = new Label
            {
                Location  = new Point(24, 8 + satir * 72),
                Size      = new Size(480, 20),
                ForeColor = Color.Crimson,
                Font      = fNormal
            };
            panelForm.Controls.Add(lblHata);

            
            panelAlt = new Panel { Dock=DockStyle.Bottom, Height=56, BackColor=Color.FromArgb(245,248,252) };
            btnKaydet = new Button
            {
                Text=_guncelleModu ? "Güncelle" : "Kaydet",
                Location=new Point(290,12), Size=new Size(110,32),
                Font=fBold, BackColor=Color.FromArgb(41,128,185), ForeColor=Color.White,
                FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand
            };
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnIptal  = new Button
            {
                Text="İptal", Location=new Point(408,12), Size=new Size(110,32),
                Font=fNormal, BackColor=Color.FromArgb(149,165,166), ForeColor=Color.White,
                FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand
            };
            btnIptal.FlatAppearance.BorderSize = 0;

            btnKaydet.Click += BtnKaydet_Click;
            btnIptal.Click  += (s, e) => this.Close();
            this.KeyPreview  = true;
            this.KeyDown    += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };

            panelAlt.Controls.AddRange(new Control[]{ btnKaydet, btnIptal });

            this.Controls.Add(panelForm);
            this.Controls.Add(panelAlt);
            this.Controls.Add(panelUst);
        }

       
        private void MevcutBilgileriYukle()
        {
            DataRow row = _hastaDAL.HastaGetirByID(_hastaID);
            if (row == null) { this.Close(); return; }

            txtTC.Text    = row["TC"].ToString();
            txtAd.Text    = row["Ad"].ToString();
            txtSoyad.Text = row["Soyad"].ToString();

            if (DateTime.TryParse(row["DogumTarihi"].ToString(), out DateTime dogum))
                dtpDogum.Value = dogum;

            cboCinsiyet.SelectedIndex = row["Cinsiyet"].ToString() == "E" ? 0 : 1;
            txtTelefon.Text           = row["Telefon"].ToString();
            txtAdres.Text             = row["Adres"].ToString();

            string kan = row["KanGrubu"].ToString();
            cboKanGrubu.SelectedItem  = cboKanGrubu.Items.Contains(kan) ? kan : "Bilinmiyor";

            string durum = row["Durum"].ToString();
            cboDurum.SelectedItem     = cboDurum.Items.Contains(durum) ? durum : "Aktif";
        }

        
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            lblHata.Text = "";

           
            if (string.IsNullOrWhiteSpace(txtTC.Text) || txtTC.Text.Trim().Length != 11)
            { lblHata.Text = "TC kimlik numarası 11 hane olmalıdır."; txtTC.Focus(); return; }

            if (!long.TryParse(txtTC.Text.Trim(), out _))
            { lblHata.Text = "TC kimlik numarası sadece rakamlardan oluşmalıdır."; txtTC.Focus(); return; }

            if (string.IsNullOrWhiteSpace(txtAd.Text))
            { lblHata.Text = "Ad alanı boş bırakılamaz."; txtAd.Focus(); return; }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            { lblHata.Text = "Soyad alanı boş bırakılamaz."; txtSoyad.Focus(); return; }

            string cinsiyet = cboCinsiyet.SelectedIndex == 0 ? "E" : "K";
            string kanGrubu = cboKanGrubu.SelectedItem.ToString() == "Bilinmiyor" ? null : cboKanGrubu.SelectedItem.ToString();
            string durum    = cboDurum.SelectedItem.ToString();
            string adres    = string.IsNullOrWhiteSpace(txtAdres.Text) ? null : txtAdres.Text.Trim();
            string telefon  = string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim();

            bool basarili;

            if (!_guncelleModu)
            {
               
                if (_hastaDAL.TCVarMi(txtTC.Text.Trim()))
                { lblHata.Text = "Bu TC kimlik numarası zaten kayıtlı!"; return; }

                basarili = _hastaDAL.HastaEkle(
                    txtTC.Text.Trim(), txtAd.Text.Trim(), txtSoyad.Text.Trim(),
                    dtpDogum.Value, cinsiyet, telefon, adres, kanGrubu, durum);

                if (basarili)
                {
                    MessageBox.Show("Hasta başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    lblHata.Text = "Kayıt sırasında bir hata oluştu.";
            }
            else
            {

                basarili = _hastaDAL.HastaGuncelle(
                    _hastaID, txtAd.Text.Trim(), txtSoyad.Text.Trim(),
                    dtpDogum.Value, cinsiyet, telefon, adres, kanGrubu, durum);

                if (basarili)
                {
                    MessageBox.Show("Hasta bilgileri güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    lblHata.Text = "Güncelleme sırasında bir hata oluştu.";
            }
        }
    }
}
