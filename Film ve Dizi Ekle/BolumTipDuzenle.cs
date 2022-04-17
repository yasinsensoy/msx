using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Film_ve_Dizi_Ekle
{
    public partial class BolumTipDuzenle : Form
    {
        public bool islem = false;
        public int id;
        public string tip;

        public BolumTipDuzenle()
        {
            InitializeComponent();
            Dictionary<string, string> tip = new Dictionary<string, string>();
            tip.Add("Normal", "b");
            tip.Add("Sezon Finali", "s");
            tip.Add("Final", "f");
            cbtip.DataSource = new BindingSource(tip, null);
        }

        private void Btnislem_Click(object sender, EventArgs e)
        {
            List<MySqlParameter> ogeler = new List<MySqlParameter>();
            ogeler.Add(new MySqlParameter("@tip", cbtip.SelectedValue.ToString()));
            ogeler.Add(new MySqlParameter("@id", id));
            if (Komutlar.bagl.VeriEkleSilGuncelle("UPDATE bolum SET tip=@tip WHERE id=@id", ogeler) != -1)
            {
                MessageBox.Show("Bölüm tipi düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                islem = true;
            }
        }

        private void BolumTipDuzenle_Load(object sender, EventArgs e)
        {
            cbtip.SelectedValue = tip;
        }
    }
}
