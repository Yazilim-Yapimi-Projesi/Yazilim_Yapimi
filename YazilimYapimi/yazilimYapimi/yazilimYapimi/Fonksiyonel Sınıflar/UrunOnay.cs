using System.Data.OleDb;

namespace yazilimYapimi
{

    class UrunOnay : IOnay
    {

        public bool Onayla(string UserID, string ItemName, string ItemAmount, string ItemID, string MoneyID)
        {
            return this.Urun_Onayla(UserID, ItemName, ItemAmount, ItemID, MoneyID);
        }


        private bool Urun_Onayla(string UserID, string ItemName, string ItemAmount, string ItemID, string MoneyID)
        {

            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            OleDbCommand komut;

            // Onaylanan ürünlerin onayları güncellenir.

            baglanti.Open();

            string sqlkodu = "update UserItems set ItemRequest="+ true +" where ItemID=@itemid";
            komut = new OleDbCommand(sqlkodu, baglanti);
            komut.Parameters.AddWithValue("@itemid", ItemID);
            komut.ExecuteNonQuery();

            baglanti.Close();

            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("UrunKontrol");
            kontrol.KontrolEt(UserID,ItemName,ItemAmount);

            return true;
        }
    }
}
