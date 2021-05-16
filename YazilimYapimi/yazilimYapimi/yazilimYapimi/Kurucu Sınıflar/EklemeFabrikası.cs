using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazilimYapimi
{
    class EklemeFabrikası
    {
        public IEkle EklemeNesnesiOlustur(string eklenecekTip)
        {
            if (eklenecekTip == "Urun")
            {
                return new UrunEkle();
            }
            else if (eklenecekTip == "Para")
            {
                return new ParaEkle();
            }
            else return null;
        }
    }
}
