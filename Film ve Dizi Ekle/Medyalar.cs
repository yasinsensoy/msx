using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Film_ve_Dizi_Ekle
{
    public partial class Medyalar : Form
    {
        public List<Medya> medyalar;
        public Medya medya;
        public Tip tip;
        private int ct, cg, pt, pg;
        public enum Tip { TMDB, BOXOFFICE }

        public Medyalar()
        {
            InitializeComponent();
        }

        private void Afisler_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (tip == Tip.BOXOFFICE)
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("Ad");
                listView1.Columns.Add("Türler");
                textBox1.Visible = false;
            }
            foreach (Medya m in medyalar)
            {
                ListViewItem item = listView1.Items.Add(m.Ad);
                if (tip == Tip.TMDB)
                    item.SubItems.Add(m.OrjAd);
                item.SubItems.Add(m.Turler);
                if (tip == Tip.TMDB)
                {
                    item.SubItems.Add(m.Yil);
                    item.SubItems.Add(m.Fragman);
                    item.SubItems.Add(m.Yonetmenler);
                    item.SubItems.Add(m.Oyuncular);
                }
                item.Tag = m;
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            int genislik = 0;
            foreach (ColumnHeader sutun in listView1.Columns)
                genislik += sutun.Text == "Oyuncular"?200: sutun.Width;
            listView1.Left = pictureBox1.Width + (textBox1.Visible ? textBox1.Width : 0);
            listView1.Width = genislik + 21;
            if (listView1.Items.Count > 0)
                listView1.Items[0].Selected = true;
            CenterToParent();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                medya = (Medya)listView1.SelectedItems[0].Tag;
                Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Medya m = (Medya)listView1.SelectedItems[0].Tag;
                pictureBox1.ImageLocation = m.Getir(Medya.ResimTip.Poster, Medya.Komut.Sonraki, true);
                pictureBox2.ImageLocation = m.Getir(Medya.ResimTip.Cover, Medya.Komut.Sonraki, true);
                pt = m.Posters.Length;
                ct = m.Covers.Length;
                cg = 1;
                    pg = 1;
                textBox1.Text = m.Ozet;
            }
            else
            {
                pictureBox1.ImageLocation = "";
                pictureBox2.ImageLocation = "";
                textBox1.Text = "";
                pt = 0;
                ct = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = pt > 0 ? $"{pg}/{pt}": "";
            label2.Text = ct > 0 ? $"{cg}/{ct}" : "";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listView1.SelectedItems.Count == 1)
            {
                Medya m = (Medya)listView1.SelectedItems[0].Tag;
                string s = m.Getir(Medya.ResimTip.Poster, e.X >= pictureBox1.Width / 2 ? Medya.Komut.Sonraki : Medya.Komut.Onceki);
                if (s != "")
                {
                    pictureBox1.ImageLocation = s;
                    pg = e.X >= pictureBox1.Width / 2 ? pg + 1 : pg - 1;
                }
            }
            pictureBox1.Focus();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listView1.SelectedItems.Count == 1)
            {
                Medya m = (Medya)listView1.SelectedItems[0].Tag;
                string s = m.Getir(Medya.ResimTip.Cover, e.X >= pictureBox2.Width / 2 ? Medya.Komut.Sonraki : Medya.Komut.Onceki);
                if (s != "")
                {
                    pictureBox2.ImageLocation = s;
                    cg = e.X >= pictureBox2.Width / 2 ? cg + 1 : cg - 1; ;
                }
            }
            pictureBox2.Focus();
        }

        private void Hareket(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Cursor = e.X >= pb.Width / 2 ? Cursors.PanEast: Cursors.PanWest;
        }
    }
}