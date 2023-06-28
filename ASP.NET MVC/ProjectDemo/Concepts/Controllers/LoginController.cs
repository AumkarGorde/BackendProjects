using Concepts.DAL;
using Concepts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Concepts.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View("Login");
        }

        public ActionResult SubmitLogin(UserDetails userDetails)
        {
            CustomerDAL cusdal = new CustomerDAL();
            var lsitOfUsers = cusdal.dbSetUserInfo.ToList<UserDetails>();
            var tempUser = lsitOfUsers.FirstOrDefault(u => u.UserName == userDetails.UserName && u.UserPassword == userDetails.UserPassword);
            if (tempUser is null)
            {
                return View("Login");
            }
            else
            {
                FormsAuthentication.SetAuthCookie("Cookie", true);
                return View("~/Views/Home/Index.cshtml");
            }
        }
    }
}