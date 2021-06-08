using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazilimYapimi
{
    class ListelemeFabrikası
    {
       
        public IListe ListeOlustur(string ListeTipi)
        {
            if (ListeTipi == "ParaOnayListesi")
            {
                return new ParaOnayListele();
            }
            else if (ListeTipi == "UrunOnayListesi")
            {
                return new UrunOnayListele();
            }
            else if (ListeTipi == "UrunListem")
            {
                return new UrunListem();
            }
            else if (ListeTipi == "PazardakiUrunlerim")
            {
                return new SatılıkUrunListem();
            }
            else if (ListeTipi == "PazarListesi")
            {
                return new PazarListele();
            }


            else return null;
        }
        public IRapor RaporListeOlustur(string ListeTipi)
        {
            if (ListeTipi == "RaporListele")
            {
                return new RaporListele();
            }
            else return null;

        }

    }
}
