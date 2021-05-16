using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazilimYapimi
{
    interface IOnay
    {
        bool Onayla(string UserID, string ItemName, string ItemAmount, string ItemID, string MoneyID);
    }
}
