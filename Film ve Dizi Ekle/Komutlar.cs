using Newtonsoft.Json.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using UPNPLib;
using hap = HtmlAgilityPack;

namespace Film_ve_Dizi_Ekle
{
    class Komutlar
    {
        public static Baglanti bagl = new Baglanti();
        public static string msx = "http://192.168.1.106:80/msx/";
        public static Dictionary<string, DGVKonum> dgvkonums = new Dictionary<string, DGVKonum>();
        public enum Tur
        {
            Film, Dizi
        }

        public static bool Sil(string ad)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("ad", ad);
                    client.DownloadString(msx + "sil.php");
                }
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool Yukle(string ad, string dosyayol, bool afis)
        {
            try
            {
                string yol = Path.Combine(Path.GetTempPath(), Path.GetFileName(dosyayol));
                using (Image img = Image.Load(dosyayol))
                {
                    if (afis)
                    {
                        var ratio = Math.Max((double)600 / img.Width, (double)900 / img.Height);
                        var width = (int)(img.Width * ratio);
                        var height = (int)(img.Height * ratio);
                        img.Mutate(x => x.Resize(width, height));
                        img.SaveAsJpeg(yol);
                    }
                    else
                    {
                        //img.Mutate(x => x.EntropyCrop());
                        img.SaveAsJpeg(yol);
                    }
                }
                File.Delete(dosyayol);
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("ad", ad);
                    client.UploadFile(msx + "upload.php", "POST", yol);
                }
                File.Delete(yol);
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string Cevir(string metin)
        {
            try
            {
                using (WebClient reader = new WebClient())
                {
                    reader.QueryString.Add("dir", "auto/tr");
                    reader.QueryString.Add("provider", "google");
                    reader.QueryString.Add("text", metin);
                    return Encoding.UTF8.GetString(reader.UploadValues("https://webmail.smartlinkcorp.com/dotrans.php", "POST", reader.QueryString));
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool ResimIndir(string url, string kayityeri, System.Drawing.Imaging.ImageFormat format)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(url);
                    using (MemoryStream mem = new MemoryStream(data))
                    using (var yourImage = System.Drawing.Image.FromStream(mem))
                        yourImage.Save(kayityeri, format);
                }
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public static string Duzenle(string ad)
        {
            string s = ad.Trim().ToLower(new CultureInfo("tr-TR")).Replace("/", "").Replace("\\", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace(" ", "-");
            s = s.Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c");
            return s;
        }

        public static string HexToString(string deger)
        {
            for (int i = 0; i <= 10175; i++)
                deger = deger.Replace($"&#x{i:X};", ((char)i).ToString());
            return deger;
        }

        public static int SayiAl(string deger)
        {
            return Convert.ToInt32(new string(deger.Where(char.IsDigit).ToArray()));
        }

        public static Oge[] AltOgeler(string Id, UPnPService service)
        {
            List<Oge> ogeler = new List<Oge>();
            object[] myInObject = {
                Id, // Id
                "BrowseDirectChildren", // SortOfInformation
                "*", // Filter
                0, // Start Index
                0, // Max result count
                "" // sort Criteria
            };
            object myOutObject = null;
            try
            {
                service.InvokeAction("Browse", myInObject, ref myOutObject);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (myOutObject == null)
                return null;
            XmlDocument myXMLDoc = new XmlDocument();
            myXMLDoc.LoadXml(((object[])myOutObject)[0].ToString());
            foreach (XmlNode xmlNode in myXMLDoc.DocumentElement.ChildNodes)
            {
                string id = xmlNode.Attributes["id"].Value;
                string ad = xmlNode["dc:title"].InnerText;
                if (xmlNode.Name == "container")
                    ogeler.Add(new Oge(id, ad));
                else if (xmlNode.Name == "item")
                {
                    string url = xmlNode["res"].InnerText;
                    ogeler.Add(new Oge(id, ad, url));
                }
            }
            return ogeler.ToArray();
        }

        public static List<Medya> MedyaBul(string ad, string oad, string qyil, Tur tur, int sayi = 0)
        {
            List<Medya> medyalar = new List<Medya>();
            using (WebClient reader = new WebClient() { Encoding = Encoding.UTF8 })
            {
                var okunan = (dynamic)JObject.Parse(reader.DownloadString($"https://api.themoviedb.org/3/search/{(tur == Tur.Film ? "movie" : "tv")}?api_key=7404ee9071fb5ec61f5ad1ccedda50bb&language=tr-TR&query={Uri.EscapeDataString(oad == "" ? ad : oad)}&region=tr{(qyil == "" && tur == Tur.Dizi ? "" : $"&year={qyil}")}"));
                okunan = okunan.total_results.Value == 0 ? (dynamic)JObject.Parse(reader.DownloadString($"https://api.themoviedb.org/3/search/{(tur == Tur.Film ? "movie" : "tv")}?api_key=7404ee9071fb5ec61f5ad1ccedda50bb&language=tr-TR&query={Uri.EscapeDataString(ad)}&region=tr{(qyil == "" && tur == Tur.Dizi ? "" : $"&year={qyil}")}")) : okunan;
                if (okunan.total_results.Value > 0)
                {
                    int length = sayi > 0 && sayi <= okunan.results.Count ? sayi : Convert.ToInt32(okunan.results.Count);
                    okunan = (dynamic)((JArray)okunan.results).OrderByDescending(n => (((dynamic)n).original_title.Value.ToLower() == oad.ToLower() && oad!="") || 
                                                                                      (((dynamic)n).original_title.Value.ToLower() == ad.ToLower() && ad != "") || 
                                                                                      (((dynamic)n).title.Value.ToLower() == ad.ToLower() && ad != "") || 
                                                                                      (((dynamic)n).title.Value.ToLower() == oad.ToLower() && oad != "")).ToArray();
                    for (int i = 0; i < length; i++)
                    {
                        var item = okunan[i];
                        var oku = (dynamic)JObject.Parse(reader.DownloadString($"https://api.themoviedb.org/3/{(tur == Tur.Film ? "movie" : "tv")}/{item.id.Value}?api_key=7404ee9071fb5ec61f5ad1ccedda50bb&language=tr-TR&include_image_language=tr,en,null,{item.original_language.Value}&append_to_response=casts,videos,translations,images"));
                        string[] afisler = Array.ConvertAll((object[])((JArray)oku.images.posters).OrderByDescending(t => ((dynamic)t).iso_639_1.Value == "tr").ThenByDescending(t => ((dynamic)t).vote_average.Value).Select(g => ((dynamic)g).file_path.Value).ToArray(), x => x.ToString());
                        string[] covers = Array.ConvertAll((object[])((JArray)oku.images.backdrops).OrderByDescending(t => ((dynamic)t).iso_639_1.Value == "tr").ThenByDescending(t => ((dynamic)t).vote_average.Value).Select(g => ((dynamic)g).file_path.Value).ToArray(), x => x.ToString());
                        if (afisler.Length == 0 && oku.poster_path != null)
                            afisler=new string[] { oku.poster_path.Value };
                        if (covers.Length == 0 && oku.backdrop_path != null)
                            covers = new string[] { oku.backdrop_path.Value };
                        string fad = oku.title.Value;
                        string yil = oku.release_date.Value == "" ? "" : DateTime.Parse(oku.release_date.Value).Year.ToString();
                        string turler = string.Join(",", ((JArray)oku.genres).Select(g => ((dynamic)g).name.Value.Replace(",", "")));
                        string yonetmenler = string.Join(",", ((JArray)oku.casts.crew).Where(g => ((dynamic)g).job.Value == "Director").Select(g => ((dynamic)g).name.Value.Replace(",", "")));
                        string oyuncular = string.Join(",", ((JArray)oku.casts.cast).Take(8).Select(g => ((dynamic)g).name.Value.Replace(",", "")));
                        string imdb = oku.imdb_id.Value;
                        string orjad = oku.original_title.Value;
                        orjad = orjad == fad ? "" : orjad;
                        string ozet = oku.overview.Value;
                        if (ozet == "")
                        {
                            var en = (dynamic)((JArray)oku.translations.translations).FirstOrDefault(t => ((dynamic)t).iso_639_1 == "en");
                            ozet = en == null ? "" : en.data.overview.Value;
                            ozet = ozet == "" ? "" : Cevir(ozet);
                            if (ozet == "")
                            {
                                var rd = (dynamic)((JArray)oku.translations.translations).First;
                                ozet = rd == null ? "" : rd.data.overview.Value;
                                ozet = ozet == "" ? "" : Cevir(ozet);
                            }
                        }
                        string fragman = oku.videos.results.Count == 0 ? "" : oku.videos.results[0].key.Value;
                        medyalar.Add(new Medya(fad, orjad, turler, afisler, covers, ozet, yil, imdb, yonetmenler, oyuncular, fragman));
                    }
                }
            }
            return medyalar;
        }

        public static Dictionary<string, string> FragmanBul(string ad)
        {
            Dictionary<string, string> fragmanlar = new Dictionary<string, string>();
            using (WebClient reader = new WebClient() { Encoding = Encoding.UTF8 })
            {
                string ok = reader.DownloadString($"https://www.youtube.com/results?search_query={Uri.EscapeDataString(ad)}&sp=EgQQARgB");
                string sen = TagYakala(ok, "window[\"ytInitialData\"] =", "};") + "}";
                var okunan = (dynamic)JObject.Parse(sen);
                int sonuc = Convert.ToInt32(okunan.estimatedResults.Value);
                if (sonuc > 0)
                {
                    var contents = okunan.contents.twoColumnSearchResultsRenderer.primaryContents.sectionListRenderer.contents;
                    var sonuclar = ((JArray)contents[0].itemSectionRenderer.contents).Where(c => ((dynamic)c).videoRenderer != null);
                    if (sonuclar.Count() == 0)
                        sonuclar = ((JArray)contents[1].itemSectionRenderer.contents).Where(c => ((dynamic)c).videoRenderer != null);
                    sonuclar = sonuclar.Where(c => ((dynamic)c).videoRenderer.lengthText != null).OrderByDescending(t => ((dynamic)t).videoRenderer.ownerText.runs[0].text.Value.ToLower() == "youtube movies");
                    foreach (dynamic item in sonuclar)
                    {
                        string vad = $"{item.videoRenderer.title.runs[0].text.Value}[a]{item.videoRenderer.lengthText.accessibility.accessibilityData.label.Value}[a]{item.videoRenderer.ownerText.runs[0].text.Value}";
                        string key = item.videoRenderer.videoId.Value;
                        fragmanlar.Add(key, vad);
                        if (fragmanlar.Count == 5)
                            break;
                    }
                }
            }
            return fragmanlar;
        }

        public static List<Medya> MedyaBulBoxOffice(string ad, int sayi = 0)
        {
            List<Medya> medyalar = new List<Medya>();
            using (WebClient reader = new WebClient() { Encoding = Encoding.UTF8 })
            {
                reader.QueryString.Add("term", ad);
                var okunan = (dynamic)JObject.Parse(Encoding.UTF8.GetString(reader.UploadValues("https://boxofficeturkiye.com/Search/AutoComplete", "POST", reader.QueryString)));
                var movie = okunan.data.movie;
                if (movie != null && movie.Count > 0)
                {
                    int length = sayi > 0 && sayi <= movie.Count ? sayi : Convert.ToInt32(movie.Count);
                    for (int i = 0; i < length; i++)
                    {
                        var item = movie[i];
                        string afis = item.image.Value == null ? "" : item.image.Value.Replace($"/{new Uri(item.image.Value).Segments[3]}", "/full/");
                        string fad = item.title.Value;
                        string turler = "";
                        if (item.subTitle.Value != null)
                        {
                            foreach (string t in item.subTitle.Value.Trim().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (t == "3 Boyutlu" || t == "IMAX" || t == "espor")
                                    continue;
                                string tt = t.Trim();
                                turler += (turler == "" ? "" : ",") + (tt == "Romantik-Komedi" ? "Romantik,Komedi" : (tt == "Aşk" ? "Romantik" : (tt == "Bilim-Kurgu" ? "Bilim Kurgu" : (tt == "Tarihi" ? "Tarih" : tt))));
                            }
                        }
                        string url = $"https://boxofficeturkiye.com{item.url.Value}";
                        medyalar.Add(new Medya(fad, turler, afis, url));
                    }
                }
            }
            return medyalar;
        }

        public static void DGVKonumKaydetYukle(ref DataGridView dgv, bool kaydet, bool sil = false)
        {
            if (dgv.RowCount > 0)
            {
                string key = dgv.Name;
                DGVKonum dGVKonum = dgvkonums.FirstOrDefault(k => k.Key == key).Value;
                if (dGVKonum == null)
                {
                    dGVKonum = new DGVKonum();
                    dgvkonums.Add(key, dGVKonum);
                }
                if (kaydet)
                    dGVKonum.Kaydet(dgv, sil);
                else
                    dGVKonum.Yukle(ref dgv);
            }
        }

        public class DGVKonum
        {
            private int ri;
            private List<int> secilenler;

            public DGVKonum()
            {
                ri = 0;
                secilenler = new List<int>();
            }

            public void Kaydet(DataGridView dgv, bool sil)
            {
                ri = dgv.FirstDisplayedScrollingRowIndex;
                if (sil)
                    secilenler.Clear();
                else
                {
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                        secilenler.Add(row.Index);
                }
            }

            public void Yukle(ref DataGridView dgv)
            {
                dgv.FirstDisplayedScrollingRowIndex = ri < dgv.RowCount ? ri : dgv.RowCount - 1;
                if (secilenler.Count > 0)
                {
                    dgv.ClearSelection();
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        foreach (int i in secilenler)
                        {
                            if (row.Index == i)
                            {
                                row.Selected = true;
                                secilenler.Remove(i);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static string TagYakala(string veri, string başlangıç, string bitiş, int index = 1)
        {
            string değer = "";
            try
            {
                değer = veri.Split(new string[] { başlangıç }, StringSplitOptions.None)[index].Split(new string[] { bitiş }, StringSplitOptions.None)[0];
            }
            catch
            {
            }
            return değer;
        }
    }

    public class Medya
    {
        public string Ad { get; set; } = "";
        public string OrjAd { get; set; } = "";
        public string Turler { get; set; } = "";
        public string Resim { get; set; } = "";
        public string Cover { get; set; } = "";
        public string Ozet { get; set; } = "";
        public string Yil { get; set; } = "";
        public decimal IMDB { get; set; } = 0;
        public string Yonetmenler { get; set; } = "";
        public string Oyuncular { get; set; } = "";
        public string Fragman { get; set; } = "";
        public string[] Posters { get; set; }
        public string[] Covers { get; set; }
        private string Url = "";
        private string IMDBId = "";
        private int pid, cid;
        private const string org = "https://image.tmdb.org/t/p/original";
        private const string w300 = "https://image.tmdb.org/t/p/w300";
        public enum Komut { Onceki, Sonraki }
        public enum ResimTip { Poster = 1, Cover = 2 }

        public Medya(string ad, string orjad, string turler, string[] posters, string[] covers, string ozet, string yil, string imdb, string yonetmenler, string oyuncular, string fragman)
        {
            Ad = ad;
            OrjAd = orjad;
            Turler = turler;
            Ozet = ozet;
            Posters = posters;
            Covers = covers;
            Yil = yil;
            IMDBId = imdb;
            Fragman = fragman;
            Yonetmenler = yonetmenler;
            Oyuncular = oyuncular;
            Getir(ResimTip.Poster | ResimTip.Cover, Komut.Sonraki, true);
        }

        public Medya(string ad, string turler, string resim, string url)
        {
            Ad = ad;
            Turler = turler;
            Resim = resim;
            Url = url;
        }

        public void BoxOfficeGetir()
        {
            using (WebClient reader = new WebClient() { Encoding = Encoding.UTF8 })
            {
                string oku = HttpUtility.HtmlDecode(reader.DownloadString(Url));
                hap.HtmlDocument doc = new hap.HtmlDocument();
                doc.LoadHtml(oku);
                var trailer = doc.DocumentNode.SelectSingleNode("//div[@class='c-movie-trailer__preview']//a[@data-lightbox='trailer']");
                if (trailer != null)
                {
                    string tl = trailer.Attributes["href"].Value;
                    Fragman = (tl.Contains("vimeo") ? "v:" : "") + Komutlar.TagYakala(tl, $"{(tl.Contains("vimeo") ? "video" : "embed")}/", "?");
                }
                var oad = doc.DocumentNode.SelectSingleNode("//div[@class='subheading']");
                OrjAd = oad != null ? oad.InnerText : "";
                var yil = doc.DocumentNode.SelectNodes("//div[@class='w-50']").FirstOrDefault(n => n.ChildNodes["h4"] != null && n.ChildNodes["h4"].InnerText == "Yapım Yılı");
                Yil = yil != null ? yil.ChildNodes["p"].InnerText : "";
                var ozet = doc.DocumentNode.SelectSingleNode("//div[@class='c-section__body']").SelectNodes("p");
                Ozet = (ozet != null ? string.Join("\r\n\r\n", ozet.Select(n => n.InnerText.Trim())) : "").Trim();
            }
        }

        public string Getir(ResimTip tip, Komut komut, bool ilk = false)
        {
            if (ilk)
            {
                Resim = Posters.Length > 0 ? org + Posters[0] : "";
                Cover = Covers.Length > 0 ? org + Covers[0] : "";
                if (tip == ResimTip.Poster)
                {
                    pid = 0;
                    return Posters.Length > 0 ? w300 + Posters[0] : "";
                }
                else if (tip == ResimTip.Cover)
                {
                    cid = 0;
                    return Covers.Length > 0 ? w300 + Covers[0] : "";
                }
                return "";
            }
            else
            {
                bool s = komut == Komut.Sonraki && ((tip == ResimTip.Poster && Posters.Length > 0 && pid + 1 < Posters.Length) || (tip == ResimTip.Cover && Covers.Length > 0 && cid + 1 < Covers.Length));
                bool o = komut == Komut.Onceki && ((tip == ResimTip.Poster && Posters.Length > 0 && pid - 1 >= 0) || (tip == ResimTip.Cover && Covers.Length > 0 && cid - 1 >= 0));
                if (s || o)
                {
                    Resim = tip == ResimTip.Poster ? org + Posters[s ? ++pid : --pid] : Resim;
                    Cover = tip == ResimTip.Cover ? org + Covers[s ? ++cid : --cid] : Cover;
                    return tip == ResimTip.Poster ? w300 + Posters[pid] : w300 + Covers[cid];
                }
                return "";
            }
        }

        public string IMDBTur()
        {
            string imdbctur = "";
            try
            {
                if (IMDBId != "")
                {
                    using (WebClient reader = new WebClient() { Encoding = Encoding.UTF8 })
                    {
                        var imdb = (dynamic)JObject.Parse(Komutlar.TagYakala(HttpUtility.HtmlDecode(reader.DownloadString($"https://www.imdb.com/title/{IMDBId}")), "<script type=\"application/ld+json\">", "</script>"));
                        IMDB = Convert.ToDecimal(imdb.aggregateRating.ratingValue.Value, new CultureInfo("en-US"));
                        if (imdb.genre != null)
                        {
                            string imdbtur = imdb.genre.Type == JTokenType.String ? imdb.genre.Value : string.Join(".", ((JArray)imdb.genre).Select(g => ((dynamic)g).Value));
                            imdbctur = Komutlar.Cevir(imdbtur).Replace(", ",",");
                        }
                    }
                }
                return imdbctur;
            }
            catch (Exception)
            {
                return imdbctur;
            }
        }
    }
}
