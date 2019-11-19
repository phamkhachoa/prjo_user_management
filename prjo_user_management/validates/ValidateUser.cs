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

            return list;
        }
    }
}