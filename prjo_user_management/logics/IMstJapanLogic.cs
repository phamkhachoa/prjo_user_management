using prjo_user_management.entities;
using prjo_user_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjo_user_management.logics
{
    interface IMstJapanLogic
    {
        List<MstJapan> GetAllMstJapan();
    }
}
