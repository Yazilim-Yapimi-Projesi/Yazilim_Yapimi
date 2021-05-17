using System;
using System.Data;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class UrunListem : IListe
    {
        public DataTable Listele(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            return UrunListemiGetir(UserID, ItemForSale);
        }

        private DataTable UrunListemiGetir(string UserID,  Boolean ItemForSale)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            DataTable tablo4 = new DataTable();
            
            
            // Satılık olma veya stok durmuna göre kullanıcnın Urunleri Listelenir.

            baglanti.Open();
            OleDbDataAdapter adp4 = new OleDbDataAdapter("select ItemName,ItemKg,ItemAmount from UserItems where UserID=" + UserID + " and ItemForSale=" + ItemForSale.ToString() + "", baglanti);
            adp4.Fill(tablo4);
            baglanti.Close();
            return tablo4;

        }

    }
}
