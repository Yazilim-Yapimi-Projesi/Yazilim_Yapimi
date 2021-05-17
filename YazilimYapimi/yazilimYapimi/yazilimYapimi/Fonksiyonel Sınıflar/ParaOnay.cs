using System.Data.OleDb;

namespace yazilimYapimi
{
   
    class ParaOnay : IOnay
    {
        public bool Onayla(string UserID, string ItemName, string ItemAmount, string ItemID, string MoneyID)
        {
            return this.Para_Onayla(UserID, MoneyID);
        }


        private bool Para_Onayla(string UserID, string MoneyID)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            OleDbCommand ekle;

            // Para, admin tarafından onaylandığında kayıt güncellenir.

            baglanti.Open();
            string sqlkodu = "update Moneys set [MoneyRequest]=" + true + " where MoneyID=@MoneyID";
            ekle = new OleDbCommand(sqlkodu, baglanti);
            ekle.Parameters.AddWithValue("@MoneyID", MoneyID);
            ekle.ExecuteNonQuery();
            baglanti.Close();

            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("ParaKontrol");
            kontrol.KontrolEt(UserID,"","");

            return true;
        }

    }
}
