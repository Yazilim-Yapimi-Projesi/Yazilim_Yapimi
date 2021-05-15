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
    class ParaEkle : IEkle
    {

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand ekle;
        OleDbDataReader oku;

        public bool Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek, Boolean Satısta_mı, string ParaMiktarı, Boolean ParaIstek)
        {
            return this.Para_Ekle(UserID, UrunTipi, UrunMiktari, UrunFiyat, UrunIstek, Satısta_mı, ParaMiktarı, ParaIstek);
        }
        private bool Para_Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek, Boolean Satısta_mı, string ParaMiktarı, Boolean ParaIstek)
        {
            baglanti.Open();
            string sqlkodu = "insert into Moneys(UserID,MoneyAmount,MoneyRequest) values (@UserID,@MoneyAmount,@MoneyRequest)";
            ekle = new OleDbCommand(sqlkodu, baglanti);


            ekle.Parameters.AddWithValue("@UserID", UserID);
            ekle.Parameters.AddWithValue("@MoneyAmount", ParaMiktarı);
            ekle.Parameters.AddWithValue("@MoneyRequest", ParaIstek);
            ekle.ExecuteNonQuery() ;

            baglanti.Close();

            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("ParaKontrol");
            kontrol.KontrolEt(UserID,"","");

            return true;
        }
    }
}
