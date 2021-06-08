using System;
using System.Windows.Forms;

namespace yazilimYapimi
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        string UserID;
        string MoneyID;
        string ItemID;
        string ItemName;
        string ItemAmount;
        public string MuhasebePara;
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            Kullanıcı admin = new Kullanıcı("192804001");
            MuhasebePara = admin.ParaGetir();
            labelMuhasaebe.Text = MuhasebePara;
            Paraİsteklistele();
            UrunistekListele();
        }

        #region Listelemeler
        private void Paraİsteklistele()
        {
            //Onay bekleyen para isteklerini listele.
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("ParaOnayListesi");
            ParaOnayDGV.DataSource = liste.Listele("",false,false);

        }
        private void UrunistekListele()
        {
            //Onay bekleyen urun isteklerini listele.
            ListelemeFabrikası listelemeFabrikası = new ListelemeFabrikası();
            IListe liste = listelemeFabrikası.ListeOlustur("UrunOnayListesi");
            UrunOnayDGV.DataSource = liste.Listele("", false, false);

        }
        #endregion

        #region Dgv tıklama
        private void ParaOnayDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserID = ParaOnayDGV.CurrentRow.Cells[0].Value.ToString();
            MoneyID = ParaOnayDGV.CurrentRow.Cells[1].Value.ToString();
        }
        private void UrunOnayDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserID = UrunOnayDGV.CurrentRow.Cells[0].Value.ToString();
            ItemID = UrunOnayDGV.CurrentRow.Cells[1].Value.ToString();
            ItemName = UrunOnayDGV.CurrentRow.Cells[2].Value.ToString();
            ItemAmount = UrunOnayDGV.CurrentRow.Cells[4].Value.ToString();
        }

        #endregion

        #region Panel gösterme

        private void btn_ParaTalep_Click(object sender, EventArgs e)
        {
            panelUrun.Visible = false;
            Paraİsteklistele();

        }

        private void btn_UrunTalep_Click(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            UrunistekListele();
        }
        #endregion

        #region Onaylama
        private void btn_UrunOnay_Click(object sender, EventArgs e)
        {
            OnayFabrikası onayFabrikası = new OnayFabrikası();
            IOnay onay = onayFabrikası.OnaylamaNesnesiOlustur("UrunOnay");
            onay.Onayla(UserID, ItemName ,ItemAmount ,ItemID, MoneyID);

            UrunistekListele();

            //Mevcut Sartlar değiştiği için sistemde sıraya alınmış işlemlerden uygun hale gelen varsa alım yapılır.
            IslemSira ıslem = new IslemSira();
            ıslem.SıradakiIslemleriKontrolEt();

            MessageBox.Show("Ürün Talebi Onaylanmıştır!", "Ürün Talebi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            labelMuhasaebe.Text = MuhasebePara;
        }
        private void btnParaOnay_Click(object sender, EventArgs e)
        {

            OnayFabrikası onayFabrikası = new OnayFabrikası();
            IOnay onay = onayFabrikası.OnaylamaNesnesiOlustur("ParaOnay");
            onay.Onayla(UserID, "", "", "", MoneyID);
            Paraİsteklistele();

            //Mevcut Sartlar değiştiği için sistemde sıraya alınmış işlemlerden uygun hale gelen varsa alım yapılır.
            IslemSira ıslem = new IslemSira();
            ıslem.SıradakiIslemleriKontrolEt();
            MessageBox.Show("Para Talebi Onaylanmıştır!", "Para Talebi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            labelMuhasaebe.Text = MuhasebePara;
        }



        #endregion

     
    }
}
