using prjo_user_management.validates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjo_user_management.Controllers
{
    public class LoginController : Controller
    {
        List<string> listErroMessage;
        // GET: Login
        public ActionResult ADM001()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["username"])))
            {
                Session.Remove("username");
            }
            ViewBag.listErr = TempData["listErr"];
            return View();
        }


        [HttpPost]
        public ActionResult Autherize()
        {
            ValidateUser validateUser = new ValidateUser();
            string username = Request.Form["loginId"];
            string password = Request.Form["password"];

            listErroMessage = validateUser.validateLogin(username, password);

            if(listErroMessage.Count == 0)
            {
                Session.Add("username", username);
                return RedirectToAction("ADM002", "ListUser");
            }
            else
            {
                //List<string> listErroMessage1 = this.Request.QueryString[listErroMessage];
                TempData["listErr"] = listErroMessage;
                return RedirectToAction("ADM001", "Login");
            }
        }
    }
}