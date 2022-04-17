using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Film_ve_Dizi_Ekle
{
    public partial class TurGuncelle : Form
    {
        public bool islem = false;
        public string ids;

        public TurGuncelle()
        {
            InitializeComponent();
        }

        private void Btnislem_Click(object sender, EventArgs e)
        {
            List<MySqlParameter> ogeler = new List<MySqlParameter>();
            ogeler.Add(new MySqlParameter("@tur", cbtur.Text));
            if (Komutlar.bagl.VeriEkleSilGuncelle($"UPDATE kanal SET tur=@tur WHERE id IN ({ids})", ogeler) != -1)
            {
                MessageBox.Show("Türler düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                islem = true;
                Close();
            }
        }

        private void TurGuncelle_Load(object sender, EventArgs e)
        {
            cbtur.SelectedIndex = 0;
        }
    }
}
