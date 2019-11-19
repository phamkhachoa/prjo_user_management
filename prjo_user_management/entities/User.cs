using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjo_user_management.entities
{
    public class User
    {
        private int user_id;
        private int group_id;
        private string login_name;
        private string password;
        private string full_name;
        private string full_name_kana;
        private string email;
        private string tel;
        private string birthday;
        private int role;
        private string salt;
        
        public int User_id { get => user_id; set => user_id = value; }
        public int Group_id { get => group_id; set => group_id = value; }
        public string Login_name { get => login_name; set => login_name = value; }
        public string Password { get => password; set => password = value; }
        public string Full_name { get => full_name; set => full_name = value; }
        public string Full_name_kana { get => full_name_kana; set => full_name_kana = value; }
        public string Email { get => email; set => email = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public int Role { get => role; set => role = value; }
        public string Salt { get => salt; set => salt = value; }
    }
}