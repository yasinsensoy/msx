using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Film_ve_Dizi_Ekle
{
    public partial class KanalEkleDuzenle : Form
    {
        public bool islem = false;
        public int id;
        public string ad, logo, tur;
        readonly string yol = "afisler/kanal/";

        public KanalEkleDuzenle()
        {
            InitializeComponent();
        }

        private void Btnislem_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "")
            {
                MessageBox.Show("Ad boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtad.Focus();
            }
            else
            {
                string dosyaad = "";
                if (pbafis.Image != null)
                {
                    dosyaad = Komutlar.Duzenle(txtad.Text) + ".png";
                    string konum = Path.Combine(Application.StartupPath, dosyaad);
                    pbafis.Image.Save(konum, ImageFormat.Png);
                    if (!Komutlar.Yukle(yol + dosyaad, konum, false))
                        return;
                }
                List<MySqlParameter> ogeler = new List<MySqlParameter>();
                ogeler.Add(new MySqlParameter("@ad", txtad.Text.Trim()));
                ogeler.Add(new MySqlParameter("@tur", cbtur.Text));
                ogeler.Add(new MySqlParameter("@resim", (pbafis.Image == null ? "" : yol + dosyaad)));
                ogeler.Add(new MySqlParameter("@id", Convert.ToInt32(nudid.Value)));
                if (btnislem.Text == "Ekle")
                {
                    if (Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO kanal(ad,tur,logo,id) VALUES(@ad,@tur,@resim,@id)", ogeler) != -1)
                    {
                        MessageBox.Show("Kanal eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islem = true;
                    }
                }
                else if (btnislem.Text == "Düzenle")
                {
                    ogeler.Add(new MySqlParameter("@eid", id));
                    if (Komutlar.bagl.VeriEkleSilGuncelle("UPDATE kanal SET ad=@ad,tur=@tur,logo=@resim,id=@id WHERE id=@eid", ogeler) != -1)
                    {
                        MessageBox.Show("Kanal düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (logo != yol + dosyaad && logo != "")
                            Komutlar.Sil(logo);
                        ad = txtad.Text = txtad.Text.Trim();
                        tur = cbtur.Text;
                        logo = (pbafis.Image == null ? "" : yol + dosyaad);
                        id = Convert.ToInt32(nudid.Value);
                        btnislem.Enabled = false;
                        islem = true;
                    }
                }
            }
        }

        private void KanalEkleDuzenle_Load(object sender, EventArgs e)
        {
            cbtur.SelectedIndex = 0;
            nudid.Maximum = decimal.MaxValue;
            if (btnislem.Text == "Düzenle")
            {
                txtad.Text = ad;
                cbtur.Text = tur;
                pbafis.ImageLocation = (logo == "" ? "" : Komutlar.msx) + logo;
                nudid.Value = id;
                Duzenle(sender, e);
            }
        }

        private void YapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri uri;
            if (Uri.TryCreate(Clipboard.GetText(), UriKind.Absolute, out uri))
            {
                pbafis.ImageLocation = uri.OriginalString;
                Duzenle(sender, e);
            }
        }

        private void TemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbafis.ImageLocation = "";
            Duzenle(sender, e);
        }

        private void Pbafis_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Title = "Resim Seç";
                file.Filter = "Resim Dosyaları (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png; *.bmp";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    pbafis.ImageLocation = file.FileName;
                    Duzenle(sender, e);
                }
            }
        }

        private void Duzenle(object sender, EventArgs e)
        {
            if (btnislem.Text == "Düzenle")
                btnislem.Enabled = txtad.Text != ad || pbafis.ImageLocation != (logo == "" ? "" : Komutlar.msx) + logo || Convert.ToInt32(nudid.Value) != id || cbtur.Text != tur;
        }
    }
}
