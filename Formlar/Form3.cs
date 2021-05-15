using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace yazilimYapimi
{

    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        public string tc;
        private void Form3_Load(object sender, EventArgs e)
        {
            ProfilBilgileri();
            StoktakiUrunlerimiistele();
            PazardakiDigerUrunleriiistele();
            SatılıkUrunlerimiListele();
            OnayBekleyenUrunlerimiListele();
        }

        #region Listeler
        private void StoktakiUrunlerimiistele()
        {

            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("UrunListem");
            ProfilDGV.DataSource = StokDGV.DataSource = liste.Listele(UserIdLabel.Text, true, false);
           

        }
        private void PazardakiDigerUrunleriiistele()
        {

        ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
        IListe liste = listelemeFabrikası.ListeOlustur("PazarListesi");
        Pazar_DGV.DataSource = liste.Listele(UserIdLabel.Text, true, true);

        }
        private void SatılıkUrunlerimiListele()
        {
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("PazardakiUrunlerim");
            SatılıkUrunlerimDGV.DataSource = liste.Listele(UserIdLabel.Text, true, true);

        }
        private void OnayBekleyenUrunlerimiListele()
        {
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("PazardakiUrunlerim");
            OnayBekleyenUrunlerimDGV.DataSource = liste.Listele(UserIdLabel.Text, false, true);
        }
        #endregion

        #region Profil Bilgilerini Getirme
        private void ProfilBilgileri()
        {
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
        #endregion


        #region Panel Görünürlükleri
        private void PanelGörünürlükleriniAyarla(Boolean AlımPanelOnay, Boolean ürünPanelOnay, Boolean profilimPanelOnay, Boolean ParaYatirPanelOnay)
        {
            AlımPanel.Visible = AlımPanelOnay;
            ürünPanel.Visible = ürünPanelOnay;
            profilimPanel.Visible = profilimPanelOnay;
            ParaYatirPanel.Visible = ParaYatirPanelOnay;
        }

        private void alimYapButon_Click(object sender, EventArgs e)
        {
            PazardakiDigerUrunleriiistele();
            PanelGörünürlükleriniAyarla(true, false, false, false);
        }
        private void ÜrünSatButon_Click(object sender, EventArgs e)
        {
            StoktakiUrunlerimiistele();
            OnayBekleyenUrunlerimiListele();
            PanelGörünürlükleriniAyarla( false, true, false, false);
        }
        private void ProfilimButon_Click(object sender, EventArgs e)
        {
            StoktakiUrunlerimiistele();
            PanelGörünürlükleriniAyarla(false, false, true, false);
            ProfilBilgileri();
        }
        private void ParaYatirButon_Click(object sender, EventArgs e)
        {
            PanelGörünürlükleriniAyarla(false, false, false, true);
        }
        #endregion


        private void btnBilgilerimiGuncelle_Click(object sender, EventArgs e)
        {
            if (adProfil.Text == "" || soyadProfil.Text == "" || tcProfil.Text == "" || telefonProfil.Text == "" ||
                adresProfil.Text == "" || emailProfil.Text == "" || sifreProfil.Text == "" || UserIdLabel.Text == "")
            {
                MessageBox.Show("Kutuları Boş bırakmayınız");
            }
            else
            {
                DialogResult mesaj = new DialogResult();
                mesaj = MessageBox.Show("Bilgileri Güncelleme İşlemi Yaptırmak Üzeresiniz \n Devam Etmek İstiyormusunuz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mesaj == DialogResult.Yes)
                {
                    Kullanıcı kullanıcı = new Kullanıcı();
                    kullanıcı.UyelikBilgileriGuncelle(adProfil.Text, soyadProfil.Text, tcProfil.Text, telefonProfil.Text,
                                                      adresProfil.Text, emailProfil.Text, sifreProfil.Text, UserIdLabel.Text);
                    ProfilBilgileri();
                }
            }
        }



        private void StokDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult mesaj = new DialogResult();
            mesaj = MessageBox.Show("Seçtiğiniz ürün satışa konmak üzere stoktan kaldırılacak  \n Devam Etmek İstiyormusunuz?", "Stoktan Kaldır", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mesaj == DialogResult.Yes)
            {
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
         


        private void btnParaTalebi_Click(object sender, EventArgs e)
        {
            EklemeFabrikası eklemeFabrikası = new EklemeFabrikası();
            IEkle ekle = eklemeFabrikası.EklemeNesnesiOlustur("Para");
            ekle.Ekle(UserIdLabel.Text, "", "", "", false,false, txtPara.Text, false);
        }



        private void satisEmriOlusturBTN_Click(object sender, EventArgs e)
        {
            EklemeFabrikası eklemeFabrikası = new EklemeFabrikası();
            IEkle ekle = eklemeFabrikası.EklemeNesnesiOlustur("Urun");
            ekle.Ekle(UserIdLabel.Text, UrunTipiSell.SelectedItem.ToString(), UrunMiktariSell.Text, FiyatSell.Text, false, true, txtPara.Text, false);
            SatılıkUrunlerimiListele();
            OnayBekleyenUrunlerimiListele();
            StoktakiUrunlerimiistele();
        }



        private void button6_Click(object sender, EventArgs e) // alim yapma
        {
            Alım alım = new Alım(UserIdLabel.Text, txtUrunTipi.Text, txtAlımMiktarı.Text, labelPara.Text);

        }
    }

}

