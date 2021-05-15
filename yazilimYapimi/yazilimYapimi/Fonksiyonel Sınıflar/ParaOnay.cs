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
   
    class ParaOnay : IOnay
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand ekle;
        OleDbDataReader oku;
        public bool Onayla(string UserID, string ItemName, string ItemAmount, string ItemID, string MoneyID)
        {
            return this.Para_Onayla(UserID, ItemName, ItemAmount, ItemID, MoneyID);
        }


        private bool Para_Onayla(string UserID, string ItemName, string ItemAmount, string ItemID, string MoneyID)
        {

            baglanti.Open();


            string sqlkodu = "update Moneys set [MoneyRequest]=" + true + " where MoneyID=@MoneyID";
            ekle = new OleDbCommand(sqlkodu, baglanti);
            ekle.Parameters.AddWithValue("@MoneyID", MoneyID);
            ekle.ExecuteNonQuery();
            baglanti.Close();

            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("ParaKontrol");
            kontrol.KontrolEt(UserID,"","");

            return true;
        }

    }
}
