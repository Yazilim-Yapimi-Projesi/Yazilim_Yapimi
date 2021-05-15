using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazilimYapimi
{
    class KontrolFabrikası
    {
        public IKontrol KontrolEdilcekNesneOlustur(string eklenecekTip)
        {
            if (eklenecekTip == "UrunKontrol")
            {
                return new UrunKontrol();
            }
            else if (eklenecekTip == "ParaKontrol")
            {
                return new ParaKontrol();
            }
            else return null;
        }
    }
}
