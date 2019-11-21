using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjo_user_management.Data;
using prjo_user_management.Models;

namespace prjo_user_management.dao.impl
{
    public class MstGroupDaoImpl : IMstGroupDao
    {
        DatabaseContext context;
        public List<mst_group> GetAllMstGroup()
        {
            context = new DatabaseContext();
            var mstGroups = context.MstGroups.ToList();
            return mstGroups;

        }
    }
}