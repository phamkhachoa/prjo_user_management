using prjo_user_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjo_user_management.dao
{
    interface ITblUserDao
    {
        tbl_user GetUserByUserName(string login_name);
        List<UserInfor> GetListUsers(int offset, int limit, int groupId, string fullName, string sortType, string sortByFullName, string sortByCodeLevel, string sortByEndDate);
        int GetTotalUsers(int groupId, string fullName);
        bool AddUser(UserInfor userInfor);
    }
}
