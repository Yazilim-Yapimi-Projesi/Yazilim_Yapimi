using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace yazilimYapimi
{
    class IslemiSirayaAl
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Borsa.accdb");
        OleDbCommand komut;
        OleDbDataReader oku;
        string sqlkodu;

        public IslemiSirayaAl()
        {

        }
    }
}
