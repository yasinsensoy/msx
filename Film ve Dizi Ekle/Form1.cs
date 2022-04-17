using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using hap = HtmlAgilityPack;

namespace Film_ve_Dizi_Ekle
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datafilmler, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datadiziler, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, databolumler, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, datakanallar, new object[] { true });
            FilmlerGuncelle();
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "tpfilmler": FilmlerGuncelle(); break;
                case "tpdiziler": DizilerGuncelle(); break;
                case "tpkanallar": KanallarGuncelle(); break;
            }
        }

        #region "Filmler"
        private void Btnfilmekle_Click(object sender, EventArgs e)
        {
            FilmEkleDuzenle frm = new FilmEkleDuzenle();
            frm.Text = "Film Ekle";
            frm.btnislem.Text = "Ekle";
            frm.ShowDialog();
            if (frm.islem)
                FilmlerGuncelle();
        }

        private void Btnfilmduzenle_Click(object sender, EventArgs e)
        {
            FilmEkleDuzenle frm = new FilmEkleDuzenle();
            frm.Text = "Film Düzenle";
            frm.btnislem.Text = "Düzenle";
            frm.id = Convert.ToInt32(datafilmler.SelectedRows[0].Cells["id"].Value);
            frm.ad = datafilmler.SelectedRows[0].Cells["ad"].Value.ToString();
            frm.orjad = datafilmler.SelectedRows[0].Cells["orjad"].Value.ToString();
            frm.tur = datafilmler.SelectedRows[0].Cells["tur"].Value.ToString();
            frm.dil = datafilmler.SelectedRows[0].Cells["dil"].Value.ToString();
            frm.yil = datafilmler.SelectedRows[0].Cells["yil"].Value.ToString();
            frm.turler = datafilmler.SelectedRows[0].Cells["turler"].Value.ToString();
            frm.yonetmenler = datafilmler.SelectedRows[0].Cells["yonetmenler"].Value.ToString();
            frm.oyuncular = datafilmler.SelectedRows[0].Cells["oyuncular"].Value.ToString();
            frm.resim = datafilmler.SelectedRows[0].Cells["resim"].Value.ToString();
            frm.cover = datafilmler.SelectedRows[0].Cells["cover"].Value.ToString();
            frm.imdb = Convert.ToDecimal(datafilmler.SelectedRows[0].Cells["imdb"].Value);
            frm.video = datafilmler.SelectedRows[0].Cells["video"].Value.ToString();
            frm.ozet = datafilmler.SelectedRows[0].Cells["ozet"].Value.ToString();
            frm.fragman = datafilmler.SelectedRows[0].Cells["fragman"].Value.ToString();
            frm.ShowDialog();
            if (frm.islem)
                FilmlerGuncelle();
        }

        private void Btnfilmsil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili filmleri silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                List<string> resimler = new List<string>();
                foreach (DataGridViewRow row in datafilmler.SelectedRows)
                {
                    resimler.Add(row.Cells["resim"].Value.ToString());
                    resimler.Add(row.Cells["cover"].Value.ToString());
                    id += (id != "" ? "," : "") + row.Cells["id"].Value.ToString();
                }
                if (Komutlar.bagl.VeriEkleSilGuncelle($"DELETE FROM film WHERE id IN ({id})") != -1)
                {
                    foreach (string item in resimler)
                        Komutlar.Sil(item);
                    MessageBox.Show("Seçilen filmler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FilmlerGuncelle(true);
                }
            }
        }

        private void Btnfilmcek_Click(object sender, EventArgs e)
        {
            MedyaSec frm = new MedyaSec();
            frm.secilecektip = Oge.OgeTip.Klasör;
            frm.ShowDialog();
            if (frm.islem)
            {
                if (frm.secilen.Ad != "Filmler")
                {
                    MessageBox.Show("Yanlış klasör seçtiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int tf = 0, ef = 0, gf = 0;
                foreach (Oge tur in Komutlar.AltOgeler(frm.secilen.Id, frm.service))
                {
                    if (tur.Tip == Oge.OgeTip.Dosya)
                        continue;
                    if (tur.Ad != "Yerli" && tur.Ad != "Yabancı")
                    {
                        MessageBox.Show("Yanlış klasör seçtiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (Oge film in Komutlar.AltOgeler(tur.Id, frm.service))
                    {
                        if (film.Tip == Oge.OgeTip.Klasör)
                            continue;
                        tf++;
                        List<MySqlParameter> ogeler = new List<MySqlParameter>();
                        ogeler.Add(new MySqlParameter("@ad", film.Ad));
                        DataTable dataTable = Komutlar.bagl.VeriGetir("SELECT id FROM film WHERE ad=@ad", ogeler, false);
                        ogeler.Clear();
                        ogeler.Add(new MySqlParameter("@video", film.Url));
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            ogeler.Add(new MySqlParameter("@id", Convert.ToInt32(dataTable.Rows[0][0])));
                            Komutlar.bagl.VeriEkleSilGuncelle("UPDATE film SET video=@video WHERE id=@id", ogeler, false);
                            gf++;
                        }
                        else
                        {
                            ogeler.Add(new MySqlParameter("@ad", film.Ad));
                            ogeler.Add(new MySqlParameter("@tur", tur.Ad));
                            ogeler.Add(new MySqlParameter("@dil", (tur.Ad == "Yerli" ? "Türkçe" : "Dublaj")));
                            ogeler.Add(new MySqlParameter("@resim", ""));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO film(ad,tur,dil,resim,video) VALUES(@ad,@tur,@dil,@resim,@video)", ogeler, false);
                            ef++;
                        }
                    }
                }
                MessageBox.Show($"Toplam: {tf}\nEklenen: {ef}\nGüncellenen: {gf}", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FilmlerGuncelle();
            }
        }

        private void FilmlerGuncelle(bool sil = false)
        {
            Komutlar.DGVKonumKaydetYukle(ref datafilmler, true, sil);
            datafilmler.DataSource = Komutlar.bagl.VeriGetir("SELECT f.id,f.ad,f.orjad,f.tur,f.dil,f.imdb,f.yil,(SELECT GROUP_CONCAT(tur) FROM turler WHERE mid=f.id) AS turler,f.fragman,f.resim,f.cover,f.video,(SELECT GROUP_CONCAT(ad) FROM yonetmenler WHERE mid=f.id) AS yonetmenler,(SELECT GROUP_CONCAT(ad) FROM oyuncular WHERE mid=f.id) AS oyuncular,f.ozet FROM film AS f WHERE fragman='' ORDER BY f.tur,f.id DESC");
        }

        private void Datafilmler_SelectionChanged(object sender, EventArgs e)
        {
            btnfilmduzenle.Enabled = datafilmler.SelectedRows.Count == 1;
            btnfilmsil.Enabled = datafilmler.SelectedRows.Count > 0;
            if (datafilmler.SelectedRows.Count == 1)
            {
                string resim = datafilmler.SelectedRows[0].Cells["resim"].Value.ToString();
                pictureBox1.ImageLocation = (resim == "" ? "" : Komutlar.msx) + resim;
                label1.Text = datafilmler.SelectedRows[0].Cells["ad"].Value.ToString();
            }
        }

        private void Datafilmler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datafilmler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            Komutlar.DGVKonumKaydetYukle(ref datafilmler, false);
            label2.Text = $"Kayıt Sayısı: {datafilmler.RowCount}";
        }
        #endregion

        #region "Diziler"
        private void Btndiziekle_Click(object sender, EventArgs e)
        {
            DiziEkleDuzenle frm = new DiziEkleDuzenle();
            frm.Text = "Dizi Ekle";
            frm.btnislem.Text = "Ekle";
            frm.ShowDialog();
            if (frm.islem)
                DizilerGuncelle();
        }

        private void Btndiziduzenle_Click(object sender, EventArgs e)
        {
            DiziEkleDuzenle frm = new DiziEkleDuzenle();
            frm.Text = "Dizi Düzenle";
            frm.btnislem.Text = "Düzenle";
            frm.id = Convert.ToInt32(datadiziler.SelectedRows[0].Cells["id"].Value);
            frm.ad = datadiziler.SelectedRows[0].Cells["ad"].Value.ToString();
            frm.tur = datadiziler.SelectedRows[0].Cells["tur"].Value.ToString();
            frm.resim = datadiziler.SelectedRows[0].Cells["resim"].Value.ToString();
            frm.ShowDialog();
            if (frm.islem)
                DizilerGuncelle();
        }

        private void Btndizisil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili dizileri silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                List<string> resimler = new List<string>();
                foreach (DataGridViewRow row in datadiziler.SelectedRows)
                {
                    resimler.Add(row.Cells["resim"].Value.ToString());
                    id += (id != "" ? "," : "") + row.Cells["id"].Value.ToString();
                }
                if (Komutlar.bagl.VeriEkleSilGuncelle($"DELETE FROM dizi WHERE id IN ({id})") != -1)
                {
                    foreach (string item in resimler)
                    {
                        Komutlar.Sil(item);
                    }
                    Komutlar.bagl.VeriEkleSilGuncelle($"DELETE FROM bolum WHERE did IN ({id})", null, false);
                    MessageBox.Show("Seçilen diziler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DizilerGuncelle(true);
                }
            }
        }

        private void Btndizicek_Click(object sender, EventArgs e)
        {
            MedyaSec frm = new MedyaSec();
            frm.secilecektip = Oge.OgeTip.Klasör;
            frm.ShowDialog();
            if (frm.islem)
            {
                if (frm.secilen.Ad != "Diziler")
                {
                    MessageBox.Show("Yanlış klasör seçtiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int td = 0, ed = 0, gd = 0, tb = 0, eb = 0, gb = 0;
                foreach (Oge tur in Komutlar.AltOgeler(frm.secilen.Id, frm.service))
                {
                    if (tur.Tip == Oge.OgeTip.Dosya)
                        continue;
                    if (tur.Ad != "Yerli" && tur.Ad != "Yabancı")
                    {
                        MessageBox.Show("Yanlış klasör seçtiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (Oge dizi in Komutlar.AltOgeler(tur.Id, frm.service))
                    {
                        if (dizi.Tip == Oge.OgeTip.Dosya)
                            continue;
                        DataGridViewRow row = datadiziler.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["ad"].Value.ToString() == dizi.Ad);
                        if (row == null)
                            continue;
                        td++;
                        List<MySqlParameter> ogeler = new List<MySqlParameter>();
                        ogeler.Add(new MySqlParameter("@ad", dizi.Ad));
                        DataTable dataTable = Komutlar.bagl.VeriGetir("SELECT id FROM dizi WHERE ad=@ad", ogeler, false);
                        int did = -1;
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            did = Convert.ToInt32(dataTable.Rows[0][0]);
                            gd++;
                        }
                        else
                        {
                            ogeler.Add(new MySqlParameter("@tur", tur.Ad));
                            ogeler.Add(new MySqlParameter("@resim", ""));
                            did = Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO dizi(ad,tur,resim) VALUES(@ad,@tur,@resim)", ogeler, false);
                            ed++;
                        }
                        if (did == -1)
                            continue;
                        foreach (Oge sezon in Komutlar.AltOgeler(dizi.Id, frm.service))
                        {
                            if (sezon.Tip == Oge.OgeTip.Dosya)
                                continue;
                            foreach (Oge bolum in Komutlar.AltOgeler(sezon.Id, frm.service))
                            {
                                if (bolum.Tip == Oge.OgeTip.Klasör)
                                    continue;
                                tb++;
                                int sno = Komutlar.SayiAl(sezon.Ad);
                                int bno = Komutlar.SayiAl(bolum.Ad);
                                ogeler.Clear();
                                ogeler.Add(new MySqlParameter("@did", did));
                                ogeler.Add(new MySqlParameter("@sno", sno));
                                ogeler.Add(new MySqlParameter("@bno", bno));
                                DataTable dataTable1 = Komutlar.bagl.VeriGetir("SELECT id FROM bolum WHERE did=@did AND sno=@sno AND bno=@bno", ogeler, false);
                                ogeler.Clear();
                                ogeler.Add(new MySqlParameter("@video", bolum.Url));
                                if (dataTable1 != null && dataTable1.Rows.Count > 0)
                                {
                                    ogeler.Add(new MySqlParameter("@id", Convert.ToInt32(dataTable1.Rows[0][0])));
                                    Komutlar.bagl.VeriEkleSilGuncelle("UPDATE bolum SET video=@video WHERE id=@id", ogeler, false);
                                    gb++;
                                }
                                else
                                {
                                    ogeler.Add(new MySqlParameter("@did", did));
                                    ogeler.Add(new MySqlParameter("@sno", sno));
                                    ogeler.Add(new MySqlParameter("@bno", bno));
                                    Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO bolum(did,sno,bno,video) VALUES(@did,@sno,@bno,@video)", ogeler, false);
                                    eb++;
                                }
                            }
                        }
                    }
                }
                MessageBox.Show($"Toplam dizi: {td}\nEklenen dizi: {ed}\nGüncellenen dizi: {gd}\n\nToplam bölüm: {tb}\nEklenen bölüm: {eb}\nGüncellenen bölüm: {gb}", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DizilerGuncelle();
            }
        }

        private void DizilerGuncelle(bool sil = false)
        {
            Komutlar.DGVKonumKaydetYukle(ref datadiziler, true, sil);
            datadiziler.DataSource = Komutlar.bagl.VeriGetir("SELECT * FROM dizi ORDER BY tur,id DESC");
        }

        private void Datadiziler_SelectionChanged(object sender, EventArgs e)
        {
            btndiziduzenle.Enabled = datadiziler.SelectedRows.Count == 1;
            btndizisil.Enabled = datadiziler.SelectedRows.Count > 0;
            BolumlerGuncelle();
        }

        private void Datadiziler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datadiziler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            Komutlar.DGVKonumKaydetYukle(ref datadiziler, false);
        }
        #endregion    

        #region "Bölümler"
        private void Btnbolumekle_Click(object sender, EventArgs e)
        {
            BolumEkle frm = new BolumEkle();
            frm.did = Convert.ToInt32(datadiziler.SelectedRows[0].Cells["id"].Value);
            frm.btnislem.Text = "Ekle";
            frm.ShowDialog();
            if (frm.islem)
                BolumlerGuncelle();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            BolumEkle frm = new BolumEkle();
            frm.id = Convert.ToInt32(databolumler.SelectedRows[0].Cells["id"].Value);
            frm.sno = Convert.ToInt32(databolumler.SelectedRows[0].Cells["sno"].Value);
            frm.bno = Convert.ToInt32(databolumler.SelectedRows[0].Cells["bno"].Value);
            frm.video = databolumler.SelectedRows[0].Cells["video"].Value.ToString();
            frm.btnislem.Text = "Düzenle";
            frm.ShowDialog();
            if (frm.islem)
                BolumlerGuncelle();
        }

        private void btnbolumtipduzenle_Click(object sender, EventArgs e)
        {
            BolumTipDuzenle frm = new BolumTipDuzenle();
            frm.id = Convert.ToInt32(databolumler.SelectedRows[0].Cells["id"].Value);
            frm.tip = databolumler.SelectedRows[0].Cells["tip"].Value.ToString();
            frm.ShowDialog();
            if (frm.islem)
                BolumlerGuncelle();
        }

        private void Btnbolumsil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili bölümleri silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                foreach (DataGridViewRow row in databolumler.SelectedRows)
                    id += (id != "" ? "," : "") + row.Cells["id"].Value.ToString();
                if (Komutlar.bagl.VeriEkleSilGuncelle($"DELETE FROM bolum WHERE id IN ({id})") != -1)
                {
                    MessageBox.Show("Seçilen bölümler başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BolumlerGuncelle(true);
                }
            }
        }

        private void BolumlerGuncelle(bool sil = false)
        {
            Komutlar.DGVKonumKaydetYukle(ref databolumler, true, sil);
            if (datadiziler.SelectedRows.Count == 1)
            {
                databolumler.DataSource = Komutlar.bagl.VeriGetir("SELECT * FROM bolum WHERE did=" + datadiziler.SelectedRows[0].Cells["id"].Value.ToString() + " ORDER BY sno DESC,bno DESC");
                btnbolumekle.Enabled = true;
            }
            else
            {
                databolumler.DataSource = Komutlar.bagl.VeriGetir("SELECT * FROM bolum WHERE did=0");
                btnbolumekle.Enabled = false;
            }
        }

        private void Databolumler_SelectionChanged(object sender, EventArgs e)
        {
            btnbolumsil.Enabled = databolumler.SelectedRows.Count > 0;
            button3.Enabled = databolumler.SelectedRows.Count == 1;
            btnbolumtipduzenle.Enabled = databolumler.SelectedRows.Count == 1;
        }

        private void Databolumler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int width = databolumler.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 25;
            int minwidth = btnbolumekle.Width + btnbolumsil.Width + 9;
            panel2.Width = (width < minwidth ? minwidth : width);
            Komutlar.DGVKonumKaydetYukle(ref databolumler, false);
        }
        #endregion

        #region "Kanallar"
        private void Btnkanalekle_Click(object sender, EventArgs e)
        {
            KanalEkleDuzenle frm = new KanalEkleDuzenle();
            frm.Text = "Kanal Ekle";
            frm.btnislem.Text = "Ekle";
            frm.ShowDialog();
            if (frm.islem)
                KanallarGuncelle();
        }

        private void Btnkanalduzenle_Click(object sender, EventArgs e)
        {
            KanalEkleDuzenle frm = new KanalEkleDuzenle();
            frm.Text = "Kanal Düzenle";
            frm.btnislem.Text = "Düzenle";
            frm.id = Convert.ToInt32(datakanallar.SelectedRows[0].Cells["id"].Value);
            frm.ad = datakanallar.SelectedRows[0].Cells["ad"].Value.ToString();
            frm.logo = datakanallar.SelectedRows[0].Cells["logo"].Value.ToString();
            frm.tur = datakanallar.SelectedRows[0].Cells["tur"].Value.ToString();
            frm.ShowDialog();
            if (frm.islem)
                KanallarGuncelle();
        }

        private void Btnkanalsil_Click(object sender, EventArgs e)
        {
            DialogResult mesaj = MessageBox.Show("Seçili kanalları silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
            {
                string id = "";
                List<string> resimler = new List<string>();
                foreach (DataGridViewRow row in datakanallar.SelectedRows)
                {
                    resimler.Add(row.Cells["logo"].Value.ToString());
                    id += (id != "" ? "," : "") + row.Cells["id"].Value.ToString();
                }
                if (Komutlar.bagl.VeriEkleSilGuncelle($"DELETE FROM kanal WHERE id IN ({id})") != -1)
                {
                    foreach (string item in resimler)
                    {
                        Komutlar.Sil(item);
                    }
                    MessageBox.Show("Seçilen kanallar başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KanallarGuncelle(true);
                }
            }
        }

        private void Btnkanalturdegis_Click(object sender, EventArgs e)
        {
            string id = "";
            foreach (DataGridViewRow row in datakanallar.SelectedRows)
                id += (id != "" ? "," : "") + row.Cells["id"].Value.ToString();
            TurGuncelle frm = new TurGuncelle();
            frm.ids = id;
            frm.ShowDialog();
            if (frm.islem)
                KanallarGuncelle();
        }

        private void Btnkanallisteekle_Click(object sender, EventArgs e)
        {
            string oku;
            string m3ulink = comboBox1.Text;
            try
            {
                using (WebClient webClient = new WebClient() { Encoding = Encoding.UTF8 })
                    oku = webClient.DownloadString(m3ulink);
                string[] kanallar = oku.Split(new string[] { "#EXTINF" }, StringSplitOptions.RemoveEmptyEntries);
                int b = 0, t = 0;
                foreach (string kanal in kanallar)
                {
                    if (!kanal.Contains("http"))
                        continue;
                    string[] icerik = kanal.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    Uri url = new Uri(icerik[1]);
                    if (url.Segments[1] == "movie/")
                        continue;
                    t++;
                    string ad = Komutlar.TagYakala(icerik[0], "tvg-name=\"", "\"");
                    string dosyaad = Komutlar.Duzenle(ad) + ".png";
                    string resim = Komutlar.TagYakala(icerik[0], "tvg-logo=\"", "\"");
                    if (resim != "")
                    {
                        string konum = Path.Combine(Application.StartupPath, dosyaad);
                        Komutlar.ResimIndir(resim, konum, ImageFormat.Png);
                        Komutlar.Yukle("afisler/kanal/" + dosyaad, konum, false);
                    }
                    List<MySqlParameter> ogeler = new List<MySqlParameter>();
                    ogeler.Add(new MySqlParameter("@ad", ad));
                    ogeler.Add(new MySqlParameter("@tur", Komutlar.TagYakala(icerik[0], "group-title=\"", "\"")));
                    ogeler.Add(new MySqlParameter("@resim", resim == "" ? "" : "afisler/kanal/" + dosyaad));
                    ogeler.Add(new MySqlParameter("@id", Convert.ToInt32(url.Segments.Last())));
                    if (Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO kanal(ad,tur,logo,id) VALUES(@ad,@tur,@resim,@id)", ogeler, false) != -1)
                        b++;
                }
                MessageBox.Show($"{t}/{b} kanal eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (b > 0)
                    KanallarGuncelle();
                if (t > 0)
                {
                    string sen = comboBox1.Items.OfType<string>().FirstOrDefault(s => s == m3ulink);
                    if (sen == null)
                    {
                        comboBox1.Items.Insert(0, m3ulink);
                        Properties.Settings.Default.items = new System.Collections.Specialized.StringCollection();
                        Properties.Settings.Default.items.AddRange(comboBox1.Items.OfType<string>().ToArray());
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KanallarGuncelle(bool sil = false)
        {
            comboBox1.Items.Clear();
            if(Properties.Settings.Default.items!=null)
            comboBox1.Items.AddRange(Properties.Settings.Default.items.OfType<string>().ToArray());
            Komutlar.DGVKonumKaydetYukle(ref datakanallar, true, sil);
            datakanallar.DataSource = Komutlar.bagl.VeriGetir("SELECT * FROM kanal ORDER BY tur,ad");
        }

        private void Datakanallar_SelectionChanged(object sender, EventArgs e)
        {
            btnkanalduzenle.Enabled = datakanallar.SelectedRows.Count == 1;
            btnkanalsil.Enabled = datakanallar.SelectedRows.Count > 0;
            btnkanalturdegis.Enabled = datakanallar.SelectedRows.Count > 0;
        }

        private void Datakanallar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            datakanallar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            Komutlar.DGVKonumKaydetYukle(ref datakanallar, false);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //int tf = 0, b = 0, h = 0; 
            //foreach (DataGridViewRow row in datafilmler.Rows)
            //{
            //    using (WebClient reader = new WebClient() { Encoding = Encoding.UTF8 })
            //    {
            //        backgroundWorker1.ReportProgress(0, $"{++tf}/{b}/{h}");
            //        string ad = row.Cells["ad"].Value.ToString();
            //        string oad = row.Cells["orjad"].Value.ToString();
            //        var okunan = (dynamic)JObject.Parse(reader.DownloadString($"https://api.themoviedb.org/3/search/movie?api_key=7404ee9071fb5ec61f5ad1ccedda50bb&language=tr-TR&query={Uri.EscapeDataString(oad == "" ? ad : oad)}&region=tr&year={row.Cells["yil"].Value}"));
            //        okunan = okunan.total_results.Value == 0 ? (dynamic)JObject.Parse(reader.DownloadString($"https://api.themoviedb.org/3/search/movie?api_key=7404ee9071fb5ec61f5ad1ccedda50bb&language=tr-TR&query={Uri.EscapeDataString(ad)}&region=tr&year={row.Cells["yil"].Value}")) : okunan;
            //        if (okunan.total_results.Value > 0)
            //        {
            //            var item = (dynamic)((JArray)okunan.results).FirstOrDefault(n=>((dynamic)n).original_title == ad || ((dynamic)n).original_title == oad || ((dynamic)n).title == ad || ((dynamic)n).title == oad);
            //            item = item == null ? okunan.results[0]:item;
            //            var oku = (dynamic)JObject.Parse(reader.DownloadString($"https://api.themoviedb.org/3/movie/{item.id.Value}?api_key=7404ee9071fb5ec61f5ad1ccedda50bb&language=tr-TR&append_to_response=translations"));
            //            string ozet = oku.overview.Value;
            //            if (ozet == "")
            //            {
            //                var en = (dynamic)((JArray)oku.translations.translations).FirstOrDefault(t => ((dynamic)t).iso_639_1 == "en");
            //                ozet = en == null ? "" : en.data.overview.Value;
            //                reader.QueryString.Add("dir", "auto/tr");
            //                reader.QueryString.Add("provider", "google");
            //                reader.QueryString.Add("text", ozet);
            //                ozet = Encoding.UTF8.GetString(reader.UploadValues("https://webmail.smartlinkcorp.com/dotrans.php", "POST", reader.QueryString));
            //                if (ozet == "")
            //                {
            //                    var rd = (dynamic)((JArray)oku.translations.translations).First;
            //                    ozet = rd == null ? "" : rd.data.overview.Value;
            //                    reader.QueryString.Clear();
            //                    reader.QueryString.Add("dir", "auto/tr");
            //                    reader.QueryString.Add("provider", "google");
            //                    reader.QueryString.Add("text", ozet);
            //                    ozet = Encoding.UTF8.GetString(reader.UploadValues("https://webmail.smartlinkcorp.com/dotrans.php", "POST", reader.QueryString));
            //                }
            //            }
            //            if(ozet != "")
            //            {
            //                List<MySqlParameter> ogeler = new List<MySqlParameter>();
            //                ogeler.Add(new MySqlParameter("@id", Convert.ToInt32(row.Cells["id"].Value)));
            //                ogeler.Add(new MySqlParameter("@ozet", ozet));
            //                Komutlar.bagl.VeriEkleSilGuncelle("UPDATE film SET ozet=@ozet WHERE id=@id", ogeler);
            //                backgroundWorker1.ReportProgress(0, $"{tf}/{++b}/{h}");
            //            }
            //            else
            //                backgroundWorker1.ReportProgress(0, $"{tf}/{b}/{++h}");
            //        }
            //        else
            //            backgroundWorker1.ReportProgress(0, $"{tf}/{b}/{++h}");
            //    }
            //}
            int ts = 0, bs = 0, bf = 0, tf = 0;
            string yol = "afisler/film/";
            using (WebClient reader = new WebClient() { Encoding = Encoding.UTF8 })
            {
                string oku = HttpUtility.HtmlDecode(reader.DownloadString("https://www.filmmodu.org/film-arsivi?genre=&imdb=&language=turkce-dublaj&order=created_at&page=1&publish_year=&quality="));
                hap.HtmlDocument doc = new hap.HtmlDocument();
                doc.LoadHtml(oku);
                var lastpage = doc.DocumentNode.SelectSingleNode("//a[@class='last-page']");
                ts = Convert.ToInt32(Komutlar.TagYakala(lastpage.Attributes["href"].Value, "page=", "&"));
                backgroundWorker1.ReportProgress(0, $"Sayfa:{ts}/{bs} Toplam Film:{tf} Eklenen Film:{bf}");
                for (int i = 1; i <= ts; i++)
                {
                    if (i > 1)
                    {
                        oku = HttpUtility.HtmlDecode(reader.DownloadString($"https://www.filmmodu.org/film-arsivi?genre=&imdb=&language=turkce-dublaj&order=created_at&page={i}&publish_year=&quality="));
                        doc.LoadHtml(oku);
                    }
                    var movie = doc.DocumentNode.SelectNodes("//div[contains(@class,'movie-list')]//div[contains(@class,'movie')]");
                    var movies = movie.Select(n => $"{n.ChildNodes["div"].ChildNodes["a"].Attributes["href"].Value}[a]{new Uri(n.ChildNodes["div"].ChildNodes["img"].Attributes["src"].Value).Segments[4].Replace("/", "")}");
                    string[] arr = movies.ToArray();
                    foreach (string link in arr)
                    {
                        backgroundWorker1.ReportProgress(0, $"Sayfa:{ts}/{bs} Toplam Film:{++tf} Eklenen Film:{bf}");
                        string[] a = link.Split(new string[] { "[a]" }, StringSplitOptions.None);
                        int id = Convert.ToInt32(a[1]);
                        List<MySqlParameter> ogeler = new List<MySqlParameter>();
                        ogeler.Add(new MySqlParameter("@id", id));
                        DataTable table = Komutlar.bagl.VeriGetir("SELECT id FROM film WHERE id=@id", ogeler);
                        if (table.Rows.Count > 0)
                            continue;
                        oku = HttpUtility.HtmlDecode(reader.DownloadString(a[0]));
                        doc.LoadHtml(oku);
                        var dad = doc.DocumentNode.SelectSingleNode("//h2[@itemprop='alternateName']");
                        string ad = dad == null ? "" : dad.InnerText.Trim();
                        var dorjad = doc.DocumentNode.SelectSingleNode("//h1[@itemprop='name']");
                        string orjad = dorjad == null ? "" : dorjad.InnerText.Trim();
                        var dfragman = doc.DocumentNode.SelectSingleNode("//iframe");
                        string fragman = dfragman == null ? "" : Komutlar.TagYakala(dfragman.Attributes["src"].Value, "embed/", "");
                        var dresim = doc.DocumentNode.SelectSingleNode("//img[@itemprop='image']");
                        string resim = dresim == null ? "" : dresim.Attributes["src"].Value.Replace("thumb_", "");
                        var dcover = doc.DocumentNode.SelectSingleNode("//meta[@property='og:image']");
                        string cover = dcover == null ? "" : dcover.Attributes["content"].Value;
                        var dimdb = doc.DocumentNode.SelectNodes("//strong").FirstOrDefault(n => n.InnerText == "IMDB");
                        decimal imdb = dimdb == null ? 0 : Convert.ToDecimal(dimdb.ParentNode.InnerText.Replace("IMDB:", "").Trim(), new CultureInfo("en-US"));
                        var dyil = doc.DocumentNode.SelectSingleNode("//span[@itemprop='dateCreated']");
                        int yil = dyil == null ? 0 : Convert.ToInt32(dyil.InnerText.Trim());
                        var dturler = doc.DocumentNode.SelectNodes("//strong").FirstOrDefault(n => n.InnerText == "Tür");
                        string turler = dturler == null ? "" : string.Join(",", dturler.ParentNode.ChildNodes.Where(n => n.Name == "a").Select(n => n.InnerText.Trim().Replace(",", "")));
                        var doyuncular = doc.DocumentNode.SelectNodes("//a[@itemprop='actor']//span");
                        string oyuncular = doyuncular == null ? "" : string.Join("[a]", doyuncular.Select(n => n.InnerText.Trim().Replace(",", "")));
                        var dyonetmenler = doc.DocumentNode.SelectNodes("//a[@itemprop='director']//span");
                        string yonetmenler = dyonetmenler == null ? "" : string.Join("[a]", dyonetmenler.Select(n => n.InnerText.Trim().Replace(",", "")));
                        var dozet = doc.DocumentNode.SelectSingleNode("//p[@itemprop='description']");
                        string ozet = dozet == null ? "" : dozet.InnerText.Replace("Film Özeti:", "").Trim().Replace("\\", "").Replace("\t", "");
                        string dosyaad = $"{id}.jpg";
                        string konum = Path.Combine(Application.StartupPath, dosyaad);
                        Komutlar.ResimIndir(resim, konum, ImageFormat.Jpeg);
                        Komutlar.Yukle(yol + dosyaad, konum, true);
                        resim = yol + dosyaad;
                        if (cover != "")
                        {
                            dosyaad = $"{id}_cover.jpg";
                            konum = Path.Combine(Application.StartupPath, dosyaad);
                            Komutlar.ResimIndir(cover, konum, ImageFormat.Jpeg);
                            Komutlar.Yukle(yol + dosyaad, konum, false);
                            cover = yol + dosyaad;
                        }
                        ogeler.Clear();
                        ogeler.Add(new MySqlParameter("@id", id));
                        ogeler.Add(new MySqlParameter("@ad", ad));
                        ogeler.Add(new MySqlParameter("@orjad", ad == orjad ? "" : orjad));
                        ogeler.Add(new MySqlParameter("@video", new Uri(a[0]).PathAndQuery));
                        ogeler.Add(new MySqlParameter("@ozet", ozet));
                        ogeler.Add(new MySqlParameter("@fragman", fragman));
                        ogeler.Add(new MySqlParameter("@resim", resim));
                        ogeler.Add(new MySqlParameter("@cover", cover));
                        ogeler.Add(new MySqlParameter("@imdb", imdb));
                        ogeler.Add(new MySqlParameter("@yil", yil));
                        Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO film(id,ad,orjad,tur,dil,video,ozet,resim,cover,fragman,imdb,yil) VALUES(@id,@ad,@orjad,'Yabancı','Dublaj',@video,@ozet,@resim,@cover,@fragman,@imdb,@yil)", ogeler);
                        foreach (string t in turler.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@tur", t));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO turler(mid,tur,tip) VALUES(@mid,@tur,'f')", ogeler);
                        }
                        foreach (string t in yonetmenler.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@ad", t));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO yonetmenler(mid,ad,tip) VALUES(@mid,@ad,'f')", ogeler);
                        }
                        foreach (string t in oyuncular.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            ogeler.Clear();
                            ogeler.Add(new MySqlParameter("@mid", id));
                            ogeler.Add(new MySqlParameter("@ad", t));
                            Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO oyuncular(mid,ad,tip) VALUES(@mid,@ad,'f')", ogeler);
                        }
                        backgroundWorker1.ReportProgress(0, $"Sayfa:{ts}/{bs} Toplam Film:{tf} Eklenen Film:{++bf}");
                    }
                    backgroundWorker1.ReportProgress(0, $"Sayfa:{ts}/{++bs} Toplam Film:{tf} Eklenen Film:{bf}");
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("bitti");
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Text = e.UserState.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datafilmler.Rows)
            {
                using (WebClient reader = new WebClient() { Encoding = Encoding.UTF8 })
                {
                    string ad = row.Cells["ad"].Value.ToString();
                    string oad = row.Cells["orjad"].Value.ToString();
                    var okunan = (dynamic)JObject.Parse(reader.DownloadString($"https://api.themoviedb.org/3/search/movie?api_key=7404ee9071fb5ec61f5ad1ccedda50bb&language=tr-TR&query={Uri.EscapeUriString(oad == "" ? ad : oad)}&region=tr&year={row.Cells["yil"].Value}"));
                    if (okunan.total_results.Value > 0)
                    {
                        var item = okunan.results[0];
                        var oku = (dynamic)JObject.Parse(reader.DownloadString($"https://api.themoviedb.org/3/movie/{item.id.Value}?api_key=7404ee9071fb5ec61f5ad1ccedda50bb&language=tr-TR&append_to_response=translations"));
                        string ozet = oku.overview.Value;
                        if (ozet == "")
                        {
                            var en = (dynamic)((JArray)oku.translations.translations).FirstOrDefault(t => ((dynamic)t).iso_639_1 == "en");
                            ozet = en == null ? "" : en.data.overview.Value;
                            var ceviri = reader.DownloadString($"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=tr&dt=t&q={Uri.EscapeUriString(ozet)}");
                            ozet = string.Join(" ", ((object[])new JavaScriptSerializer().Deserialize<List<dynamic>>(ceviri)[0]).Select(t => ((object[])t)[0]));
                            if (ozet == "")
                            {
                                var rd = (dynamic)((JArray)oku.translations.translations).First;
                                ozet = rd == null ? "" : rd.data.overview.Value;
                                var cevir = reader.DownloadString($"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=tr&dt=t&q={Uri.EscapeUriString(ozet)}");
                                ozet = string.Join(" ", ((object[])new JavaScriptSerializer().Deserialize<List<dynamic>>(cevir)[0]).Select(t => ((object[])t)[0]));
                            }
                        }
                        List<MySqlParameter> ogeler = new List<MySqlParameter>();
                        ogeler.Add(new MySqlParameter("@id", Convert.ToInt32(row.Cells["id"].Value)));
                        ogeler.Add(new MySqlParameter("@ozet", ozet));
                        Komutlar.bagl.VeriEkleSilGuncelle("UPDATE film SET ozet=@ozet WHERE id=@id", ogeler);
                    }
                }
            }
        }

        bool dacik=false;
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            dacik = true;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            dacik = false;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dacik&& comboBox1.SelectedIndex>=0)
            {
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                Properties.Settings.Default.items = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.items.AddRange(comboBox1.Items.OfType<string>().ToArray());
                Properties.Settings.Default.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string m3u = "#EXTM3U\r\n";
            foreach (DataGridViewRow item in datakanallar.Rows)
                m3u += $"#EXTINF:-1 tvg-id=\"\" tvg-name=\"{item.Cells["ad"].Value}\" tvg-logo=\"\" group-title=\"{item.Cells["tur"].Value}\",{item.Cells["ad"].Value}\r\nhttp://ftnh1881.xyz:8080/yasinsensoy/BdV4CwmwwA/{item.Cells["id"].Value}\r\n";
            File.WriteAllText(Path.Combine(Environment.GetFolderPath( Environment.SpecialFolder.Desktop),"Kanallar.m3u"), m3u, Encoding.UTF8);
        }
    }
}
