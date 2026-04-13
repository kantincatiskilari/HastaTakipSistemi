using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HastaTakipSistemi.DAL;
using HastaTakipSistemi.Models;

namespace HastaTakipSistemi.Forms
{
    /// <summary>
    /// Hasta listesi, arama, durum filtreleme, güncelleme ve silme işlemlerini içerir.
    /// </summary>
    public class HastaForm : Form
    {
        private readonly HastaDAL _hastaDAL = new HastaDAL();
        private int _seciliHastaID = -1;

        
        private Panel       panelUst, panelAlt;
        private Label       lblBaslik, lblArama, lblFiltre;
        private TextBox     txtArama;
        private ComboBox    cboDurum;
        private Button      btnAra, btnTemizle, btnGuncelle, btnSil, btnTeshisEkle, btnTeshisGor;
        private DataGridView dgvHastalar;
        private StatusStrip statusBar;
        private ToolStripStatusLabel lblStatus;

        public HastaForm()
        {
            FormOlustur();
            HastalarYukle();
        }

      
        private void FormOlustur()
        {
            this.Text            = "Hasta Listesi ve Sorgulama";
            this.Size            = new Size(1100, 680);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.BackColor       = Color.White;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            Font fontNormal = new Font("Segoe UI", 9F);
            Font fontBold   = new Font("Segoe UI", 9F, FontStyle.Bold);

            
            panelUst = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 60,
                BackColor = Color.FromArgb(245, 248, 252),
                Padding   = new Padding(12, 10, 12, 10)
            };

            lblArama    = new Label  { Text="Ara (Ad, Soyad veya TC):", Location=new Point(14,20), Size=new Size(180,22), Font=fontBold };
            txtArama    = new TextBox{ Location=new Point(200,18), Size=new Size(200,26), Font=fontNormal };
            btnAra      = new Button { Text="🔍 Ara",   Location=new Point(408,16), Size=new Size(80,28), Font=fontNormal, BackColor=Color.FromArgb(41,128,185), ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
            btnAra.FlatAppearance.BorderSize = 0;
            btnTemizle  = new Button { Text="Temizle", Location=new Point(494,16), Size=new Size(72,28), Font=fontNormal, BackColor=Color.FromArgb(189,195,199), ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
            btnTemizle.FlatAppearance.BorderSize = 0;
            lblFiltre   = new Label  { Text="Durum:", Location=new Point(590,20), Size=new Size(50,22), Font=fontBold };
            cboDurum    = new ComboBox { Location=new Point(644,17), Size=new Size(120,26), Font=fontNormal, DropDownStyle=ComboBoxStyle.DropDownList };
            cboDurum.Items.AddRange(new[] {"Tümü","Aktif","Yatan","Acil","Taburcu"});
            cboDurum.SelectedIndex = 0;

            panelUst.Controls.AddRange(new Control[]{ lblArama, txtArama, btnAra, btnTemizle, lblFiltre, cboDurum });

            // ── DataGridView ──────────────────────────────────────────────
            dgvHastalar = new DataGridView
            {
                Dock                  = DockStyle.Fill,
                ReadOnly              = true,
                MultiSelect           = false,
                SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows    = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible     = false,
                BackgroundColor       = Color.White,
                BorderStyle           = BorderStyle.None,
                Font                  = fontNormal,
                AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvHastalar.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(41, 128, 185);
            dgvHastalar.ColumnHeadersDefaultCellStyle.ForeColor  = Color.White;
            dgvHastalar.ColumnHeadersDefaultCellStyle.Font       = fontBold;
            dgvHastalar.ColumnHeadersHeight = 32;
            dgvHastalar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 252);
            dgvHastalar.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(189, 215, 238);
            dgvHastalar.DefaultCellStyle.SelectionForeColor       = Color.Black;
            dgvHastalar.RowTemplate.Height = 28;
            dgvHastalar.SelectionChanged  += DgvHastalar_SelectionChanged;
            dgvHastalar.CellDoubleClick   += DgvHastalar_CellDoubleClick;

            // ── Alt panel: butonlar ───────────────────────────────────────
            panelAlt = new Panel
            {
                Dock      = DockStyle.Bottom,
                Height    = 54,
                BackColor = Color.FromArgb(245, 248, 252),
                Padding   = new Padding(12, 10, 12, 10)
            };

            btnGuncelle   = new Button { Text="✏ Güncelle",    Location=new Point(14,12),  Size=new Size(120,32), Font=fontNormal, Enabled=false, BackColor=Color.FromArgb(41,128,185), ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
            btnSil        = new Button { Text="🗑 Sil",         Location=new Point(142,12), Size=new Size(90,32),  Font=fontNormal, Enabled=false, BackColor=Color.FromArgb(192,57,43), ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
            btnTeshisEkle = new Button { Text="📝 Teşhis Ekle", Location=new Point(240,12), Size=new Size(130,32), Font=fontNormal, Enabled=false, BackColor=Color.FromArgb(39,174,96), ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
            btnTeshisGor  = new Button { Text="📋 Teşhis Geçmişi",Location=new Point(378,12),Size=new Size(145,32), Font=fontNormal, Enabled=false, BackColor=Color.FromArgb(52,152,219), ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };

            foreach (Button b in new[]{btnGuncelle, btnSil, btnTeshisEkle, btnTeshisGor})
                b.FlatAppearance.BorderSize = 0;

            panelAlt.Controls.AddRange(new Control[]{ btnGuncelle, btnSil, btnTeshisEkle, btnTeshisGor });

            // ── Status bar ─────────────────────────────────────────────────
            statusBar = new StatusStrip { BackColor = Color.FromArgb(236, 240, 241) };
            lblStatus = new ToolStripStatusLabel("Hazır") { ForeColor = Color.DimGray };
            statusBar.Items.Add(lblStatus);

            // ── Form ───────────────────────────────────────────────────────
            this.Controls.Add(dgvHastalar);
            this.Controls.Add(panelAlt);
            this.Controls.Add(panelUst);
            this.Controls.Add(statusBar);

            // Olay bağlamaları
            btnAra.Click          += (s, e) => AramaYap();
            btnTemizle.Click      += (s, e) => { txtArama.Clear(); cboDurum.SelectedIndex = 0; HastalarYukle(); };
            cboDurum.SelectedIndexChanged += (s, e) => AramaYap();
            btnGuncelle.Click     += BtnGuncelle_Click;
            btnSil.Click          += BtnSil_Click;
            btnTeshisEkle.Click   += BtnTeshisEkle_Click;
            btnTeshisGor.Click    += BtnTeshisGor_Click;
            txtArama.KeyDown      += (s, e) => { if (e.KeyCode == Keys.Enter) AramaYap(); };
        }

        // ─── VERİ YÜKLEME ─────────────────────────────────────────────────
        private void HastalarYukle()
        {
            DataTable dt = _hastaDAL.TumHastalariGetir();
            DataGridVieweBagla(dt);
        }

        private void AramaYap()
        {
            DataTable dt;
            string arama = txtArama.Text.Trim();
            string durum = cboDurum.SelectedItem?.ToString() ?? "Tümü";

            if (!string.IsNullOrEmpty(arama))
                dt = _hastaDAL.HastaAra(arama);
            else
                dt = _hastaDAL.DurumaGoreFiltrele(durum);

            DataGridVieweBagla(dt);
        }

        private void DataGridVieweBagla(DataTable dt)
        {
            dgvHastalar.DataSource = null;
            dgvHastalar.DataSource = dt;
            SutunlarDuzenle();
            lblStatus.Text = $"{dt.Rows.Count} kayıt listelendi.";
            ButonlariAyarla(false);
            _seciliHastaID = -1;
        }

        private void SutunlarDuzenle()
        {
            if (dgvHastalar.Columns.Count == 0) return;

         
            if (dgvHastalar.Columns.Contains("HastaID"))
                dgvHastalar.Columns["HastaID"].Visible = false;

            // Başlık isimleri
            var basliklar = new System.Collections.Generic.Dictionary<string, string>
            {
                {"TC","TC Kimlik"},{"AdSoyad","Ad Soyad"},{"DogumTarihi","Doğum Tarihi"},
                {"Cinsiyet","C."},{"Telefon","Telefon"},{"KanGrubu","Kan Gr."},
                {"Durum","Durum"},{"GuncelTarih","Güncelleme"}
            };

            foreach (DataGridViewColumn col in dgvHastalar.Columns)
            {
                if (basliklar.ContainsKey(col.Name))
                    col.HeaderText = basliklar[col.Name];
            }

            
            dgvHastalar.CellFormatting -= DgvHastalar_CellFormatting;
            dgvHastalar.CellFormatting += DgvHastalar_CellFormatting;
        }

        private void DgvHastalar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHastalar.Columns[e.ColumnIndex].Name == "Durum" && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "Acil":   e.CellStyle.ForeColor = Color.Crimson;                    break;
                    case "Yatan":  e.CellStyle.ForeColor = Color.FromArgb(41, 128, 185);     break;
                    case "Aktif":  e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);      break;
                    case "Taburcu":e.CellStyle.ForeColor = Color.Gray;                        break;
                }
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        
        private void DgvHastalar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHastalar.SelectedRows.Count > 0)
            {
                var row = dgvHastalar.SelectedRows[0];
                _seciliHastaID = Convert.ToInt32(row.Cells["HastaID"].Value);
                ButonlariAyarla(true);
                lblStatus.Text = $"Seçili: {row.Cells["AdSoyad"].Value}  —  TC: {row.Cells["TC"].Value}";
            }
        }

