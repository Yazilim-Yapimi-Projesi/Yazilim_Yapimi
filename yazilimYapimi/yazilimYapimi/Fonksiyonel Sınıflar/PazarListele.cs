using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace yazilimYapimi
{
    class PazarListele : IListe
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        DataTable tablo5 = new DataTable();

        public DataTable Listele(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            return PazarListesiniGetir(UserID, ItemRequest, ItemForSale);
        }

        private DataTable PazarListesiniGetir(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            baglanti.Open();
            OleDbDataAdapter adp5 = new OleDbDataAdapter("select UserID,ItemID,ItemName,ItemKg,ItemAmount from UserItems where ItemRequest=" + ItemRequest.ToString() + " and ItemForSale=" + ItemForSale.ToString(), baglanti);
            adp5.Fill(tablo5);
            baglanti.Close();
            return tablo5;

        }
    }
}
