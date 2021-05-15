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
    class UrunListem : IListe
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        DataTable tablo4 = new DataTable();
        public DataTable Listele(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            return UrunListemiGetir(UserID, ItemRequest, ItemForSale);
        }

        private DataTable UrunListemiGetir(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            baglanti.Open();
            OleDbDataAdapter adp4 = new OleDbDataAdapter("select ItemName,ItemKg,ItemAmount from UserItems where UserID=" + UserID + " and ItemForSale=" + ItemForSale.ToString() + "", baglanti);
            adp4.Fill(tablo4);
            baglanti.Close();
            return tablo4;

        }

    }
}
