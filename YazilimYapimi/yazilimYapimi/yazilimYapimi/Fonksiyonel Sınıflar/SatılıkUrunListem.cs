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
    class SatılıkUrunListem : IListe
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        DataTable tablo3 = new DataTable();

        public DataTable Listele(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            return SatılıkUrunleriminListesiniGetir(UserID, ItemRequest, ItemForSale);
        }

        private DataTable SatılıkUrunleriminListesiniGetir(string UserID, Boolean ItemRequest, Boolean ItemForSale)
        {
            baglanti.Open();
            OleDbDataAdapter adp3 = new OleDbDataAdapter("select ItemID,ItemName,ItemKg,ItemAmount from UserItems where UserID=" +UserID+ "and ItemRequest="+ ItemRequest.ToString() +" and ItemForSale="+ ItemForSale.ToString() +"", baglanti);
            adp3.Fill(tablo3);
            baglanti.Close();
            return tablo3;

        }

    }

}
