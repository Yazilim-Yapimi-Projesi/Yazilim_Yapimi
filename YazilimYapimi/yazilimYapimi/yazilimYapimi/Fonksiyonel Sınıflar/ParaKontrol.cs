using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class ParaKontrol : IKontrol
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand komut;
        OleDbDataReader oku;
        string sqlkodu;
        public bool KontrolEt(string UserID, string ItemName, string ItemAmount)
        {
            return this.ParayıKontrolEt( UserID,ItemName,ItemAmount);
        }

        private bool ParayıKontrolEt(string UserID, string ItemName, string ItemAmount)
        {
            baglanti.Open();
            int ToplamPara = 0;
            OleDbCommand getir = new OleDbCommand("select MoneyAmount from Moneys where MoneyRequest= true and UserID=@userid", baglanti);
            getir.Parameters.AddWithValue("@userid", UserID);
            oku = getir.ExecuteReader();
            while (oku.Read())
            {
                ToplamPara += Convert.ToInt32(oku[0]);
            }

            sqlkodu = "Delete from Moneys where MoneyRequest= true and UserID=@userid";
            komut = new OleDbCommand(sqlkodu, baglanti);
            komut.Parameters.AddWithValue("@userid", UserID);
            komut.ExecuteNonQuery();

            sqlkodu = "insert into Moneys(UserID,MoneyAmount,MoneyRequest) values (@UserID,@MoneyAmount,@MoneyRequest)";
            komut = new OleDbCommand(sqlkodu, baglanti);

            komut.Parameters.AddWithValue("@UserID", UserID);
            komut.Parameters.AddWithValue("@MoneyAmount", ToplamPara);
            komut.Parameters.AddWithValue("@MoneyRequest", true);
            komut.ExecuteNonQuery();



            baglanti.Close();
            return true;
        }


    }

}
