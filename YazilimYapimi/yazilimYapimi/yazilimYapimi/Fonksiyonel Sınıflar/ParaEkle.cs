using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace yazilimYapimi
{
    class ParaEkle : IEkle
    {
        public bool Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek, Boolean Satısta_mı, string ParaMiktarı, Boolean ParaIstek)
        {
            return this.Para_Ekle(UserID, UrunTipi, UrunMiktari, UrunFiyat, UrunIstek, Satısta_mı, ParaMiktarı, ParaIstek);
        }
        private bool Para_Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek, Boolean Satısta_mı, string ParaMiktarı, Boolean ParaIstek)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            OleDbCommand ekle;


            baglanti.Open();

            // Para Ekleme işlemi
            string sqlkodu = "insert into Moneys(UserID,MoneyAmount,MoneyRequest) values (@UserID,@MoneyAmount,@MoneyRequest)";
            ekle = new OleDbCommand(sqlkodu, baglanti);


            ekle.Parameters.AddWithValue("@UserID", UserID);
            ekle.Parameters.AddWithValue("@MoneyAmount", ParaMiktarı);
            ekle.Parameters.AddWithValue("@MoneyRequest", ParaIstek);
            ekle.ExecuteNonQuery() ;


                baglanti.Close();

            // Eğer kullanıcnın daha öncedenonaylanmış parası varsa parasının miktarını arttırır.
            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("ParaKontrol");
            kontrol.KontrolEt(UserID,"","");

            return true;
        }
    }
}
