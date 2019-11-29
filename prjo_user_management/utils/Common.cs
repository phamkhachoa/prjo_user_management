using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjo_user_management.utils
{
    /// <summary>
    /// Methods common of project
    /// Create by HoaPK 19/11/2019
    /// </summary>
    public class Common
    {
        /// <summary>
        /// Check string is empty or not.
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>
        ///     true: input string is null
        ///     false: input string isn't null
        /// </returns>
        public static bool IsEmpty(string str)
        {
            if ("".Equals(str)|| (str == null))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Get data from retquest or session.
        /// </summary>
        /// <param name="requestPara"></param>
        /// <param name="sessionPara"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetParameter<T>(string requestPara, object sessionPara, T defaultValue)
        {
            T value = default(T);
            if (requestPara == null)
            {
                if (sessionPara == null)
                {
                    value = defaultValue;
                }
                else
                {
                    value = (T)sessionPara;
                }
            }
            else
            {
                if (defaultValue is Int32)
                {
                    value = (T)(object)Int32.Parse(requestPara);
                }
                else
                {
                    value = (T)(object)requestPara;
                }


            }

            return value;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        public static IQueryable GetStringOrder(IQueryable query, string sortType)
        {
            switch (sortType)
            {
                case "full_name":


                    break;

                case "code_level":

                    break;

                case "end_date":

                    break;
            }
            return query;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="rowLimit"></param>
        /// <returns></returns>
        public static int getOffset(int currentPage, int rowLimit)
        {
            return (currentPage - 1) * rowLimit;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalUsers"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static int GetTotalPages(int totalUsers, int limit)
        {
            int count = totalUsers / limit; // Lấy phần nguyên.
            int temp = totalUsers % limit; // lấy phần dư.
            if (temp != 0)
            {
                count += 1;
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalRecords"></param>
        /// <param name="limit"></param>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public static List<Int32> getListPaging(int totalRecords, int limit, int currentPage)
        {
            List<Int32> list = new List<Int32>();
            int totalPages = GetTotalPages(totalRecords, limit);
            //System.out.println("TotalPages: " + totalPages);
            int firstPage = getFirstPage(Constant.PAGE_DISPLAY_NUM, currentPage);
            int lastPage = getLastpage(Constant.PAGE_DISPLAY_NUM, currentPage);
            for (int i = firstPage; i <= lastPage; i++)
            {
                if (i <= totalPages)
                {
                    list.Add(i);
                }
            }
            return list;
        }

        /**
         * Hàm lấy ra page đầu tiên trong listPaging.
         * @param limitPage số page hiển thị trên 1 trang.
         * @param currentPage trang hiện tại.
         * @return
         */
        public static int getFirstPage(int limitPage, int currentPage)
        {
            //int totalPages = getTotalPages(totalRecords, limit);
            int page;
            if (currentPage % limitPage == 0)
            {
                page = currentPage - limitPage + 1;
            }
            else
            {
                page = currentPage - currentPage % limitPage + 1;
            }

            return page;

        }
        /**
         * Hàm lấy ra trang cuối cùng ứng với vị trí trang hiện tại.
         * @param limitPage số page hiển thị trên 1 trang.
         * @param currentPage trang hiện tại.
         * @return
         */
        public static int getLastpage(int limitPage, int currentPage)
        {
            int page;
            int temp1 = currentPage / limitPage;
            int temp = currentPage % limitPage;
            if (temp == 0)
            {
                page = temp1 * limitPage;
            }
            else
            {
                page = (temp1 + 1) * limitPage;
            }
            return page;

        }
    }
}