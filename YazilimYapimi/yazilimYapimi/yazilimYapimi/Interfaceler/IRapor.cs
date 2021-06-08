using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace yazilimYapimi
{
    interface IRapor
    {
        DataTable Listele(string UserID, string ItemName, string SDatetime, string LDateTime, string Choise);
    }
}
