using System;
using System.Windows.Forms;
using System.Data.OleDb;
using excel = Microsoft.Office.Interop.Excel;


namespace yazilimYapimi
{

    public partial class FormKullanici : Form
    {
        public FormKullanici()
        {
            InitializeComponent();
        }


        public string tc;
        private void FormKullanici_Load(object sender, EventArgs e)
        {
            timer1.Start();
            ProfilBilgileri();
            StoktakiUrunlerimiistele();
            PazardakiDigerUrunleriiistele();
            SatılıkUrunlerimiListele();
            OnayBekleyenUrunlerimiListele();
            TarihveZaman();

            ToolTip Aciklama = new ToolTip();
            Aciklama.IsBalloon = true;
            Aciklama.SetToolTip(btnOtoAlim, "İstediğiniz ürün sistemdeki en ucuz satışlara göre alınır.");
            Aciklama.SetToolTip(btnManuelAlim, "İstediğiniz ürün, sistemde sizim istediğiniz birim fiyattan satış olduğunda alınır");
        }

        #region Alım Yapma
        private void btnManuelAlim_Click(object sender, EventArgs e)
        {
            Alım alım = new Alım();

            //Yapılabiliyorsa işlemi yap.
            if (alım.ManuelAlimYap(UserIdLabel.Text, cmbxAlinacakUrun.Text, txtAlımMiktarı.Text, Convert.ToInt32(txtAlımBirimFiyat.Text), labelPara.Text))
            { MessageBox.Show("İstediğiniz şekilde alım islemi gerçekleştirilmiştir.","Alım İşlemi",MessageBoxButtons.OK,MessageBoxIcon.Information); }
            else
            {
                //Yapılamıyorsa islemi sıraya al.
                IslemSira ıslem = new IslemSira();
                ıslem.SırayaAl(UserIdLabel.Text, cmbxAlinacakUrun.Text, txtAlımMiktarı.Text, txtAlımBirimFiyat.Text);
                MessageBox.Show("Sistemde istediğini şartlarda satılık ürün yok.\nİşleminiz sıraya alınmıştır uygun şartlar oluştuğu zaman alım gerçekleştirilecektir.", "Alım İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOtoAlim_Click(object sender, EventArgs e)
        {
            Alım alım = new Alım();
            alım.OtoAlımYap(UserIdLabel.Text, cmbxAlinacakUrun.Text, txtAlımMiktarı.Text, labelPara.Text);
            PazardakiDigerUrunleriiistele();
        }
        #endregion


        #region Listeler
        private void StoktakiUrunlerimiistele()
        {
            //Kullanıcıın almış olduğu stoktaki ürünleri listeler.
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("UrunListem");
            ProfilDGV.DataSource = StokDGV.DataSource = liste.Listele(UserIdLabel.Text, true, false);
           

        }
        private void PazardakiDigerUrunleriiistele()
        {
            // Pazardaki tüm satılık ürünleri listeler
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("PazarListesi");
            Pazar_DGV.DataSource = liste.Listele(UserIdLabel.Text, true, true);

        }
        private void SatılıkUrunlerimiListele()
        {
            // Kullanıcnın pazarda sattığıürünleri listeler
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("PazardakiUrunlerim");
            SatılıkUrunlerimDGV.DataSource = liste.Listele(UserIdLabel.Text, true, true);

        }
        private void OnayBekleyenUrunlerimiListele()
        {
            // Kullanıcının onay bekleyen ürünlerini listeler
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("PazardakiUrunlerim");
            OnayBekleyenUrunlerimDGV.DataSource = liste.Listele(UserIdLabel.Text, false, true);
        }
        void RaporListele()
        {
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();       //ListelemeFabrikası classı için nesne oluşturuldu
            IRapor liste = listelemeFabrikası.RaporListeOlustur("RaporListele");    //oluşturulan nesne ile Method ismine göre işlem yapıyor

            if (RaporUrunTipi.Text == "Hepsi")
            {
                raporDGV.DataSource = liste.Listele(UserIdLabel.Text, RaporUrunAd.Text, KucukTarihDTP.Text, BuyukTarihDTP.Text, RaporUrunTipi.Text);
            }
            else if (RaporUrunTipi.Text == "Sattığım Ürünler")
            {
                //Interface nesnesine göre istenilen bilgiler yollanıyor
                raporDGV.DataSource = liste.Listele(UserIdLabel.Text, RaporUrunAd.Text, KucukTarihDTP.Text, BuyukTarihDTP.Text, RaporUrunTipi.Text);
            }
            else
            {
                raporDGV.DataSource = liste.Listele(UserIdLabel.Text, RaporUrunAd.Text, KucukTarihDTP.Text, BuyukTarihDTP.Text, RaporUrunTipi.Text);
            }
            this.raporDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //dataGridView'ın boyutlarına göre tabloların boyutlarını ayarlama

        }
        #endregion



        #region Profil Bilgilerini Getirme
        private void ProfilBilgileri()
        {
            //Profil ekranındaki araçlara yerleştirmek üzere kullanıcı bilglilerini getirir.
            Kullanıcı kullanıcı = new Kullanıcı(tc);
            adProfil.Text = kullanıcı.AdGetir();
            soyadProfil.Text = kullanıcı.SoyadGetir();
            tcProfil.Text = kullanıcı.TcGetir();
            telefonProfil.Text = kullanıcı.TelnoGetir();
            adresProfil.Text = kullanıcı.AdresGetir();
            emailProfil.Text = kullanıcı.EmailGetir();
            sifreProfil.Text = kullanıcı.SifreGetir();
            UserIdLabel.Text = kullanıcı.UserIDGetir();
            labelPara.Text = kullanıcı.ParaGetir();
        }
        private void TarihveZaman()
        {
            labelSaat.Text = DateTime.Now.ToLongTimeString();
            labelTarih.Text = DateTime.Now.ToLongDateString();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TarihveZaman();
        }
        #endregion



        #region Panel Görünürlükleri
        private void PanelGörünürlükleriniAyarla(Boolean AlımPanelOnay, Boolean ürünPanelOnay, Boolean profilimPanelOnay, Boolean ParaYatirPanelOnay, Boolean RaporPanelOnay)

        {
            AlımPanel.Visible = AlımPanelOnay;
            ürünPanel.Visible = ürünPanelOnay;
            profilimPanel.Visible = profilimPanelOnay;
            ParaYatirPanel.Visible = ParaYatirPanelOnay;
            raporPanel.Visible = RaporPanelOnay;
        }

        private void alimYapButon_Click(object sender, EventArgs e)
        {
            PazardakiDigerUrunleriiistele();
            PanelGörünürlükleriniAyarla(true, false, false, false, false);
        }
        private void ÜrünSatButon_Click(object sender, EventArgs e)
        {
            StoktakiUrunlerimiistele();
            OnayBekleyenUrunlerimiListele();
            PanelGörünürlükleriniAyarla( false, true, false, false, false);
        }
        private void ProfilimButon_Click(object sender, EventArgs e)
        {
            StoktakiUrunlerimiistele();
            PanelGörünürlükleriniAyarla(false, false, true, false, false);
            ProfilBilgileri();
        }
        private void ParaYatirButon_Click(object sender, EventArgs e)
        {
            PanelGörünürlükleriniAyarla(false, false, false, true, false);
        }
        private void RaporButon_Click(object sender, EventArgs e)
        {
            PanelGörünürlükleriniAyarla(false, false, false, false, true);
            RaporListele();
        }
        #endregion



        #region Guncelleme

        private void btnBilgilerimiGuncelle_Click(object sender, EventArgs e)
        {
            if (adProfil.Text == "" || soyadProfil.Text == "" || tcProfil.Text == "" || telefonProfil.Text == "" ||
                adresProfil.Text == "" || emailProfil.Text == "" || sifreProfil.Text == "" || UserIdLabel.Text == "")
            {
                MessageBox.Show("Kutuları Boş bırakmayınız","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                DialogResult mesaj = new DialogResult();
                mesaj = MessageBox.Show("Bilgileri Güncelleme İşlemi Yaptırmak Üzeresiniz \n Devam Etmek İstiyormusunuz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mesaj == DialogResult.Yes)
                {

                    // Kullanıcı bilgilerini güncelleme işlemi
                    Kullanıcı kullanıcı = new Kullanıcı();
                    kullanıcı.UyelikBilgileriGuncelle(adProfil.Text, soyadProfil.Text, tcProfil.Text, telefonProfil.Text,
                                                      adresProfil.Text, emailProfil.Text, sifreProfil.Text, UserIdLabel.Text);
                    ProfilBilgileri();
                }
            }
        }
        #endregion



        #region Stoktaki ürünü satılığa koymak için DGV'ye tıklama
        private void StokDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult mesaj = new DialogResult();
            mesaj = MessageBox.Show("Seçtiğiniz ürün satışa konmak üzere stoktan kaldırılacak  \n Devam Etmek İstiyormusunuz?", "Stoktan Kaldır", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
            {
                //Kullanıcı stoktaki ürününü satılığa koymak isterse ürünü stoktan silme ve onay için gönderme işlemleri

                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
                OleDbCommand komut;
                string sqlkodu;
                int seç = StokDGV.CurrentRow.Index;

                UrunTipiSell.SelectedItem = StokDGV.Rows[seç].Cells[0].Value.ToString();
                UrunMiktariSell.Text = StokDGV.Rows[seç].Cells[1].Value.ToString();
                FiyatSell.Text = StokDGV.Rows[seç].Cells[2].Value.ToString();

                baglanti.Open();
                sqlkodu = "delete from UserItems where (UserID=@userid) and (ItemName=@itemname) and (ItemAmount=@itemamount) and (ItemRequest=@itemrequest) and (ItemForSale=@ıtemforsale)";
                komut = new OleDbCommand(sqlkodu, baglanti);

                komut.Parameters.AddWithValue("@userid", UserIdLabel.Text);
                komut.Parameters.AddWithValue("@itemname", UrunTipiSell.SelectedItem);
                komut.Parameters.AddWithValue("@itemamount", FiyatSell.Text);
                komut.Parameters.AddWithValue("@itemrequest", false);
                komut.Parameters.AddWithValue("@ıtemforsale", false);
                komut.ExecuteNonQuery();

                baglanti.Close();
            }
        }
        #endregion



        #region Para Yatırma
        private void btnParaTalebi_Click(object sender, EventArgs e)
        {
            // Para yatırma işleminde onay için para isteği gönderilir.
            EklemeFabrikası eklemeFabrikası = new EklemeFabrikası();
            IEkle ekle = eklemeFabrikası.EklemeNesnesiOlustur("Para");
            ekle.Ekle(UserIdLabel.Text, "", "", "", false,false, txtPara.Text, false, cmbxDövizTipi.Text);
            MessageBox.Show("Para Talebiniz Oluşturulmuştur!", "Para Talebi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        #endregion



        #region Satılığa Ürün Ekleme
        private void satisEmriOlusturBTN_Click(object sender, EventArgs e)
        {
            // Satıs isteği oluşturma işleminde onay için ürün isteği gönderilir.
            EklemeFabrikası eklemeFabrikası = new EklemeFabrikası();
            IEkle ekle = eklemeFabrikası.EklemeNesnesiOlustur("Urun");
            ekle.Ekle(UserIdLabel.Text, UrunTipiSell.SelectedItem.ToString(), UrunMiktariSell.Text, FiyatSell.Text, false, true, txtPara.Text, false,"");
            MessageBox.Show("Urun Talebiniz Oluşturulmuştur!", "Ürün Talebi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            SatılıkUrunlerimiListele();
            OnayBekleyenUrunlerimiListele();
            StoktakiUrunlerimiistele();
        }
        #endregion



        
        #region Rapor Islemleri
        private void ExcelAktarBTN_Click(object sender, EventArgs e)
        {
            excel.Application excelUygulamasi = new excel.Application();       //Excel uygulaması için yeni bir nesne oluşturuluyor.
            excelUygulamasi.Visible = true;                                  //Excel'in gözükmesini sağlar.  
            excel.Workbook kitaplık = excelUygulamasi.Workbooks.Add(System.Reflection.Missing.Value);
            excel.Worksheet sayfa = (excel.Worksheet)kitaplık.Sheets[1];    //1. sayfadan başlaması sağlandı.
            for (int i = 0; i < raporDGV.Columns.Count; i++)                // sütun sayısı kadar döngü döndürülüyor.
            {
                excel.Range range = (excel.Range)sayfa.Cells[1, i + 1];        //tablodaki kolonların başlıkları geçirildi.
                range.Value2 = raporDGV.Columns[i].HeaderText;
            }
            for (int i = 0; i < raporDGV.Columns.Count; i++)                // sütun sayısı kadar döngü döndürülüyor.
            {
                for (int j = 0; j < raporDGV.Rows.Count; j++)               //satır sayısı kadar döngü döndürülüyor.
                {
                    excel.Range range = (excel.Range)sayfa.Cells[j + 2, i + 1];  //tablodaki geri kalan değerler excel'e aktarıldı.
                    range.Value2 = raporDGV[i, j].Value;
                    range.Select();

                }
            }
        }

        private void KucukTarihDTP_ValueChanged(object sender, EventArgs e)
        {
            RaporListele();
        }

        private void BuyukTarihDTP_ValueChanged(object sender, EventArgs e)
        {
            RaporListele();
        }

        private void RaporUrunAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            RaporListele();
        }

        private void RaporUrunTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            RaporListele();
        }
        #endregion

        
    }

}

