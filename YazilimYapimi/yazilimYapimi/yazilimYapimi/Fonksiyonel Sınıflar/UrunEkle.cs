using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class UrunEkle : IEkle
    {
        public bool Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek,Boolean Satısta_mı ,string ParaMiktarı, Boolean ParaIstek ,string DövizTipi)
        { 
           
            return this.Urun_Ekle(UserID,  UrunTipi,  UrunMiktari, UrunFiyat,  UrunIstek, Satısta_mı);
        }
        private bool Urun_Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek, Boolean Satısta_mı)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            OleDbCommand ekle;

            //Urun Ekleme işlemi
            baglanti.Open();
            string sqlkodu = "insert into UserItems(UserID,ItemName,ItemKg,ItemAmount,ItemRequest,ItemForSale) values (@UserID,@ItemName,@ItemKg,@ItemAmount,@ItemRequest,@ItemForSale)";
            ekle = new OleDbCommand(sqlkodu, baglanti);

            ekle.Parameters.AddWithValue("@UserID", UserID);
            ekle.Parameters.AddWithValue("@ItemName", UrunTipi);
            ekle.Parameters.AddWithValue("@ItemKg", UrunMiktari);
            ekle.Parameters.AddWithValue("@ItemAmount", UrunFiyat);
            ekle.Parameters.AddWithValue("@ItemRequest", UrunIstek);
            ekle.Parameters.AddWithValue("@ItemForSale", Satısta_mı);
            ekle.ExecuteNonQuery() ;


            baglanti.Close();

            // Eğer aynı fiyatta aynı üründen varsa miktarın üzerine eklenmesi için kontrol
            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("UrunKontrol");
            kontrol.KontrolEt(UserID, UrunTipi, UrunFiyat);


            return true;
        }
    }
}