        private void DgvHastalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) BtnGuncelle_Click(null, null);
        }

        private void ButonlariAyarla(bool aktif)
        {
            btnGuncelle.Enabled   = aktif;
            btnSil.Enabled        = aktif;
            btnTeshisEkle.Enabled = aktif;
            btnTeshisGor.Enabled  = aktif;
        }

      
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (_seciliHastaID < 0) return;
            HastaEkleGuncelleForm form = new HastaEkleGuncelleForm(_seciliHastaID);
            form.ShowDialog();
            AramaYap();
        }

       
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (_seciliHastaID < 0) return;

            var secili = dgvHastalar.SelectedRows[0].Cells["AdSoyad"].Value;
            DialogResult dr = MessageBox.Show(
                $"{secili} adlı hastayı silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz.",
                "Hasta Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (_hastaDAL.HastaSil(_seciliHastaID))
                {
                    MessageBox.Show("Hasta başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HastalarYukle();
                }
            }
        }

       
        private void BtnTeshisEkle_Click(object sender, EventArgs e)
        {
            if (_seciliHastaID < 0) return;
            TeshisForm form = new TeshisForm(_seciliHastaID);
            form.ShowDialog();
        }

      
        private void BtnTeshisGor_Click(object sender, EventArgs e)
        {
            if (_seciliHastaID < 0) return;

            DataTable teshisler = _hastaDAL.TeshisleriGetir(_seciliHastaID);
            string adSoyad = dgvHastalar.SelectedRows[0].Cells["AdSoyad"].Value.ToString();

            Form frmGecmis = new Form
            {
                Text = $"Teşhis Geçmişi — {adSoyad}",
                Size = new Size(700, 400),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White
            };

            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = teshisler,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            frmGecmis.Controls.Add(dgv);
            frmGecmis.ShowDialog();
        }
    }
}
