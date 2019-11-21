﻿using prjo_user_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjo_user_management.logics
{
    interface ITblUserLogic
    {
        tbl_user GetUserByUserName(string login_name);
        List<UserInfor> GetListUsers(int groupId, string fullName, string sortType, string sortByFullName, string sortByCodeLevel, string sortByEndDate);
    }
}