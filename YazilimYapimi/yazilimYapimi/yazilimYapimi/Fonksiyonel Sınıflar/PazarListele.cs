using System;
using System.Data;
using System.Data.OleDb;


namespace yazilimYapimi
{
    class PazarListele : IListe
    {
        public DataTable Listele(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            return PazarListesiniGetir(UserID, ItemRequest, ItemForSale);
        }

        private DataTable PazarListesiniGetir(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            DataTable tablo5 = new DataTable();

            //urunler, Urun onay ve satılık olma durumuna göre listelenir.
            baglanti.Open();
            OleDbDataAdapter adp5 = new OleDbDataAdapter("select UserID,ItemID,ItemName,ItemKg,ItemAmount from UserItems where ItemRequest=" + ItemRequest.ToString() + " and ItemForSale=" + ItemForSale.ToString(), baglanti);
            adp5.Fill(tablo5);
            baglanti.Close();
            return tablo5;

        }
    }
}
