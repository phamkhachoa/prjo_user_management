using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjo_user_management.Models
{
    public class UserInfor
    {
        private int id;
        private string name;
        private string birthday;
        private string email;
        private string tel;
        private string group_name;
        private int groupId;
        private string name_level;
        private System.DateTime? end_date;
        private int total;
        private string login_name;
        private string full_name_kana;
        private string password;
        private string passwordConfirm;
        private System.DateTime start_date;
        private string code_level;
        private int role;
        private string action;
        private string totalStr;

        public UserInfor(int id, string name, string birthday, string email, string tel, string group_name, string name_level, System.DateTime? end_date, int total)
        {
            this.id = id;
            this.name = name;
            this.birthday = birthday;
            this.email = email;
            this.tel = tel;
            this.group_name = group_name;
            this.name_level = name_level;
            this.end_date = end_date;
            this.total = total;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Email { get => email; set => email = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Group_name { get => group_name; set => group_name = value; }
        public int GroupId { get => groupId; set => groupId = value; }
        public string Name_level { get => name_level; set => name_level = value; }
        public System.DateTime? End_date { get => end_date; set => end_date = value; }
        public int Total { get => total; set => total = value; }
        public string Login_name { get => login_name; set => login_name = value; }
        public string Full_name_kana { get => full_name_kana; set => full_name_kana = value; }
        public string Password { get => password; set => password = value; }
        public string PasswordConfirm { get => passwordConfirm; set => passwordConfirm = value; }
        public System.DateTime Start_date { get => start_date; set => start_date = value; }
        public string Code_level { get => code_level; set => code_level = value; }
        public int Role { get => role; set => role = value; }
        public string Action { get => action; set => action = value; }
        public string TotalStr { get => totalStr; set => totalStr = value; }
    }
}