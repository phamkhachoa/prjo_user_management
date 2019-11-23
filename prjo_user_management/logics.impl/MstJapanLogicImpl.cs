using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjo_user_management.dao.impl;
using prjo_user_management.entities;
using prjo_user_management.Models;

namespace prjo_user_management.logics.impl
{
    public class MstJapanLogicImpl : IMstJapanLogic
    {
        MstJapanDaoImpl mstJapan;

        public MstJapanLogicImpl()
        {
            mstJapan = new MstJapanDaoImpl();
        }

        public List<MstJapan> GetAllMstJapan()
        {
            return mstJapan.GetAllMstJapan();
        }
    }
}