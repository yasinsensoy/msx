using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using UPNPLib;

namespace Film_ve_Dizi_Ekle
{
    public partial class DiziEkleDuzenle : Form
    {
        public bool islem = false;
        public int id;
        public string ad, tur, resim;
        readonly string yol = "afisler/dizi/";
        Oge secilen;
        UPnPService service;

        public DiziEkleDuzenle()
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
                    dosyaad = Komutlar.Duzenle(txtad.Text) + ".jpg";
                    string konum = Path.Combine(Application.StartupPath, dosyaad);
                    pbafis.Image.Save(konum, ImageFormat.Jpeg);
                    if (!Komutlar.Yukle(yol + dosyaad, konum, true))
                        return;
                }
                List<MySqlParameter> ogeler = new List<MySqlParameter>();
                ogeler.Add(new MySqlParameter("@ad", txtad.Text.Trim()));
                ogeler.Add(new MySqlParameter("@tur", cbtur.Text));
                ogeler.Add(new MySqlParameter("@resim", (pbafis.Image == null ? "" : yol + dosyaad)));
                if (btnislem.Text == "Ekle")
                {
                    int did = Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO dizi(ad,tur,resim) VALUES(@ad,@tur,@resim)", ogeler);
                    if (did != -1)
                    {
                        if (secilen != null)
                        {
                            foreach (Oge sezon in Komutlar.AltOgeler(secilen.Id, service))
                            {
                                if (sezon.Tip == Oge.OgeTip.Dosya)
                                    continue;
                                foreach (Oge bolum in Komutlar.AltOgeler(sezon.Id, service))
                                {
                                    if (bolum.Tip == Oge.OgeTip.Klasör)
                                        continue;
                                    ogeler.Clear();
                                    ogeler.Add(new MySqlParameter("@sno", Komutlar.SayiAl(sezon.Ad)));
                                    ogeler.Add(new MySqlParameter("@bno", Komutlar.SayiAl(bolum.Ad)));
                                    ogeler.Add(new MySqlParameter("@video", bolum.Url));
                                    ogeler.Add(new MySqlParameter("@did", did));
                                    Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO bolum(did,sno,bno,video) VALUES(@did,@sno,@bno,@video)", ogeler, false);
                                }
                            }
                        }
                        MessageBox.Show("Dizi eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islem = true;
                    }
                }
                else if (btnislem.Text == "Düzenle")
                {
                    ogeler.Add(new MySqlParameter("@id", id));
                    if (Komutlar.bagl.VeriEkleSilGuncelle("UPDATE dizi SET ad=@ad,tur=@tur,resim=@resim WHERE id=@id", ogeler) != -1)
                    {
                        MessageBox.Show("Dizi düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (resim != yol + dosyaad && resim != "")
                            Komutlar.Sil(resim);
                        ad = txtad.Text = txtad.Text.Trim();
                        tur = cbtur.Text;
                        resim = (pbafis.Image == null ? "" : yol + dosyaad);
                        btnislem.Enabled = false;
                        islem = true;
                    }
                }
            }
        }

        private void DiziEkleDuzenle_Load(object sender, EventArgs e)
        {
            cbtur.SelectedIndex = 0;
            if (btnislem.Text == "Düzenle")
            {
                txtad.Text = ad;
                cbtur.Text = tur;
                pbafis.ImageLocation = (resim == "" ? "" : Komutlar.msx) + resim;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            MedyaSec frm = new MedyaSec();
            frm.secilecektip = Oge.OgeTip.Klasör;
            frm.ShowDialog();
            if (frm.islem)
            {
                secilen = frm.secilen;
                service = frm.service;
                txtad.Text = secilen.Ad;
                cbtur.Text = frm.secilentur;
            }
        }

        private void Btnafisbul_Click(object sender, EventArgs e)
        {
            //Medyalar frm = new Medyalar();
            //frm.medyalar = Komutlar.MedyaBul(txtad.Text, Komutlar.Tur.Dizi);
            //frm.ShowDialog();
            //if (frm.medya != null)
            //{
            //    pbafis.ImageLocation = frm.medya.Resim == "" ? pbafis.ImageLocation : frm.medya.Resim;
            //    txtad.Text = frm.medya.Ad;
            //    txtorjad.Text = frm.medya.OrjAd;
            //    txtturler.Text = frm.medya.Turler;
            //    txtyil.Text = frm.medya.Yil;
            //    txtozet.Text = frm.medya.Ozet;
            //    Duzenle(sender, e);
            //}
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
                btnislem.Enabled = txtad.Text != ad || cbtur.Text != tur || pbafis.ImageLocation != (resim == "" ? "" : Komutlar.msx) + resim;
            btnafisbul.Enabled = txtad.TextLength > 0;
        }
    }
}
