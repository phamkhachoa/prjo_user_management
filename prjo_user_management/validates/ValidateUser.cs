using prjo_user_management.logics.impl;
using prjo_user_management.Models;
using prjo_user_management.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjo_user_management.validates
{
    public class ValidateUser
    {
        private List<string> list;
        public List<string> validateLogin(string username, string password)
        {
            list = new List<string>();
            string aler = "";
            bool temp = true;
            if (Common.IsEmpty(username))
            {
                aler = string.Format("{0}", Constant.ER001_username);
                list.Add(Constant.ER001_username);
                temp = false;
            }

            if(Common.IsEmpty(password))
            {
                aler = aler + string.Format("<br /> {0}", Constant.ER001_username);
                list.Add(Constant.ER001_password);
                temp = false;
            }

            if (temp)
            {
                temp = this.CheckUsernamePassword(username, password);
            }

            return list;
        }


        public bool CheckUsernamePassword (string username, string password)
        {
            TblUserLogicImpl tblLogic = new TblUserLogicImpl();

            tbl_user tblUser = tblLogic.GetUserByUserName(username);

            if(tblUser != null)
            {
                int kt = tblUser.password.CompareTo(password);
                if (kt==0)
                {
                    return true;
                }
            }
            list.Add(Constant.ER016);
            return false;
        }


    }
}