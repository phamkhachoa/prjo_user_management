using prjo_user_management.logics.impl;
using prjo_user_management.Models;
using prjo_user_management.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

     /**
	 * Hàm validate UserInfor
	 * @param userInfor user muốn kiểm tra.
	 * @return Danh sách các lỗi khi validate
	 * @throws Exception Lỗi 
	 */
        public List<string> validateUserInfor(UserInfor userInfor)
        {
            List<string> listError = new List<string>();
            TblUserLogicImpl tblUser = new TblUserLogicImpl();
		
		// Lấy ra các dữ liệu để validate.
		int userId = userInfor.Id;
        string loginName = userInfor.Login_name;
        int groupId = userInfor.GroupId;
        string fullName = userInfor.Name;
        string fullNameKana = userInfor.Full_name_kana;
        string birthday = userInfor.BirthdayStr;
        string email = userInfor.Email;
        string tel = userInfor.Tel;
        string password = userInfor.Password;
        string passwordConfirm = userInfor.PasswordConfirm;
        string codeLevel = userInfor.Code_level;
        string startDate = userInfor.StartDateStr;
        string endDate = userInfor.EndDateStr;
        string totalStr = userInfor.TotalStr;
        //string action = userInfor.getAction();

        // Danh sách các key lỗi.
        //MessageErrorProperties.getInstance();
		
		// validate loginName.
		if (Common.IsEmpty(loginName))
        { // Kiểm tra rỗng.
			listError.Add("The login name must be not null.");
		} else if (tblUser.GetUserByUserName(loginName) != null)
        { // Kiểm tra xem đã tồn tại loginName hay chưa.
			listError.Add("The login name had been used.");
		}		

		// validate email.
		if (Common.IsEmpty(email)) { // Kiểm tra rỗng.
			listError.Add("Email must be not null.");
		} else if (!Regex.IsMatch(email, "[a-z0-9-]+@[a-z0-9]+\\.[a-z]+")) { // Kiểm tra format.
			listError.Add("Invalid Email.");
		}
		
		// validate tel.
		if (Common.IsEmpty(tel)) { // Kiểm tra rỗng.
			listError.Add("Phone number must be not null.");
		} else if (!Regex.IsMatch(tel, "[0-9]*")) { // Kiểm tra format.
			listError.Add("Invalid Phone Number.");
		}
		

			// validate password.
		if (Common.IsEmpty(password)) { // Kiểm tra rỗng.
			listError.Add("Password must be not null.");
		}			
			// validate passwordConfirm.
		if (!(password == passwordConfirm)) { // Kiểm tra có giống vs pass không.
				listError.Add("Password and PasswordConfirm must be same.");
		}
		
		// validate trinh do tieng nhat.
		if(String.Compare(codeLevel, "0", true) != 0) { // Nếu có trình độ tiếng Nhật.
			// total

			if (Common.IsEmpty(totalStr)) {
				listError.Add("Total must be not null.");
			} else if (!Regex.IsMatch(totalStr, "[0-9]*")) {
				listError.Add("Invalid Total.");
			} else {
				userInfor.Total= Int32.Parse(totalStr);
			}
	    }
		return listError;
	    }


    }
}