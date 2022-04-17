using System;
using System.Windows.Forms;
using UPNPLib;

namespace Film_ve_Dizi_Ekle
{
    public partial class MedyaSec : Form
    {
        readonly UPnPDeviceFinder upnp = new UPnPDeviceFinder();
        readonly CihazArama cihazArama = new CihazArama();
        UPnPDevice mediaserver;
        public UPnPService service;
        int msid;
        public bool islem = false;
        public Oge secilen;
        public string secilentur;
        public Oge.OgeTip secilecektip;

        public MedyaSec()
        {
            InitializeComponent();
        }

        private void MedyaSec_Load(object sender, EventArgs e)
        {
            cihazArama.CihazBulundu += CihazArama_CihazBulundu;
            cihazArama.AramaTamamlandi += CihazArama_AramaTamamlandi;
            Btnyenile_Click(sender, e);
        }

        private void Btnyenile_Click(object sender, EventArgs e)
        {
            btnyenile.Enabled = false;
            btnyenile.Text = "Aranıyor...";
            listserver.Items.Clear();
            msid = upnp.CreateAsyncFind("urn:schemas-upnp-org:device:MediaServer:1", 0, cihazArama);
            upnp.StartAsyncFind(msid);
        }

        private void CihazArama_AramaTamamlandi(int lFindData)
        {
            if (lFindData == msid)
            {
                btnyenile.Enabled = true;
                btnyenile.Text = "Yenile";
            }
        }

        private void CihazArama_CihazBulundu(int lFindData, IUPnPDevice pDevice)
        {
            if (lFindData == msid)
                listserver.Items.Add(pDevice);
        }

        private void Listserver_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (listserver.SelectedIndex < 0)
                        return;
                    mediaserver = (UPnPDevice)listserver.SelectedItem;
                    service = null;
                    foreach (UPnPService uPnPService in mediaserver.Services)
                    {
                        if (uPnPService.ServiceTypeIdentifier == "urn:schemas-upnp-org:service:ContentDirectory:1")
                        {
                            service = uPnPService;
                            break;
                        }
                    }
                    if (service == null)
                    {
                        MessageBox.Show("Bu server dosya içeriklerini listelemeyi desteklemiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    treeView1.Nodes.Clear();
                    TreeNode node = treeView1.Nodes.Add(mediaserver.FriendlyName);
                    node.Tag = new Oge("0", "Root");
                    AltOgelerYukle(node);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void AltOgelerYukle(TreeNode ananode)
        {
            Oge anaoge = (Oge)ananode.Tag;
            if (anaoge.Tip == Oge.OgeTip.Dosya)
                return;
            if (anaoge.Yuklendi == true)
                return;
            object[] altogeler = Komutlar.AltOgeler(anaoge.Id, service);
            if (altogeler == null)
                return;
            ananode.Nodes.Clear();
            foreach (Oge oge in altogeler)
            {
                TreeNode node = ananode.Nodes.Add(oge.Ad);
                if (oge.Tip == Oge.OgeTip.Dosya)
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                }
                node.Tag = oge;
            }
            anaoge.Yuklendi = true;
            ananode.Expand();
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AltOgelerYukle(e.Node);
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnsec.Enabled = ((Oge)e.Node.Tag).Tip == secilecektip;
        }

        private void Btnsec_Click(object sender, EventArgs e)
        {
            secilentur = ((Oge)treeView1.SelectedNode.Parent.Tag).Ad;
            secilen = (Oge)treeView1.SelectedNode.Tag;
            islem = true;
            Close();
        }
    }

    public class Oge
    {
        public enum OgeTip
        {
            Klasör, Dosya
        }

        public string Id { get; set; }
        public string Ad { get; set; }
        public string Url { get; set; }
        public bool Yuklendi { get; set; }
        public OgeTip Tip { get; set; }

        public Oge(string id, string ad, string url)
        {
            Id = id;
            Ad = ad;
            Url = url;
            Tip = OgeTip.Dosya;
        }

        public Oge(string id, string ad)
        {
            Id = id;
            Ad = ad;
            Yuklendi = false;
            Tip = OgeTip.Klasör;
        }

        public override string ToString()
        {
            return $"Id: {Id} Ad: { Ad}";
        }
    }

    public class CihazArama : IUPnPDeviceFinderCallback
    {
        public event CihazBulunduEventHandler CihazBulundu;
        public delegate void CihazBulunduEventHandler(int lFindData, UPnPDevice pDevice);
        public event CihazSilindiEventHandler CihazSilindi;
        public delegate void CihazSilindiEventHandler(int lFindData, string bstrUDN);
        public event AramaTamamlandiCompletedEventHandler AramaTamamlandi;
        public delegate void AramaTamamlandiCompletedEventHandler(int lFindData);

        public void DeviceAdded(int lFindData, UPnPDevice pDevice)
        {
            CihazBulundu?.Invoke(lFindData, pDevice);
        }

        public void DeviceRemoved(int lFindData, string bstrUDN)
        {
            CihazSilindi?.Invoke(lFindData, bstrUDN);
        }

        public void SearchComplete(int lFindData)
        {
            AramaTamamlandi?.Invoke(lFindData);
        }
    }
}
