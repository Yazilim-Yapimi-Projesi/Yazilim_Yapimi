using System;
using System.Windows.Forms;
using System.Xml;
using System.Data.OleDb;

namespace yazilimYapimi
{
    class Doviz
    {
        string Dolar;
        string Pound;
        string Euro;

        public  Doviz()
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(url);
            
            Euro  = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            Dolar = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            Pound = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
        }

        public string EuroGetir()
        {
            return Euro;
        }

        public string DolarGetir()
        {
           
            return Dolar;
        }
        public string PoundGetir()
        {
            
            return Pound;
        }

        public double DovizDonusumuYap(string MoneyID)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
            OleDbCommand komut;
            OleDbDataReader oku;
            string sqlkodu, DövizTipi;
            double Para, Kur;

            //Döviz Dönüsümü için gerekli bilgiler veritabanından çekilir
            baglanti.Open();

            sqlkodu = ("select * from Moneys where MoneyID=" + MoneyID);
            komut = new OleDbCommand(sqlkodu, baglanti);
            oku = komut.ExecuteReader();

            //Çekilen bilgiler okunur ve ilgili değişkenlere atanır
            oku.Read();
            Para = Convert.ToInt32(oku[2]);
            DövizTipi = oku[4].ToString();

            //Uygun olan döviz tipine göre döviz kuru belirlenir, Kur değişkenine atanır.

            if (DövizTipi == "EUR") { Kur = Convert.ToDouble(Euro); }
            else if (DövizTipi == "USD") { Kur = Convert.ToDouble(Dolar); }
            else if (DövizTipi == "GBP") { Kur = Convert.ToDouble(Pound); }
            else Kur = 1;

            //İlgili değer  X,xx formatına donustulur. Virgulden sonra 2 basamak kalacak hale getirilir.  
            Kur = Kur / 10000;
            Kur = Math.Round(Kur, 2);

            Para = Para * Kur;
            Para = Math.Round(Para, 2);

            baglanti.Close();
            return Para;
        }

    }
}
