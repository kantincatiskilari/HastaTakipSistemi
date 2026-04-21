namespace HastaTakipSistemi.Forms
{
    partial class HastaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelUst = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.lblDogumFiltre = new System.Windows.Forms.Label();
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
            this.HastaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdSoyad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDogumTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCinsiyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKanGrubu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuncelTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelUst.SuspendLayout();
            this.panelAlt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHastalar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.White;
            this.panelUst.Controls.Add(this.label1);
            this.panelUst.Controls.Add(this.dtpBitis);
            this.panelUst.Controls.Add(this.dtpBaslangic);
            this.panelUst.Controls.Add(this.lblDogumFiltre);
            this.panelUst.Controls.Add(this.cboDurum);
            this.panelUst.Controls.Add(this.lblFiltre);
            this.panelUst.Controls.Add(this.btnTemizle);
            this.panelUst.Controls.Add(this.btnAra);
            this.panelUst.Controls.Add(this.txtArama);
            this.panelUst.Controls.Add(this.lblArama);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(1084, 90);
            this.panelUst.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "—";
            // 
            // dtpBitis
            // 
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBitis.Location = new System.Drawing.Point(260, 55);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(120, 20);
            this.dtpBitis.TabIndex = 8;
            this.dtpBitis.ValueChanged += new System.EventHandler(this.dtpBitis_ValueChanged);
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBaslangic.Location = new System.Drawing.Point(120, 55);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(120, 20);
            this.dtpBaslangic.TabIndex = 7;
            this.dtpBaslangic.ValueChanged += new System.EventHandler(this.dtpBaslangic_ValueChanged);
            // 
            // lblDogumFiltre
            // 
            this.lblDogumFiltre.AutoSize = true;
            this.lblDogumFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDogumFiltre.Location = new System.Drawing.Point(14, 58);
            this.lblDogumFiltre.Name = "lblDogumFiltre";
            this.lblDogumFiltre.Size = new System.Drawing.Size(98, 15);
            this.lblDogumFiltre.TabIndex = 6;
            this.lblDogumFiltre.Text = "Doğum Tarihi:";
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvHastalar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHastalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHastalar.BackgroundColor = System.Drawing.Color.White;
            this.dgvHastalar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHastalar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHastalar.ColumnHeadersHeight = 32;
            this.dgvHastalar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HastaID,
            this.colTC,
            this.AdSoyad,
            this.colDogumTarihi,
            this.colCinsiyet,
            this.colTelefon,
            this.colKanGrubu,
            this.colDurum,
            this.colGuncelTarih});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHastalar.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHastalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHastalar.EnableHeadersVisualStyles = false;
            this.dgvHastalar.Location = new System.Drawing.Point(0, 90);
            this.dgvHastalar.MultiSelect = false;
            this.dgvHastalar.Name = "dgvHastalar";
            this.dgvHastalar.ReadOnly = true;
            this.dgvHastalar.RowHeadersVisible = false;
            this.dgvHastalar.RowTemplate.Height = 28;
            this.dgvHastalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHastalar.Size = new System.Drawing.Size(1084, 497);
            this.dgvHastalar.TabIndex = 4;
            this.dgvHastalar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHastalar_CellDoubleClick);
            this.dgvHastalar.SelectionChanged += new System.EventHandler(this.dgvHastalar_SelectionChanged);
            // 
            // HastaID
            // 
            this.HastaID.DataPropertyName = "HastaID";
            this.HastaID.HeaderText = "HastaID";
            this.HastaID.Name = "HastaID";
            this.HastaID.ReadOnly = true;
            this.HastaID.Visible = false;
            // 
            // colTC
            // 
            this.colTC.DataPropertyName = "TC";
            this.colTC.HeaderText = "TC Kimlik";
            this.colTC.Name = "colTC";
            this.colTC.ReadOnly = true;
            // 
            // AdSoyad
            // 
            this.AdSoyad.DataPropertyName = "AdSoyad";
            this.AdSoyad.HeaderText = "Ad Soyad";
            this.AdSoyad.Name = "AdSoyad";
            this.AdSoyad.ReadOnly = true;
            // 
            // colDogumTarihi
            // 
            this.colDogumTarihi.DataPropertyName = "DogumTarihi";
            this.colDogumTarihi.HeaderText = "Doğum Tarihi";
            this.colDogumTarihi.Name = "colDogumTarihi";
            this.colDogumTarihi.ReadOnly = true;
            // 
            // colCinsiyet
            // 
            this.colCinsiyet.DataPropertyName = "Cinsiyet";
            this.colCinsiyet.HeaderText = "Cinsiyet";
            this.colCinsiyet.Name = "colCinsiyet";
            this.colCinsiyet.ReadOnly = true;
            // 
            // colTelefon
            // 
            this.colTelefon.DataPropertyName = "Telefon";
            this.colTelefon.HeaderText = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.ReadOnly = true;
            // 
            // colKanGrubu
            // 
            this.colKanGrubu.DataPropertyName = "KanGrubu";
            this.colKanGrubu.HeaderText = "Kan Grubu";
            this.colKanGrubu.Name = "colKanGrubu";
            this.colKanGrubu.ReadOnly = true;
            // 
            // colDurum
            // 
            this.colDurum.DataPropertyName = "Durum";
            this.colDurum.HeaderText = "Durum";
            this.colDurum.Name = "colDurum";
            this.colDurum.ReadOnly = true;
            // 
            // colGuncelTarih
            // 
            this.colGuncelTarih.DataPropertyName = "GuncelTarih";
            this.colGuncelTarih.HeaderText = "Güncelleme Tarihi";
            this.colGuncelTarih.Name = "colGuncelTarih";
            this.colGuncelTarih.ReadOnly = true;
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

        #endregion

        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.ComboBox cboDurum;
        private System.Windows.Forms.Label lblFiltre;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label lblArama;
        private System.Windows.Forms.Panel panelAlt;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTeshisEkle;
        private System.Windows.Forms.Button btnTeshisGor;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.DataGridView dgvHastalar;
        private System.Windows.Forms.Label lblDogumFiltre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.DataGridViewTextBoxColumn HastaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdSoyad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDogumTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCinsiyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKanGrubu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuncelTarih;
    }
}
