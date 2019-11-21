using prjo_user_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjo_user_management.dao
{
    interface IMstGroupDao
    {
        List<mst_group> GetAllMstGroup();
    }
}
