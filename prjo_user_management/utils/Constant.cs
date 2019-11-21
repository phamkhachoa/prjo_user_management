using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjo_user_management.utils
{
    public class Constant
    {
        public static string ER001_username = "アカウント名を入力してください";
        public static string ER001_password = "パスワードを入力してください";
        public static string ER016 = "アカウント名またはパスワードは不正です。";
        public static string DEFAULT_FULLNAME= "";
        public static string SORT_BY_DEFAULT = "full_name";
        public static string SORT_INCREMENT = "asc";
	    public static string SORT_DECREMENT = "desc";
        public static int DEFAULT_GROUPID = 0;
    }
}