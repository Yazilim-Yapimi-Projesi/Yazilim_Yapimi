using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class RaporListele : IRapor
    {
        public DataTable Listele(string UserID, string ItemName, string SDatetime, string LDateTime, string Choise)
        {
            return RaporListesiniGetir(UserID, ItemName, SDatetime, LDateTime, Choise);
        }
        private DataTable RaporListesiniGetir(string UserID, string ItemName, string SDatetime, string LDateTime, string Choise)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            DataTable tablo6 = new DataTable();
            OleDbCommand islem;

            baglanti.Open();
            if (Choise == "Hepsi")
            {
                islem = new OleDbCommand("select BuyerID,BuyerName,BuyerSurname,SellerID,SellerName,SellerSurname,Itemname,ItemAmount,ItemUnitPrice,SellDate from CompletedPurchase where ([SellerID] = @sellerid or [BuyerID] = @buyerid) and ([Itemname]=@itemname) and ([SellDate]>@sdatetime and [SellDate]<@ldatetime)", baglanti);
                islem.Parameters.AddWithValue("@buyerid", UserID.ToString());
                islem.Parameters.AddWithValue("@sellerid", UserID.ToString());
                islem.Parameters.AddWithValue("@itemname", ItemName.ToString());
                islem.Parameters.AddWithValue("@sdatetime", SDatetime.ToString());
                islem.Parameters.AddWithValue("@ldatetime", LDateTime.ToString());
                OleDbDataAdapter adp6 = new OleDbDataAdapter(islem);
                adp6.Fill(tablo6);
            }
            else if (Choise == "Sattığım Ürünler")
            {
                islem = new OleDbCommand("select BuyerID,BuyerName,BuyerSurname,SellerID,SellerName,SellerSurname,Itemname,ItemAmount,ItemUnitPrice,SellDate from CompletedPurchase where ([SellerID] = @sellerid) and ([Itemname]=@itemname) and ([SellDate]>@sdatetime and [SellDate]<@ldatetime)", baglanti);
                islem.Parameters.AddWithValue("@sellerid", UserID.ToString());
                islem.Parameters.AddWithValue("@itemname", ItemName.ToString());
                islem.Parameters.AddWithValue("@sdatetime", SDatetime.ToString());
                islem.Parameters.AddWithValue("@ldatetime", LDateTime.ToString());

                OleDbDataAdapter adp6 = new OleDbDataAdapter(islem);
                adp6.Fill(tablo6);
            }
            else
            {
                islem = new OleDbCommand("select BuyerID,BuyerName,BuyerSurname,SellerID,SellerName,SellerSurname,Itemname,ItemAmount,ItemUnitPrice,SellDate from CompletedPurchase where ([BuyerID] = @buyerid) and ([Itemname]=@itemname) and ([SellDate]>@sdatetime and [SellDate]<@ldatetime)", baglanti);
                islem.Parameters.AddWithValue("@buyerid", UserID.ToString());
                islem.Parameters.AddWithValue("@itemname", ItemName.ToString());
                islem.Parameters.AddWithValue("@sdatetime", SDatetime.ToString());
                islem.Parameters.AddWithValue("@ldatetime", LDateTime.ToString());
                OleDbDataAdapter adp6 = new OleDbDataAdapter(islem);
                adp6.Fill(tablo6);
            }
            baglanti.Close();
            return tablo6;
        }
    }
}
