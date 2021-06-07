using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazilimYapimi
{
    interface IEkle
    {
        bool Ekle(string UserID, string UrunTipi, string UrunMiktari, string UrunFiyat, Boolean UrunIstek, Boolean Satısta_mı, string ParaMiktarı, Boolean ParaIstek, string DövizTipi);
    }
}
