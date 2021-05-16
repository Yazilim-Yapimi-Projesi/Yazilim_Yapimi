using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazilimYapimi
{
    class OnayFabrikası
    {
        public IOnay OnaylamaNesnesiOlustur(string onayTipi)
        {
            if (onayTipi == "ParaOnay")
            {
                return new ParaOnay();
            }
            else if (onayTipi == "UrunOnay")
            {
                return new UrunOnay();
            }
            else return null;
        }
    }
}
