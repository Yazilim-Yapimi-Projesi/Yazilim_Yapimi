using System.Data.OleDb;
using System;
using System.Windows.Forms;

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
            OleDbCommand komut;
            string sqlkodu;
            double Para;

            Doviz doviz = new Doviz();
            Para = doviz.DovizDonusumuYap(MoneyID);

            // Para, admin tarafından onaylandığında kayıt güncellenir.

            baglanti.Open();
            sqlkodu = "update Moneys set [MoneyAmount]=@MoneyAmount, [Currency]=@Currency, [MoneyRequest]=" + true + " where MoneyID=@MoneyID";
            komut = new OleDbCommand(sqlkodu, baglanti);
            komut.Parameters.AddWithValue("@MoneyAmount", Para);
            komut.Parameters.AddWithValue("@Currency", "TRY");
            komut.Parameters.AddWithValue("@MoneyID", MoneyID);
            komut.ExecuteNonQuery();
            baglanti.Close();

            //Kullanıcının daha önce onaylanmış parası var ise yeni onaylanan parayı o paranın üzerine eklemek üzere kontrol yapan sınıf çağrılır.
            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("ParaKontrol");
            kontrol.KontrolEt(UserID,"","");

            return true;
        }

    }
}
