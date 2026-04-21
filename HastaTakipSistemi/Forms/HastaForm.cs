using HastaTakipSistemi.Helpers;
using HastaTakipSistemi.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HastaTakipSistemi.Forms
{
   
    public partial class HastaForm : Form
    {
        private int _seciliHastaID = -1;

        public HastaForm()
        {
            InitializeComponent();
        }

        private void HastaForm_Load(object sender, EventArgs e)
        {
          
            HastalarYukle();
            dgvHastalar.AutoGenerateColumns = false;
            cboDurum.SelectedIndex = 0;
            dtpBaslangic.Value = new DateTime(1900, 1, 1);
            dtpBitis.Value = DateTime.Today;
        }

       
        private void HastalarYukle()
        {
            DataTable dt = DatabaseHelper.TumHastalariGetir();
            DgveBagla(dt);
        }

        private void DgveBagla(DataTable dt)
        {
            dgvHastalar.AutoGenerateColumns = false;

            dgvHastalar.DataSource = null;
            dgvHastalar.DataSource = dt;
            dgvHastalar.ClearSelection();

            ButonlariAyarla(false);
            _seciliHastaID = -1;
        }

        

        private DataTable TarihFiltrele(DataTable dt, DateTime baslangic, DateTime bitis)
        {
            DataTable sonuc = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (DateTime.TryParse(row["DogumTarihi"].ToString(), out DateTime dogum))
                {
                    if (dogum.Date >= baslangic && dogum.Date <= bitis)
                        sonuc.ImportRow(row);
                }
            }
            return sonuc;
        }

        private void AramaYap()
        {
            string arama = txtArama.Text.Trim();
            string durum = cboDurum.SelectedItem?.ToString() ?? "Tümü";
            DateTime baslangic = dtpBaslangic.Value.Date;
            DateTime bitis = dtpBitis.Value.Date;

            if (baslangic > bitis)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dt;

            if (!string.IsNullOrEmpty(arama))
            {
                dt = DatabaseHelper.HastaAra(arama);
                dt = TarihFiltrele(dt, baslangic, bitis);
            }
            else if (durum != "Tümü")
            {
                dt = DatabaseHelper.DurumaGoreFiltrele(durum);
                dt = TarihFiltrele(dt, baslangic, bitis);
            }
            else
            {
                dt = DatabaseHelper.DogumTarihineGoreFiltrele(baslangic, bitis);
            }

            DgveBagla(dt);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            AramaYap();
        }

        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            AramaYap();
        }

        private void dtpBitis_ValueChanged(object sender, EventArgs e)
        {
            AramaYap();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            cboDurum.SelectedIndex = 0;
            dtpBaslangic.Value = new DateTime(1900, 1, 1);
            dtpBitis.Value = DateTime.Today;
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
                if (DatabaseHelper.HastaSil(_seciliHastaID))
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

            DataTable teshisler = DatabaseHelper.TeshisleriGetir(_seciliHastaID);
            string adSoyad = dgvHastalar.SelectedRows[0].Cells["AdSoyad"].Value.ToString();

            Form frmGecmis = new TeshisGecmisForm(teshisler, adSoyad);

            frmGecmis.ShowDialog();
        }
    }
}
