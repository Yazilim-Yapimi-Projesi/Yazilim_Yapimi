using System;
using System.Data;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class UrunOnayListele : IListe
    {

        public DataTable Listele(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            return UrunOnayListesiGetir();
        }

        private DataTable UrunOnayListesiGetir()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            DataTable tablo2 = new DataTable();

            // Onay bekleyen ürünler listelenir.

            baglanti.Open();

            OleDbDataAdapter adp2 = new OleDbDataAdapter("select UserID,ItemID,ItemName,ItemKg,ItemAmount from UserItems where ItemRequest=false and ItemForSale=true", baglanti);
            adp2.Fill(tablo2);
            baglanti.Close();
            return tablo2;

        }
      
    }
}
