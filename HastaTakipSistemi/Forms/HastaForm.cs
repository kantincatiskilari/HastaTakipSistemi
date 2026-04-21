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
        private Panel panelUst;
        private TextBox txtArama;
        private Label lblArama;
        private ComboBox cboDurum;
        private Label lblFiltre;
        private Button btnTemizle;
        private Button btnAra;
        private Panel panelAlt;
        private Button btnSil;
        private Button btnTeshisEkle;
        private Button btnTeshisGor;
        private Button btnGuncelle;
        private DataGridView dgvHastalar;
        private int _seciliHastaID = -1;

        private void InitializeComponent()
        {
            this.panelUst = new System.Windows.Forms.Panel();
            this.cboDurum = new System.Windows.Forms.ComboBox();
            this.lblFiltre = new System.Windows.Forms.Label();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.lblArama = new System.Windows.Forms.Label();
            this.panelAlt = new System.Windows.Forms.Panel();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTeshisEkle = new System.Windows.Forms.Button();
            this.btnTeshisGor = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.dgvHastalar = new System.Windows.Forms.DataGridView();
            this.panelUst.SuspendLayout();
            this.panelAlt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHastalar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.White;
            this.panelUst.Controls.Add(this.cboDurum);
            this.panelUst.Controls.Add(this.lblFiltre);
            this.panelUst.Controls.Add(this.btnTemizle);
            this.panelUst.Controls.Add(this.btnAra);
            this.panelUst.Controls.Add(this.txtArama);
            this.panelUst.Controls.Add(this.lblArama);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(1084, 60);
            this.panelUst.TabIndex = 0;
            // 
            // cboDurum
            // 
            this.cboDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDurum.FormattingEnabled = true;
            this.cboDurum.Items.AddRange(new object[] {
            "Tümü",
            "Aktif",
            "Yatan",
            "Acil",
            "Taburcu"});
            this.cboDurum.Location = new System.Drawing.Point(650, 21);
            this.cboDurum.Name = "cboDurum";
            this.cboDurum.Size = new System.Drawing.Size(120, 21);
            this.cboDurum.TabIndex = 5;
            this.cboDurum.SelectedIndexChanged += new System.EventHandler(this.cboDurum_SelectedIndexChanged);
            // 
            // lblFiltre
            // 
            this.lblFiltre.AutoSize = true;
            this.lblFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiltre.Location = new System.Drawing.Point(596, 24);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(54, 15);
            this.lblFiltre.TabIndex = 4;
            this.lblFiltre.Text = "Durum:";
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Location = new System.Drawing.Point(502, 16);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(80, 28);
            this.btnTemizle.TabIndex = 3;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAra.ForeColor = System.Drawing.Color.White;
            this.btnAra.Location = new System.Drawing.Point(408, 16);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(80, 28);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // txtArama
            // 
            this.txtArama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtArama.Location = new System.Drawing.Point(200, 18);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(200, 21);
            this.txtArama.TabIndex = 1;
            this.txtArama.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArama_KeyDown);
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblArama.Location = new System.Drawing.Point(14, 20);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(162, 15);
            this.lblArama.TabIndex = 0;
            this.lblArama.Text = "Ara (Ad, Soyad veya TC):";
            // 
            // panelAlt
            // 
            this.panelAlt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panelAlt.Controls.Add(this.btnSil);
            this.panelAlt.Controls.Add(this.btnTeshisEkle);
            this.panelAlt.Controls.Add(this.btnTeshisGor);
            this.panelAlt.Controls.Add(this.btnGuncelle);
            this.panelAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAlt.Location = new System.Drawing.Point(0, 587);
            this.panelAlt.Name = "panelAlt";
            this.panelAlt.Size = new System.Drawing.Size(1084, 54);
            this.panelAlt.TabIndex = 6;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(58)))), ((int)(((byte)(43)))));
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(142, 12);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(120, 32);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTeshisEkle
            // 
            this.btnTeshisEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTeshisEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTeshisEkle.ForeColor = System.Drawing.Color.White;
            this.btnTeshisEkle.Location = new System.Drawing.Point(268, 12);
            this.btnTeshisEkle.Name = "btnTeshisEkle";
            this.btnTeshisEkle.Size = new System.Drawing.Size(130, 32);
            this.btnTeshisEkle.TabIndex = 2;
            this.btnTeshisEkle.Text = "Teşhis Ekle";
            this.btnTeshisEkle.UseVisualStyleBackColor = false;
            this.btnTeshisEkle.Click += new System.EventHandler(this.btnTeshisEkle_Click);
            // 
            // btnTeshisGor
            // 
            this.btnTeshisGor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTeshisGor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTeshisGor.ForeColor = System.Drawing.Color.White;
            this.btnTeshisGor.Location = new System.Drawing.Point(404, 12);
            this.btnTeshisGor.Name = "btnTeshisGor";
            this.btnTeshisGor.Size = new System.Drawing.Size(120, 32);
            this.btnTeshisGor.TabIndex = 1;
            this.btnTeshisGor.Text = "Teşhis Geçmişi";
            this.btnTeshisGor.UseVisualStyleBackColor = false;
            this.btnTeshisGor.Click += new System.EventHandler(this.btnTeshisGor_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(14, 12);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(120, 32);
            this.btnGuncelle.TabIndex = 0;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // dgvHastalar
            // 
            this.dgvHastalar.AllowUserToAddRows = false;
            this.dgvHastalar.AllowUserToDeleteRows = false;
            this.dgvHastalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHastalar.BackgroundColor = System.Drawing.Color.White;
            this.dgvHastalar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHastalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHastalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHastalar.Location = new System.Drawing.Point(0, 60);
            this.dgvHastalar.MultiSelect = false;
            this.dgvHastalar.Name = "dgvHastalar";
            this.dgvHastalar.ReadOnly = true;
            this.dgvHastalar.RowHeadersVisible = false;
            this.dgvHastalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHastalar.Size = new System.Drawing.Size(1084, 527);
            this.dgvHastalar.TabIndex = 4;
            this.dgvHastalar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHastalar_CellDoubleClick);
            this.dgvHastalar.SelectionChanged += new System.EventHandler(this.dgvHastalar_SelectionChanged);
            // 
            // HastaForm
            // 
            this.ClientSize = new System.Drawing.Size(1084, 641);
            this.Controls.Add(this.dgvHastalar);
            this.Controls.Add(this.panelAlt);
            this.Controls.Add(this.panelUst);
            this.Name = "HastaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hasta Listesi ve Sorgulama";
            this.Load += new System.EventHandler(this.HastaForm_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            this.panelAlt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHastalar)).EndInit();
            this.ResumeLayout(false);

        }

        public HastaForm()
        {
            InitializeComponent();
        }

        private void HastaForm_Load(object sender, EventArgs e)
        {
            DgvAyarla();
            HastalarYukle();
            cboDurum.SelectedIndex = 0;
        }

       
        private void DgvAyarla()
        {
            dgvHastalar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvHastalar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHastalar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvHastalar.ColumnHeadersHeight = 32;
            dgvHastalar.EnableHeadersVisualStyles = false;

            dgvHastalar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 252);
            dgvHastalar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(189, 215, 238);
            dgvHastalar.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvHastalar.RowTemplate.Height = 28;
        }

       
        private void HastalarYukle()
        {
            DataTable dt = _hastaDAL.TumHastalariGetir();
            DgveBagla(dt);
        }

        private void DgveBagla(DataTable dt)
        {
            dgvHastalar.DataSource = null;
            dgvHastalar.DataSource = dt;
            SutunlarDuzenle();
 
            ButonlariAyarla(false);
            _seciliHastaID = -1;
        }

        private void SutunlarDuzenle()
        {
            if (dgvHastalar.Columns.Count == 0) return;

            if (dgvHastalar.Columns.Contains("HastaID"))
                dgvHastalar.Columns["HastaID"].Visible = false;

            var basliklar = new System.Collections.Generic.Dictionary<string, string>
            {
                { "TC",          "TC Kimlik"    },
                { "AdSoyad",     "Ad Soyad"     },
                { "DogumTarihi", "Doğum Tarihi" },
                { "Cinsiyet",    "C."           },
                { "Telefon",     "Telefon"      },
                { "KanGrubu",    "Kan Gr."      },
                { "Durum",       "Durum"        },
                { "GuncelTarih", "Güncelleme"   }
            };

            foreach (DataGridViewColumn col in dgvHastalar.Columns)
                if (basliklar.ContainsKey(col.Name))
                    col.HeaderText = basliklar[col.Name];
        }

       
        private void AramaYap()
        {
            string arama = txtArama.Text.Trim();
            string durum = cboDurum.SelectedItem?.ToString() ?? "Tümü";

            DataTable dt = !string.IsNullOrEmpty(arama)
                ? _hastaDAL.HastaAra(arama)
                : _hastaDAL.DurumaGoreFiltrele(durum);

            DgveBagla(dt);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            AramaYap();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            cboDurum.SelectedIndex = 0;
            HastalarYukle();
        }

        private void cboDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            AramaYap();
        }

        private void txtArama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AramaYap();
        }

        // ─── Satır seçimi ─────────────────────────────────────────────────
        private void dgvHastalar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHastalar.SelectedRows.Count > 0)
            {
                var row = dgvHastalar.SelectedRows[0];
                _seciliHastaID = Convert.ToInt32(row.Cells["HastaID"].Value);
                ButonlariAyarla(true);
               
            }
        }

        private void dgvHastalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                BtnGuncelle_Click(null, null);
        }

        private void ButonlariAyarla(bool aktif)
        {
            btnGuncelle.Enabled = aktif;
            btnSil.Enabled = aktif;
            btnTeshisEkle.Enabled = aktif;
            btnTeshisGor.Enabled = aktif;
        }

      
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (_seciliHastaID < 0) return;
            HastaEkleGuncelleForm form = new HastaEkleGuncelleForm(_seciliHastaID);
            form.ShowDialog();
            AramaYap();
        }

        
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_seciliHastaID < 0) return;

            string adSoyad = dgvHastalar.SelectedRows[0].Cells["AdSoyad"].Value.ToString();

            DialogResult dr = MessageBox.Show(
                $"{adSoyad} adlı hastayı silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz.",
                "Hasta Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (_hastaDAL.HastaSil(_seciliHastaID))
                {
                    MessageBox.Show("Hasta başarıyla silindi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HastalarYukle();
                }
            }
        }

        
        private void btnTeshisEkle_Click(object sender, EventArgs e)
        {
            if (_seciliHastaID < 0) return;
            TeshisForm form = new TeshisForm(_seciliHastaID);
            form.ShowDialog();
        }

      
        private void btnTeshisGor_Click(object sender, EventArgs e)
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
            dgv.EnableHeadersVisualStyles = false;

            frmGecmis.Controls.Add(dgv);
            frmGecmis.ShowDialog();
        }


    }
}
