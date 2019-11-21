using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjo_user_management.dao.impl;
using prjo_user_management.Models;

namespace prjo_user_management.logics.impl
{
    public class MstGroupLogicImpl : IMstGroupLogic
    {
        MstGroupDaoImpl mstGroup;
        List<mst_group> listMstGroup;
        public List<mst_group> GetAllMstGroup()
        {
            mstGroup = new MstGroupDaoImpl();
            listMstGroup = mstGroup.GetAllMstGroup();
            return listMstGroup;
        }
    }
}