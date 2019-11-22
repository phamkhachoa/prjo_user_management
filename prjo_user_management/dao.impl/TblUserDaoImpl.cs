using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using prjo_user_management.Data;
using prjo_user_management.Models;

namespace prjo_user_management.dao.impl
{
    public class TblUserDaoImpl : ITblUserDao
    {
        DatabaseContext context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="fullName"></param>
        /// <param name="sortType"></param>
        /// <param name="sortByFullName"></param>
        /// <param name="sortByCodeLevel"></param>
        /// <param name="sortByEndDate"></param>
        /// <returns></returns>
        public List<UserInfor> GetListUsers(int offset, int limit,int groupId, string fullName, string sortType, string sortByFullName, string sortByCodeLevel, string sortByEndDate)
        {
            List<UserInfor> listUsers = new List<UserInfor>();
            context = new DatabaseContext();
            var query = (from u in context.TblUsers
                         join g in context.MstGroups on u.group_id equals g.group_id
                         join j in context.TblDetailJ on u.user_id equals j.user_id into group1
                         from gr1 in group1.DefaultIfEmpty()
                         join mj in context.MstJapans on gr1.code_level equals mj.code_level into group2
                         from gr2 in group2.DefaultIfEmpty()
                         where ((groupId <= 0 || u.group_id == groupId) && (string.IsNullOrEmpty(fullName) || u.full_name.Contains(fullName))
                         )
                         //orderby (sortByFullName == "desc" ? u.full_name descending : u.full_name ascending)
                         //orderby u.full_name sortByFullName == "desc" ? descending :  ascending
                         select new
                         {
                             u.user_id,
                             u.group_id,
                             u.full_name,
                             u.birthday,
                             u.email,
                             u.tel,
                             g.group_name,
                             gr2.name_level,
                             gr2.code_level,
                             end_date = gr1.end_date != null ? gr1.end_date : (DateTime?)null,
                             total = gr1.total != null ? gr1.total : 0
                         }
                         );
            switch (sortByFullName)
            {
                case "asc":
                    query = query.OrderBy(x => x.full_name);
                    break;
                case "desc":
                    query = query.OrderByDescending(x => x.full_name);
                    break;
            }

            //switch (sortType)
            //{
            //    case "full_name":
            //        switch (sortByFullName)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.full_name);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.full_name);
            //                break;
            //        }

            //        switch (sortByCodeLevel)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.code_level);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.code_level);
            //                break;
            //        }
            //        switch (sortByEndDate)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.end_date);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.end_date);
            //                break;
            //        }
            //        break;

            //    case "code_level":
            //        switch (sortByCodeLevel)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.code_level);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.code_level);
            //                break;
            //        }
            //        switch (sortByFullName)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.full_name);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.full_name);
            //                break;
            //        }
            //        switch (sortByEndDate)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.end_date);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.end_date);
            //                break;
            //        }
            //        break;

            //    case "end_date":
            //        switch (sortByEndDate)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.end_date);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.end_date);
            //                break;
            //        }
            //        switch (sortByFullName)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.full_name);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.full_name);
            //                break;
            //        }

            //        switch (sortByCodeLevel)
            //        {
            //            case "asc":
            //                query = query.OrderBy(x => x.code_level);
            //                break;
            //            case "desc":
            //                query = query.OrderByDescending(x => x.code_level);
            //                break;
            //        }
            //        break;
            //}
            query = query.Skip(offset).Take(limit);
            //query.Take(limit);
            query.ToList();
            //.ToList();
            foreach (var el in query)
            {
                listUsers.Add(new UserInfor(el.user_id, el.full_name, el.birthday, el.email, el.tel, el.group_name, el.name_level, el.end_date, el.total));
                //DateTime date = null;
            }

            return listUsers;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public int GetTotalUsers(int groupId, string fullName)
        {
            context = new DatabaseContext();
            var query = (from u in context.TblUsers
                         join g in context.MstGroups on u.group_id equals g.group_id
                         join j in context.TblDetailJ on u.user_id equals j.user_id into group1
                         from gr1 in group1.DefaultIfEmpty()
                         join mj in context.MstJapans on gr1.code_level equals mj.code_level into group2
                         from gr2 in group2.DefaultIfEmpty()
                         where ((groupId <= 0 || u.group_id == groupId) && (string.IsNullOrEmpty(fullName) || u.full_name.Contains(fullName))
                         )
                         select u.user_id).Count();

            return query;
        }

        //LoginDataBaseEntities db;
        public tbl_user GetUserByUserName(string login_name)
        {
            context = new DatabaseContext();
            var userDetail = context.TblUsers.Where(c => c.login_name == login_name).FirstOrDefault();
            return userDetail;
            //throw new NotImplementedException();
        }
    }
}