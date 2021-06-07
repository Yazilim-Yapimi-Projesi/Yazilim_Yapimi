using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace yazilimYapimi
{
    class ParaEkle : IEkle
    {
        public bool Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek, Boolean Satısta_mı, string ParaMiktarı, Boolean ParaIstek, string DövizTipi)
        {
            return this.Para_Ekle(UserID, ParaMiktarı, ParaIstek, DövizTipi);
        }
        private bool Para_Ekle(string UserID, string ParaMiktarı, Boolean ParaIstek, string DövizTipi)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            OleDbCommand ekle;


            baglanti.Open();

            // Para Ekleme işlemi
            string sqlkodu = "insert into Moneys([UserID], [MoneyAmount], [MoneyRequest], [Currency]) values (@UserID, @MoneyAmount, @MoneyRequest, @Currency)";
            
            ekle = new OleDbCommand(sqlkodu, baglanti);

            ekle.Parameters.AddWithValue("@UserID", UserID);
            ekle.Parameters.AddWithValue("@MoneyAmount", ParaMiktarı);
            ekle.Parameters.AddWithValue("@MoneyRequest", ParaIstek);
            ekle.Parameters.AddWithValue("@Currency", DövizTipi);
            ekle.ExecuteNonQuery() ;

                
            baglanti.Close();

            // Eğer kullanıcnın daha öncedenonaylanmış parası varsa parasının miktarını arttırır.
            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("ParaKontrol");
            kontrol.KontrolEt(UserID, "", "");


            return true;
        }
    }
}
