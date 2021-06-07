using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace yazilimYapimi
{
    class TamamlananAlim
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand komut;
        OleDbDataReader oku;
        string sqlkodu;

        public void IslemiKaydet(string AliciID, string SaticiID, string UrunAd, int UrunMiktar, int UrunBirimFiyati )
        {
            string IslemTarihi = DateTime.Now.ToShortDateString();

            baglanti.Open();
            
            // ID'ye göre Alicinin ad ve soyad bilgileri okunur.
            sqlkodu = "select UserName,UserSurname from Users where UserID =@UserID";
            komut = new OleDbCommand(sqlkodu, baglanti);
            komut.Parameters.AddWithValue("@UserID", AliciID);
            oku = komut.ExecuteReader();
            oku.Read();
            //Okunan bilgiler ilgili değişkenlere atanır.
            string AliciAd = oku[0].ToString();
            string AliciSoyad = oku[1].ToString();


            // ID'ye göre Alicinin ad ve soyad bilgileri okunur.
            komut = new OleDbCommand(sqlkodu, baglanti);
            komut.Parameters.AddWithValue("@UserID", SaticiID);
            oku = komut.ExecuteReader();
            oku.Read();
            //Okunan bilgiler ilgili değişkenlere atanır.
            string SaticiAd = oku[0].ToString();
            string SaticiSoyad = oku[1].ToString();

            baglanti.Close();

            
            //Daha sonra raporda görüntüleyebilmek için veritabanına alım işlemi kayıt edilir.
            baglanti.Open();
            sqlkodu = "insert into CompletedPurchase(BuyerID,BuyerName,BuyerSurname,SellerID,SellerName,SellerSurname,ItemName,ItemAmount,ItemUnitPrice,SellDate) " +
                        "values (@BuyerID,@BuyerName,@BuyerSurname,@SellerID,@SellerName,@SellerSurname,@ItemName,@ItemAmount,@ItemUnitPrice,@SellDate)";
           
            
            komut = new OleDbCommand(sqlkodu, baglanti);

            komut.Parameters.AddWithValue("@BuyerID", AliciID);
            komut.Parameters.AddWithValue("@BuyerName", AliciAd);
            komut.Parameters.AddWithValue("@BuyerSurname", AliciSoyad);
            komut.Parameters.AddWithValue("@SellerID", SaticiID);
            komut.Parameters.AddWithValue("@SellerName", SaticiAd);
            komut.Parameters.AddWithValue("@SellerSurname", SaticiSoyad);
            komut.Parameters.AddWithValue("@ItemName", UrunAd);
            komut.Parameters.AddWithValue("@ItemAmount", UrunMiktar);
            komut.Parameters.AddWithValue("@ItemUnitPrice", UrunBirimFiyati);
            komut.Parameters.AddWithValue("@SellDate", IslemTarihi);
            komut.ExecuteNonQuery();


            baglanti.Close();

        }



    }
}