using prjo_user_management.logics.impl;
using prjo_user_management.Models;
using prjo_user_management.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjo_user_management.Controllers
{
    public class ListUserController : Controller
    {
        // GET: ListUser
        public ActionResult ADM002()
        {
            string full_name = Common.GetParameter(Request.Form["full_name"], Session.Contents["full_name"], Constant.DEFAULT_FULLNAME);
            string sortType = Common.GetParameter(Request.Form["sortType"], Session.Contents["sortType"], Constant.SORT_BY_DEFAULT);
            string sortByFullName = Common.GetParameter(Request.Form["sortByFullName"], Session.Contents["sortByFullName"], Constant.SORT_INCREMENT);
            string sortByCodeLevel = Common.GetParameter(Request.Form["sortByCodeLevel"], Session.Contents["sortByCodeLevel"], Constant.SORT_INCREMENT);
            string sortByEndDate = Common.GetParameter(Request.Form["sortByCodeLevel"], Session.Contents["sortByCodeLevel"], Constant.SORT_DECREMENT);
            int groupId = Common.GetParameter(Request.Form["group_id"], Session.Contents["group_id"], Constant.DEFAULT_GROUPID);


            TblUserLogicImpl tUserLogic = new TblUserLogicImpl();
            List<UserInfor> listUser = tUserLogic.GetListUsers(groupId, full_name, sortType, sortByFullName, sortByCodeLevel, sortByEndDate);
            MstGroupLogicImpl mstGroup = new MstGroupLogicImpl();
            List<mst_group> listMstGroup = mstGroup.GetAllMstGroup();

            ViewBag.listMstGroup = listMstGroup;
            ViewBag.listUser = listUser;
            return View();
        }
    }
}