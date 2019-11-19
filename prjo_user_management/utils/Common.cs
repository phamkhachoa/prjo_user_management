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
            if ("".Equals(str))
            {
                return true;
            }

            return false;
        }
    }
}