using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace yazilimYapimi
{
    class IslemSira
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand komut;
        OleDbDataReader oku;
        string sqlkodu;

   
        public void SırayaAl(string AliciID, string UrunAd, string UrunMiktar, string UrunBirimFiyati)
        {
            baglanti.Open();
            sqlkodu = "insert into QueuedPurchases(BuyerID,ItemName,ItemAmount,ItemUnitPrice) " +
                        "values (@BuyerID,@ItemName,@ItemAmount,@ItemUnitPrice)";


            komut = new OleDbCommand(sqlkodu, baglanti);

            komut.Parameters.AddWithValue("@BuyerID", AliciID);
            komut.Parameters.AddWithValue("@ItemName", UrunAd);
            komut.Parameters.AddWithValue("@ItemAmount", UrunMiktar);
            komut.Parameters.AddWithValue("@ItemUnitPrice", UrunBirimFiyati);
            komut.ExecuteNonQuery();


            baglanti.Close();

        }


        public void SıradakiIslemleriKontrolEt()
        {
            baglanti.Open();
            // Islem sırasına alınmış butun işlemler sırayla okunur,gezilir.
            sqlkodu = "Select * from QueuedPurchases";
            komut = new OleDbCommand(sqlkodu, baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())//Mevcut okunan işlemdeki bilgiler ilgili değişkenlere atanır
            {
                string IslemID = oku[0].ToString();
                string AliciID = oku[1].ToString();
                string UrunAd = oku[2].ToString();
                string UrunMiktar = oku[3].ToString();
                string UrunBirimFiyati = oku[4].ToString();
                string AlicininParasi="";


                // Islemdki alıcının ID'sine göre alıcıın parası veritabanından çekilir ve ilgili değere atanır.
                sqlkodu = "Select * from Moneys where UserID=@UserID";
                komut = new OleDbCommand(sqlkodu, baglanti);
                komut.Parameters.AddWithValue("@UserID",AliciID);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                  AlicininParasi = oku[2].ToString();
                }

                // Mevcut işlemdeki bilgilere göre alım yapılabilir mi kontrol edilir.
                Alım alım = new Alım();

               if(alım.ManuelAlimYap(AliciID, UrunAd, UrunMiktar, Convert.ToInt32(UrunBirimFiyati), AlicininParasi))
                {//Eğer Alım gerekirse ,sıraya alınmış işlem veritabanından silinir.
                    MessageBox.Show("IslemID 3 = =?  "+IslemID);
                    sqlkodu = "Delete from QueuedPurchases where PurchaseID=@PurchaseID";
                    komut = new OleDbCommand(sqlkodu, baglanti);
                    komut.Parameters.AddWithValue("@PurchaseID", IslemID);
                    komut.ExecuteNonQuery();

                }
            }
            baglanti.Close();
        }




    }
}
//QueuedPurchases PurchaseID BuyerID SellerID ItemName ItemAmount ItemUnitPrice