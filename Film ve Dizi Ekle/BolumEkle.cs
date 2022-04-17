using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Film_ve_Dizi_Ekle
{
    public partial class BolumEkle : Form
    {
        public bool islem = false;
        public int did, id, sno, bno;
        public string video;

        private void BolumEkle_Load(object sender, EventArgs e)
        {
            if (btnislem.Text == "Düzenle")
            {
                nudsno.Value = sno;
                nudbno.Value = bno;
                txtvideo.Text = video;
                Duzenle(sender, e);
            }
        }

        private void Duzenle(object sender, EventArgs e)
        {
            if (btnislem.Text == "Düzenle")
                btnislem.Enabled = Convert.ToInt32(nudsno.Value) != sno || txtvideo.Text != video || Convert.ToInt32(nudbno.Value) != bno;
        }

        public BolumEkle()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MedyaSec frm = new MedyaSec();
            frm.secilecektip = Oge.OgeTip.Dosya;
            frm.ShowDialog();
            if (frm.islem)
            {
                nudsno.Value = Komutlar.SayiAl(frm.secilentur);
                nudbno.Value = Komutlar.SayiAl(frm.secilen.Ad);
                txtvideo.Text = frm.secilen.Url;
            }
        }

        private void Btnislem_Click(object sender, EventArgs e)
        {
            if (txtvideo.Text == "")
            {
                MessageBox.Show("Video boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtvideo.Focus();
            }
            else
            {
                List<MySqlParameter> ogeler = new List<MySqlParameter>();
                ogeler.Add(new MySqlParameter("@sno", Convert.ToInt32(nudsno.Value)));
                ogeler.Add(new MySqlParameter("@bno", Convert.ToInt32(nudbno.Value)));
                ogeler.Add(new MySqlParameter("@video", txtvideo.Text.Trim()));
                if (btnislem.Text == "Ekle")
                {
                    ogeler.Add(new MySqlParameter("@did", did));
                    if (Komutlar.bagl.VeriEkleSilGuncelle("INSERT INTO bolum(did,sno,bno,video) VALUES(@did,@sno,@bno,@video)", ogeler) != -1)
                    {
                        MessageBox.Show("Bölüm eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islem = true;
                    }
                }
                else if (btnislem.Text == "Düzenle")
                {
                    ogeler.Add(new MySqlParameter("@id", id));
                    if (Komutlar.bagl.VeriEkleSilGuncelle("UPDATE bolum SET sno=@sno,bno=@bno,video=@video WHERE id=@id", ogeler) != -1)
                    {
                        MessageBox.Show("Bölüm düzenlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sno = Convert.ToInt32(nudsno.Value);
                        bno = Convert.ToInt32(nudbno.Value);
                        video = txtvideo.Text.Trim();
                        btnislem.Enabled = false;
                        islem = true;
                    }
                }
            }
        }
    }
}
