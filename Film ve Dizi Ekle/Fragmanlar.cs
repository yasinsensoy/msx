using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Film_ve_Dizi_Ekle
{
    public partial class Fragmanlar : Form
    {
        public Dictionary<string, string> fragmanlar;
        public string key = "";

        public Fragmanlar()
        {
            InitializeComponent();
        }

        private void Fragmanlar_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (var m in fragmanlar)
            {
                string[] a = m.Value.Split(new string[] { "[a]" }, StringSplitOptions.RemoveEmptyEntries);
                ListViewItem item = listView1.Items.Add(a[0]);
                item.SubItems.Add(a[1]);
                item.SubItems.Add(a[2]);
                item.SubItems.Add(m.Key);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            int genislik = 0;
            foreach (ColumnHeader sutun in listView1.Columns)
                genislik += sutun.Width;
            listView1.Width = genislik + 21;
            CenterToParent();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                key = listView1.SelectedItems[0].SubItems[3].Text;
                Close();
            }
        }
    }
}