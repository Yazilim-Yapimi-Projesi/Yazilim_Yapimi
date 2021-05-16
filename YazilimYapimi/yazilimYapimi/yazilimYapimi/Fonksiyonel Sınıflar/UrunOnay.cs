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

    class UrunOnay : IOnay
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand komut;

        public bool Onayla(string UserID, string ItemName, string ItemAmount, string ItemID, string MoneyID)
        {
            return this.Urun_Onayla(UserID, ItemName, ItemAmount, ItemID, MoneyID);
        }


        private bool Urun_Onayla(string UserID, string ItemName, string ItemAmount, string ItemID, string MoneyID)
        {

            baglanti.Open();


            string sqlkodu = "update UserItems set ItemRequest="+ true +" where ItemID=@itemid";
            komut = new OleDbCommand(sqlkodu, baglanti);
            komut.Parameters.AddWithValue("@itemid", ItemID);
            komut.ExecuteNonQuery();

            baglanti.Close();

            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("UrunKontrol");
            kontrol.KontrolEt(UserID,ItemName,ItemAmount);

            return true;
        }
    }
}
