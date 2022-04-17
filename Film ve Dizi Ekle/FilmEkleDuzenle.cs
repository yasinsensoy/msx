using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Film_ve_Dizi_Ekle
{
    public partial class FilmEkleDuzenle : Form
    {
        public bool islem = false;
        public int id;
        public string ad, orjad, tur, dil, resim, cover, video, ozet, turler, yil, fragman, yonetmenler, oyuncular;
        public decimal imdb;
        readonly string yol = "afisler/film/";

        public FilmEkleDuzenle()
        {
            InitializeComponent();
        }

        private void pb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Title = "Resim Seç";
                file.Filter = "Resim Dosyaları (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png; *.bmp";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    ((PictureBox)sender).ImageLocation = file.FileName;
                    Duzenle(sender, e);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var sen = sender;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtfragman.Text.Substring(0, 2) == "v:")
                Process.Start($"https://vimeo.com/{txtfragman.Text.Substring(2)}");
            else
                Process.Start($"https://www.youtube.com/watch?v={txtfragman.Text}");
        }

        private void btnbobul_Click(object sender, EventArgs e)
        {
            Medyalar frm = new Medyalar();
            frm.medyalar = Komutlar.MedyaBulBoxOffice(txtad.Text);
            frm.tip = Medyalar.Tip.BOXOFFICE;
            frm.ShowDialog();
            if (frm.medya != null)
            {
                frm.medya.BoxOfficeGetir();
                pbafis.ImageLocation = frm.medya.Resim;
                txtad.Text = frm.medya.Ad;
                txtorjad.Text = frm.medya.OrjAd;
                txtturler.Text = frm.medya.Turler;
                txtyil.Text = frm.medya.Yil;
                txtozet.Text = frm.medya.Ozet;
                txtfragman.Text = frm.medya.Fragman;
                Duzenle(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fragmanlar frm = new Fragmanlar();
            frm.fragmanlar = Komutlar.FragmanBul($"{(txtorjad.Text==""? txtad.Text:txtorjad.Text)} {txtyil.Text} YouTube Movies Trailer");
            frm.ShowDialog();
            if (frm.key != "")
                txtfragman.Text = frm.key;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MedyaSec frm = new MedyaSec();
            frm.secilecektip = Oge.OgeTip.Dosya;
            frm.ShowDialog();
            if (frm.islem)
            {
                txtad.Text = frm.secilen.Ad;
                txtvideo.Text = frm.secilen.Url;
                cbtur.Text = frm.secilentur;
            }
        }

        private void TemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            pictureBox.ImageLocation = "";
            Duzenle(sender, e);
        }

        private void Btnafisbul_Click(object sender, EventArgs e)
        {
            Medyalar frm = new Medyalar();
            frm.medyalar = Komutlar.MedyaBul(txtad.Text, txtorjad.Text, txtyil.Text, Komutlar.Tur.Film);
            frm.tip = Medyalar.Tip.TMDB;
            frm.ShowDialog();
            if (frm.medya != null)
            {
                pbafis.ImageLocation = frm.medya.Resim;
                txtad.Text = frm.medya.Ad;
                txtorjad.Text = frm.medya.OrjAd;
                txtyil.Text = frm.medya.Yil;
                txtozet.Text = frm.medya.Ozet;
                txtfragman.Text = frm.medya.Fragman;
                Duzenle(sender, e);
            }
        }

        private void Btnislem_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "")
            {
                MessageBox.Show("Ad boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtad.Focus();
            }
            else if (txtvideo.Text == "")
            {
                MessageBox.Show("Video boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtvideo.Focus();
            }
            else
            {
                List<MySqlParameter> ogeler = new List<MySqlParameter>();
                ogeler.Add(new MySqlParameter("@ad", txtad.Text.Trim()));
                ogeler.Add(new MySqlParameter("@orjad", txtorjad.Text.Trim()));
                ogeler.Add(new MySqlParameter("@tur", cbtur.Text));
                ogeler.Add(new MySqlParameter("@dil", cbdil.Text));
                ogeler.Add(new MySqlParameter("@video", txtvideo.Text.Trim()));
                ogeler.Add(new MySqlParameter("@ozet", txtozet.Text.Trim()));
                ogeler.Add(new MySqlParameter("@fragman", txtfragman.Text.Trim()));
                ogeler.Add(new MySqlParameter("@imdb", nudimdb.Value));
                ogeler.Add(new MySqlParameter("@yil", Convert.ToInt32(txtyil.Text.Trim())));
                if (btnislem.Text == "Ekle")
                {
                    id = Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO film(ad,orjad,tur,dil,video,ozet,fragman,imdb,yil) VALUES(@ad,@orjad,@tur,@dil,@video,@ozet,@fragman,@imdb,@yil)", ogeler);
                    if (id != -1)
                    {
                        string adosyaad = "";
                        string cdosyaad = "";
                        if (pbafis.Image != null)
                        {
                            adosyaad = $"{id}.jpg";
                            string konum = Path.Combine(Application.StartupPath, adosyaad);
                            pbafis.Image.Save(konum, ImageFormat.Jpeg);
                            if (!Komutlar.Yukle(yol + adosyaad, konum, true))
                                return;
                        }
                        if (pbcover.Image != null)
                        {
                            cdosyaad = $"{id}_cover.jpg";
                            string konum = Path.Combine(Application.StartupPath, cdosyaad);
                            pbcover.Image.Save(konum, ImageFormat.Jpeg);
                            if (!Komutlar.Yukle(yol + cdosyaad, konum, true))
                                return;
                        }
                        ogeler.Clear();
                        ogeler.Add(new MySqlParameter("@id", id));
                        ogeler.Add(new MySqlParameter("@resim", pbafis.Image == null ? "" : yol + adosyaad));
                        ogeler.Add(new MySqlParameter("@cover", pbcover.Image == null ? "" : yol + cdosyaad));
                        Komutlar.bagl.VeriEkleSilGuncelle("UPDATE film SET resim=@resim,cover=@cover WHERE id=@id", ogeler);
                        foreach (string t in txtturler.Text.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@tur", t.Trim()));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO turler(mid,tur,tip) VALUES(@mid,@tur,'f')", ogeler);
                        }
                        foreach (string t in txtyonetmenler.Text.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@ad", t.Trim()));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO yonetmenler(mid,ad,tip) VALUES(@mid,@ad,'f')", ogeler);
                        }
                        foreach (string t in txtoyuncular.Text.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@ad", t.Trim()));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO oyuncular(mid,ad,tip) VALUES(@mid,@ad,'f')", ogeler);
                        }
                        MessageBox.Show("Film eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islem = true;
                    }
                }
                else if (btnislem.Text == "Düzenle")
                {
                    string adosyaad = "";
                    string cdosyaad = "";
                    if (pbafis.Image != null)
                    {
                        adosyaad = $"{id}.jpg";
                        string konum = Path.Combine(Application.StartupPath, adosyaad);
                        pbafis.Image.Save(konum, ImageFormat.Jpeg);
                        if (!Komutlar.Yukle(yol + adosyaad, konum, true))
                            return;
                    }
                    if (pbcover.Image != null)
                    {
                        cdosyaad = $"{id}_cover.jpg";
                        string konum = Path.Combine(Application.StartupPath, cdosyaad);
                        pbcover.Image.Save(konum, ImageFormat.Jpeg);
                        if (!Komutlar.Yukle(yol + cdosyaad, konum, true))
                            return;
                    }
                    ogeler.Add(new MySqlParameter("@resim", pbafis.Image == null ? "" : yol + adosyaad));
                    ogeler.Add(new MySqlParameter("@cover", pbcover.Image == null ? "" : yol + cdosyaad));
                    ogeler.Add(new MySqlParameter("@id", id));
                    if (Komutlar.bagl.VeriEkleSilGuncelle("UPDATE film SET ad=@ad,orjad=@orjad,tur=@tur,dil=@dil,resim=@resim,cover=@cover,video=@video,ozet=@ozet,fragman=@fragman WHERE id=@id", ogeler) != -1)
                    {
                        ogeler.Clear();
                        ogeler.Add(new MySqlParameter("@mid", id));
                        Komutlar.bagl.VeriEkleSilGuncelle("DELETE FROM turler WHERE mid=@mid; DELETE FROM oyuncular WHERE mid=@mid; DELETE FROM yonetmenler WHERE mid=@mid;", ogeler);
                        foreach (string t in txtturler.Text.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@tur", t.Trim()));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO turler(mid,tur,tip) VALUES(@mid,@tur,'f')", ogeler);
                        }
                        foreach (string t in txtyonetmenler.Text.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@ad", t.Trim()));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO yonetmenler(mid,ad,tip) VALUES(@mid,@ad,'f')", ogeler);
                        }
                        foreach (string t in txtoyuncular.Text.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@ad", t.Trim()));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO oyuncular(mid,ad,tip) VALUES(@mid,@ad,'f')", ogeler);
                        }
                        MessageBox.Show("Film düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (resim != yol + adosyaad && resim != "")
                            Komutlar.Sil(resim);
                        if (cover != yol + cdosyaad && cover != "")
                            Komutlar.Sil(cover);
                        ad = txtad.Text = txtad.Text.Trim();
                        orjad = txtorjad.Text = txtorjad.Text.Trim();
                        tur = cbtur.Text;
                        dil = cbdil.Text;
                        resim = (pbafis.Image == null ? "" : yol + adosyaad);
                        cover = (pbcover.Image == null ? "" : yol + cdosyaad);
                        video = txtvideo.Text = txtvideo.Text.Trim();
                        ozet = txtozet.Text = txtozet.Text.Trim();
                        yil = txtyil.Text = txtyil.Text.Trim();
                        turler = txtturler.Text = txtturler.Text.Trim();
                        imdb = nudimdb.Value;
                        fragman = txtfragman.Text = txtfragman.Text.Trim();
                        yonetmenler = txtyonetmenler.Text = txtyonetmenler.Text.Trim();
                        oyuncular = txtoyuncular.Text = txtoyuncular.Text.Trim();
                        btnislem.Enabled = false;
                        islem = true;
                    }
                }
            }
        }

        private void FilmEkleDuzenle_Load(object sender, EventArgs e)
        {
            cbdil.SelectedIndex = 0;
            cbtur.SelectedIndex = 0;
            if (btnislem.Text == "Düzenle")
            {
                txtad.Text = ad;
                txtorjad.Text = orjad;
                cbtur.Text = tur;
                cbdil.Text = dil;
                pbafis.ImageLocation = (resim == "" ? "" : Komutlar.msx) + resim;
                pbcover.ImageLocation = (cover == "" ? "" : Komutlar.msx) + cover;
                txtvideo.Text = video;
                txtozet.Text = ozet;
                txtturler.Text = turler;
                txtyil.Text = yil;
                nudimdb.Value = imdb;
                txtfragman.Text = fragman;
                txtoyuncular.Text = oyuncular;
                txtyonetmenler.Text = yonetmenler;
                Duzenle(sender, e);
            }
        }

        private void YapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri uri;
            if (Uri.TryCreate(Clipboard.GetText(), UriKind.Absolute, out uri))
            {
                PictureBox pictureBox = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
                pictureBox.ImageLocation = uri.OriginalString;
                Duzenle(sender, e);
            }
        }

        private void Duzenle(object sender, EventArgs e)
        {
            if (btnislem.Text == "Düzenle")
                btnislem.Enabled = nudimdb.Value != imdb || txtoyuncular.Text != oyuncular || txtyonetmenler.Text != yonetmenler || txtad.Text != ad || txtfragman.Text != fragman || txtorjad.Text != orjad || txtozet.Text != ozet || txtturler.Text != turler || txtyil.Text != yil || cbtur.Text != tur || cbdil.Text != dil || pbafis.ImageLocation != (resim == "" ? "" : Komutlar.msx) + resim || pbcover.ImageLocation != (cover == "" ? "" : Komutlar.msx) + cover || txtvideo.Text != video;
            btnafisbul.Enabled = txtad.TextLength > 0;
            btnbobul.Enabled = txtad.TextLength > 0;
            button2.Enabled = txtad.TextLength > 0;
            button3.Enabled = txtfragman.TextLength > 0;
            label7.Text = $"Özet ({txtozet.TextLength})";
        }
    }
}
