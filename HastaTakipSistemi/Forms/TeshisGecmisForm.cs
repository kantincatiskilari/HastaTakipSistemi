using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaTakipSistemi.Forms
{
    public partial class TeshisGecmisForm : Form
    {
        private readonly string _adSoyad;
        private readonly DataTable _teshisler;
        public TeshisGecmisForm(DataTable teshisler, string adSoyad)
        {
            InitializeComponent();
            _adSoyad = adSoyad;
            _teshisler = teshisler;
            dgvTeshisler.DataSource = _teshisler;
        }

        private void TeshisGecmisForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Teşhis Geçmişi - {_adSoyad}";
        }
    }
}
