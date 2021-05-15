using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class UrunKontrol : IKontrol
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand komut;
        OleDbDataReader oku;
        string sqlkodu;
        public bool KontrolEt(string UserID, string ItemName, string ItemAmount)
        {
            return this.UrunuKontrolEt( UserID, ItemName, ItemAmount);
        }

        private bool UrunuKontrolEt(string UserID, string ItemName, string ItemAmount)
        {
            int ToplamKG = 0;
            baglanti.Open();

            sqlkodu = "select * from UserItems where (UserID=@userid) and (ItemName=@itemname) and (ItemAmount=@itemamount) and (ItemRequest=@itemrequest) and (ItemForSale=@ıtemforsale)";
            komut = new OleDbCommand(sqlkodu, baglanti);

            komut.Parameters.AddWithValue("@userid", UserID);
            komut.Parameters.AddWithValue("@itemname", ItemName);
            komut.Parameters.AddWithValue("@itemamount", ItemAmount);
            komut.Parameters.AddWithValue("@itemrequest", true);
            komut.Parameters.AddWithValue("@ıtemforsale", true);


            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ToplamKG += Convert.ToInt32(oku[3]);
            }

          
                sqlkodu = "delete from UserItems where (UserID=@userid) and (ItemName=@itemname) and (ItemAmount=@itemamount) and (ItemRequest=@itemrequest) and (ItemForSale=@ıtemforsale)";
                komut = new OleDbCommand(sqlkodu, baglanti);

                komut.Parameters.AddWithValue("@userid", UserID);
                komut.Parameters.AddWithValue("@itemname", ItemName);
                komut.Parameters.AddWithValue("@itemamount", ItemAmount);
                komut.Parameters.AddWithValue("@itemrequest", true);
                komut.Parameters.AddWithValue("@ıtemforsale", true);
                komut.ExecuteNonQuery();

            if (ToplamKG != 0)
            {
                sqlkodu = "insert into UserItems(UserID,ItemName,ItemKg,ItemAmount,ItemRequest,ItemForSale) values (@UserID,@ItemName,@ItemKg,@ItemAmount,@ItemRequest,@ItemForSale)";
                komut = new OleDbCommand(sqlkodu, baglanti);

                komut.Parameters.AddWithValue("@UserID", UserID);
                komut.Parameters.AddWithValue("@ItemName", ItemName);
                komut.Parameters.AddWithValue("@ItemKg", ToplamKG.ToString());
                komut.Parameters.AddWithValue("@ItemAmount", ItemAmount);
                komut.Parameters.AddWithValue("@ItemRequest", true);
                komut.Parameters.AddWithValue("@ItemForSale", true);
                komut.ExecuteNonQuery();
            }


            baglanti.Close();
            return true;
        }

    }
}
