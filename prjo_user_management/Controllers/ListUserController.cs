using Newtonsoft.Json;
using prjo_user_management.entities;
using prjo_user_management.logics.impl;
using prjo_user_management.Models;
using prjo_user_management.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace prjo_user_management.Controllers
{
    public class ListUserController : Controller
    {
        // GET: ListUser
        public ActionResult ADM002()
        {
            string full_name = Common.GetParameter(Request.QueryString["full_name"], Session.Contents["full_name"], Constant.DEFAULT_FULLNAME);
            string sortType = Common.GetParameter(Request.QueryString["sortType"], Session.Contents["sortType"], Constant.SORT_BY_DEFAULT);
            string sortByFullName = Common.GetParameter(Request.QueryString["sortByFullName"], Session.Contents["sortByFullName"], Constant.SORT_INCREMENT);
            string sortByCodeLevel = Common.GetParameter(Request.QueryString["sortByCodeLevel"], Session.Contents["sortByCodeLevel"], Constant.SORT_INCREMENT);
            string sortByEndDate = Common.GetParameter(Request.QueryString["sortByEndDate"], Session.Contents["sortByEndDate"], Constant.SORT_DECREMENT);
            int groupId = Common.GetParameter(Request.QueryString["group_id"], Session.Contents["group_id"], Constant.DEFAULT_GROUPID);
            string currentPageStr = Request.QueryString["page"];
            Int32 currentPage = 1; // Trang hiện tại.

            if (currentPageStr == null)
            {
                currentPage = Common.GetParameter(null, Session.Contents["currentPage"], 1);

                if(Request.QueryString["group_id"] != null)
                {
                    currentPage = 1;
                }
                
            } else
            {
                currentPage = Int32.Parse(currentPageStr);
            }

            int offset = Common.getOffset(currentPage,Constant.ROW);

            TblUserLogicImpl tUserLogic = new TblUserLogicImpl();
            MstGroupLogicImpl mstGroup = new MstGroupLogicImpl();

            int totalUsers = tUserLogic.GetTotalUsers(groupId, full_name); // Lấy tổng số user.
            int totalPages; // Tổng số pages.

            totalPages = Common.GetTotalPages(totalUsers, Constant.ROW); // Số page cần thiết.

            // Kiểm tra xem page truyền lên có lớn hơn tổng số page.
            if (currentPage > totalPages)
            {
                currentPage = 1;
                offset = 0;
            }
            List<Int32> listPages = Common.getListPaging(totalUsers, Constant.ROW, currentPage);

            List<UserInfor> listUser = tUserLogic.GetListUsers(offset, Constant.ROW, groupId, full_name, sortType, sortByFullName, sortByCodeLevel, sortByEndDate);            
            List<MstGroup> listMstGroup = mstGroup.GetAllMstGroup();

            Session.Add("sortType", sortByFullName);
            Session.Add("sortByFullName", sortByFullName);
            Session.Add("sortByCodeLevel", sortByCodeLevel);
            Session.Add("sortByEndDate", sortByEndDate);
            Session.Add("currentPage", currentPage);

            Session.Add("group_id", groupId);
            Session.Add("full_name", full_name);

            ViewBag.listPages = listPages;
            ViewBag.totalPages = totalPages;
            ViewBag.totalUsers = totalUsers;
            ViewBag.listMstGroup = listMstGroup;
            ViewBag.listUser = listUser;


            return View();
        }

        [HttpPost]
        public JsonResult ADM002Add()
        {
            MstJapanLogicImpl mstJapan = new MstJapanLogicImpl();
            MstGroupLogicImpl mstGroup = new MstGroupLogicImpl();
            var result = new
            {
               listMstJapan =  mstJapan.GetAllMstJapan(),
                listMstGroup = mstGroup.GetAllMstGroup()
            };

            //var json = JsonConvert.SerializeObject(mstJapan.GetAllMstJapan());

            return Json(result);
            //string mess = "Hello";
            //return Json(new { mess = mess });

        }
    }
}