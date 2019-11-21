using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjo_user_management.dao.impl;
using prjo_user_management.Models;

namespace prjo_user_management.logics.impl
{
    public class TblUserLogicImpl : ITblUserLogic
    {
        TblUserDaoImpl userDao;
        tbl_user tblUser;

        public List<UserInfor> GetListUsers(int groupId, string fullName, string sortType, string sortByFullName, string sortByCodeLevel, string sortByEndDate)
        {
            userDao = new TblUserDaoImpl();
            return userDao.GetListUsers(groupId, fullName, sortType, sortByFullName, sortByCodeLevel, sortByEndDate);
            //throw new NotImplementedException();
        }

        public tbl_user GetUserByUserName(string login_name)
        {
            userDao = new TblUserDaoImpl();
            tblUser = userDao.GetUserByUserName(login_name);
            return tblUser;
            //throw new NotImplementedException();
        }
    }
}