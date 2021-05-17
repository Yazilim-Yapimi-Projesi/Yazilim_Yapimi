using System;
using System.Data;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class ParaOnayListele : IListe
    {
        public DataTable Listele(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            return ParaOnayListesiGetir();
        }

        private DataTable ParaOnayListesiGetir()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            DataTable tablo1 = new DataTable();

            // Admin sayfasında görüntülemek için onay bekleyen para istekleri listelenir.
            baglanti.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter("select UserID,MoneyID,MoneyAmount from Moneys where MoneyRequest=false", baglanti);
            adp.Fill(tablo1);
            baglanti.Close();
            return tablo1;
        }

    }
}
