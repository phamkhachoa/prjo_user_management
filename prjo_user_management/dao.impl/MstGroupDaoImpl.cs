using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjo_user_management.Data;
using prjo_user_management.entities;
using prjo_user_management.Models;

namespace prjo_user_management.dao.impl
{
    public class MstGroupDaoImpl : IMstGroupDao
    {
        DatabaseContext context;
        public List<MstGroup> GetAllMstGroup()
        {
            List<MstGroup> listMstGroup = new List<MstGroup>();
            context = new DatabaseContext();
            var mstGroups = context.MstGroups.Select(a => new { GroupId = a.group_id, GroupName = a.group_name });

            foreach(var el in mstGroups)
            {
                listMstGroup.Add(new MstGroup(el.GroupId, el.GroupName));
            }
            return listMstGroup;

        }
    }
}