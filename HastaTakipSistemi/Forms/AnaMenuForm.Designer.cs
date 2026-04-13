namespace HastaTakipSistemi.Forms
{
    partial class AnaMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelUst = new System.Windows.Forms.Panel();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblHosgeldin = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.panelIstatistik = new System.Windows.Forms.Panel();
            this.pnlTaburcu = new System.Windows.Forms.Panel();
            this.lblTaburcuText = new System.Windows.Forms.Label();
            this.lblTaburcu = new System.Windows.Forms.Label();
            this.pnlAcil = new System.Windows.Forms.Panel();
            this.lblAcilText = new System.Windows.Forms.Label();
            this.lblAcil = new System.Windows.Forms.Label();
            this.pnlYatan = new System.Windows.Forms.Panel();
            this.lblYatanText = new System.Windows.Forms.Label();
            this.lblYatan = new System.Windows.Forms.Label();
            this.pnlAktif = new System.Windows.Forms.Panel();
            this.lblAktifText = new System.Windows.Forms.Label();
            this.lblAktif = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelButon = new System.Windows.Forms.Panel();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnYeniHasta = new System.Windows.Forms.Button();
            this.btnHastaListesi = new System.Windows.Forms.Button();
            this.panelUst.SuspendLayout();
            this.panelIstatistik.SuspendLayout();
            this.pnlTaburcu.SuspendLayout();
            this.pnlAcil.SuspendLayout();
            this.pnlYatan.SuspendLayout();
            this.pnlAktif.SuspendLayout();
            this.panelButon.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelUst.Controls.Add(this.lblTarih);
            this.panelUst.Controls.Add(this.lblHosgeldin);
            this.panelUst.Controls.Add(this.lblBaslik);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(764, 80);
            this.panelUst.TabIndex = 0;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.lblTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih.Location = new System.Drawing.Point(560, 48);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(0, 15);
            this.lblTarih.TabIndex = 2;
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.AutoSize = true;
            this.lblHosgeldin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHosgeldin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblHosgeldin.Location = new System.Drawing.Point(18, 48);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(0, 15);
            this.lblHosgeldin.TabIndex = 1;
            this.lblHosgeldin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(18, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(205, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Hasta Takip Sistemi";
            // 
            // panelIstatistik
            // 
            this.panelIstatistik.Controls.Add(this.pnlTaburcu);
            this.panelIstatistik.Controls.Add(this.pnlAcil);
            this.panelIstatistik.Controls.Add(this.pnlYatan);
            this.panelIstatistik.Controls.Add(this.pnlAktif);
            this.panelIstatistik.Controls.Add(this.label1);
            this.panelIstatistik.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIstatistik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panelIstatistik.Location = new System.Drawing.Point(0, 80);
            this.panelIstatistik.Name = "panelIstatistik";
            this.panelIstatistik.Size = new System.Drawing.Size(764, 160);
            this.panelIstatistik.TabIndex = 3;
            // 
            // pnlTaburcu
            // 
            this.pnlTaburcu.BackColor = System.Drawing.Color.Gray;
            this.pnlTaburcu.Controls.Add(this.lblTaburcuText);
            this.pnlTaburcu.Controls.Add(this.lblTaburcu);
            this.pnlTaburcu.Location = new System.Drawing.Point(594, 44);
            this.pnlTaburcu.Name = "pnlTaburcu";
            this.pnlTaburcu.Size = new System.Drawing.Size(158, 90);
            this.pnlTaburcu.TabIndex = 3;
            // 
            // lblTaburcuText
            // 
            this.lblTaburcuText.AutoSize = true;
            this.lblTaburcuText.ForeColor = System.Drawing.Color.White;
            this.lblTaburcuText.Location = new System.Drawing.Point(10, 62);
            this.lblTaburcuText.Name = "lblTaburcuText";
            this.lblTaburcuText.Size = new System.Drawing.Size(47, 13);
            this.lblTaburcuText.TabIndex = 1;
            this.lblTaburcuText.Text = "Taburcu";
            // 
            // lblTaburcu
            // 
            this.lblTaburcu.AutoSize = true;
            this.lblTaburcu.BackColor = System.Drawing.Color.Gray;
            this.lblTaburcu.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTaburcu.ForeColor = System.Drawing.Color.White;
            this.lblTaburcu.Location = new System.Drawing.Point(10, 8);
            this.lblTaburcu.Name = "lblTaburcu";
            this.lblTaburcu.Size = new System.Drawing.Size(40, 42);
            this.lblTaburcu.TabIndex = 0;
            this.lblTaburcu.Text = "0";
            // 
            // pnlAcil
            // 
            this.pnlAcil.BackColor = System.Drawing.Color.Crimson;
            this.pnlAcil.Controls.Add(this.lblAcilText);
            this.pnlAcil.Controls.Add(this.lblAcil);
            this.pnlAcil.Location = new System.Drawing.Point(402, 44);
            this.pnlAcil.Name = "pnlAcil";
            this.pnlAcil.Size = new System.Drawing.Size(158, 90);
            this.pnlAcil.TabIndex = 2;
            // 
            // lblAcilText
            // 
            this.lblAcilText.AutoSize = true;
            this.lblAcilText.ForeColor = System.Drawing.Color.White;
            this.lblAcilText.Location = new System.Drawing.Point(10, 62);
            this.lblAcilText.Name = "lblAcilText";
            this.lblAcilText.Size = new System.Drawing.Size(55, 13);
            this.lblAcilText.TabIndex = 1;
            this.lblAcilText.Text = "Acil Hasta";
            // 
            // lblAcil
            // 
            this.lblAcil.AutoSize = true;
            this.lblAcil.BackColor = System.Drawing.Color.Crimson;
            this.lblAcil.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAcil.ForeColor = System.Drawing.Color.White;
            this.lblAcil.Location = new System.Drawing.Point(10, 8);
            this.lblAcil.Name = "lblAcil";
            this.lblAcil.Size = new System.Drawing.Size(40, 42);
            this.lblAcil.TabIndex = 0;
            this.lblAcil.Text = "0";
            // 
            // pnlYatan
            // 
            this.pnlYatan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlYatan.Controls.Add(this.lblYatanText);
            this.pnlYatan.Controls.Add(this.lblYatan);
            this.pnlYatan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlYatan.Location = new System.Drawing.Point(215, 44);
            this.pnlYatan.Name = "pnlYatan";
            this.pnlYatan.Size = new System.Drawing.Size(158, 90);
            this.pnlYatan.TabIndex = 2;
            // 
            // lblYatanText
            // 
            this.lblYatanText.AutoSize = true;
            this.lblYatanText.ForeColor = System.Drawing.Color.White;
            this.lblYatanText.Location = new System.Drawing.Point(10, 62);
            this.lblYatanText.Name = "lblYatanText";
            this.lblYatanText.Size = new System.Drawing.Size(66, 13);
            this.lblYatanText.TabIndex = 1;
            this.lblYatanText.Text = "Yatan Hasta";
            // 
            // lblYatan
            // 
            this.lblYatan.AutoSize = true;
            this.lblYatan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblYatan.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYatan.ForeColor = System.Drawing.Color.White;
            this.lblYatan.Location = new System.Drawing.Point(10, 8);
            this.lblYatan.Name = "lblYatan";
            this.lblYatan.Size = new System.Drawing.Size(40, 42);
            this.lblYatan.TabIndex = 0;
            this.lblYatan.Text = "0";
            // 
            // pnlAktif
            // 
            this.pnlAktif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlAktif.Controls.Add(this.lblAktifText);
            this.pnlAktif.Controls.Add(this.lblAktif);
            this.pnlAktif.Location = new System.Drawing.Point(23, 44);
            this.pnlAktif.Name = "pnlAktif";
            this.pnlAktif.Size = new System.Drawing.Size(158, 90);
            this.pnlAktif.TabIndex = 1;
            // 
            // lblAktifText
            // 
            this.lblAktifText.AutoSize = true;
            this.lblAktifText.ForeColor = System.Drawing.Color.White;
            this.lblAktifText.Location = new System.Drawing.Point(10, 62);
            this.lblAktifText.Name = "lblAktifText";
            this.lblAktifText.Size = new System.Drawing.Size(59, 13);
            this.lblAktifText.TabIndex = 1;
            this.lblAktifText.Text = "Aktif Hasta";
            // 
            // lblAktif
            // 
            this.lblAktif.AutoSize = true;
            this.lblAktif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblAktif.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAktif.ForeColor = System.Drawing.Color.White;
            this.lblAktif.Location = new System.Drawing.Point(10, 8);
            this.lblAktif.Name = "lblAktif";
            this.lblAktif.Size = new System.Drawing.Size(40, 42);
            this.lblAktif.TabIndex = 0;
            this.lblAktif.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hasta Durum Özeti";
            // 
            // panelButon
            // 
            this.panelButon.Controls.Add(this.btnCikis);
            this.panelButon.Controls.Add(this.btnYeniHasta);
            this.panelButon.Controls.Add(this.btnHastaListesi);
            this.panelButon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButon.Location = new System.Drawing.Point(0, 421);
            this.panelButon.Name = "panelButon";
            this.panelButon.Size = new System.Drawing.Size(764, 100);
            this.panelButon.TabIndex = 2;
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(520, 27);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(244, 52);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            // 
            // btnYeniHasta
            // 
            this.btnYeniHasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnYeniHasta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnYeniHasta.ForeColor = System.Drawing.Color.White;
            this.btnYeniHasta.Location = new System.Drawing.Point(253, 27);
            this.btnYeniHasta.Name = "btnYeniHasta";
            this.btnYeniHasta.Size = new System.Drawing.Size(261, 52);
            this.btnYeniHasta.TabIndex = 1;
            this.btnYeniHasta.Text = "Yeni Hasta Kaydı";
            this.btnYeniHasta.UseVisualStyleBackColor = false;
            // 
            // btnHastaListesi
            // 
            this.btnHastaListesi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnHastaListesi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHastaListesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnHastaListesi.ForeColor = System.Drawing.Color.White;
            this.btnHastaListesi.Location = new System.Drawing.Point(3, 27);
            this.btnHastaListesi.Name = "btnHastaListesi";
            this.btnHastaListesi.Size = new System.Drawing.Size(244, 52);
            this.btnHastaListesi.TabIndex = 0;
            this.btnHastaListesi.Text = "Hasta Listesi ve Sorgulama";
            this.btnHastaListesi.UseVisualStyleBackColor = false;
            // 
            // AnaMenuForm
            // 
            this.ClientSize = new System.Drawing.Size(764, 521);
            this.Controls.Add(this.panelButon);
            this.Controls.Add(this.panelIstatistik);
            this.Controls.Add(this.panelUst);
            this.Name = "AnaMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hasta Takip Sistemi — Ana Menü";
            this.Load += new System.EventHandler(this.AnaMenuForm_Load);
            this.panelUst.ResumeLayout(false);
            this.panelUst.PerformLayout();
            this.panelIstatistik.ResumeLayout(false);
            this.panelIstatistik.PerformLayout();
            this.pnlTaburcu.ResumeLayout(false);
            this.pnlTaburcu.PerformLayout();
            this.pnlAcil.ResumeLayout(false);
            this.pnlAcil.PerformLayout();
            this.pnlYatan.ResumeLayout(false);
            this.pnlYatan.PerformLayout();
            this.pnlAktif.ResumeLayout(false);
            this.pnlAktif.PerformLayout();
            this.panelButon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       
     
    }
}
