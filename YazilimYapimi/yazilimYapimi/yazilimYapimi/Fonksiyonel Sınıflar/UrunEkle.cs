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
    class UrunEkle : IEkle
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand ekle;

        public bool Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek,Boolean Satısta_mı ,string ParaMiktarı, Boolean ParaIstek)
        { 
           
            return this.Urun_Ekle(UserID,  UrunTipi,  UrunMiktari, UrunFiyat,  UrunIstek, Satısta_mı, ParaMiktarı, ParaIstek);
        }
        private bool Urun_Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek, Boolean Satısta_mı , string ParaMiktarı, Boolean ParaIstek)
        {
            baglanti.Open();
            string sqlkodu = "insert into UserItems(UserID,ItemName,ItemKg,ItemAmount,ItemRequest,ItemForSale) values (@UserID,@ItemName,@ItemKg,@ItemAmount,@ItemRequest,@ItemForSale)";
            ekle = new OleDbCommand(sqlkodu, baglanti);

            ekle.Parameters.AddWithValue("@UserID", UserID);
            ekle.Parameters.AddWithValue("@ItemName", UrunTipi);
            ekle.Parameters.AddWithValue("@ItemKg", UrunMiktari);
            ekle.Parameters.AddWithValue("@ItemAmount", UrunFiyat);
            ekle.Parameters.AddWithValue("@ItemRequest", UrunIstek);
            ekle.Parameters.AddWithValue("@ItemForSale", Satısta_mı);
            ekle.ExecuteNonQuery();

            baglanti.Close();

            KontrolFabrikası kontrolFabrikası = new KontrolFabrikası();
            IKontrol kontrol = kontrolFabrikası.KontrolEdilcekNesneOlustur("UrunKontrol");
            kontrol.KontrolEt(UserID, UrunTipi, UrunFiyat);


            return true;
        }
    }
}

