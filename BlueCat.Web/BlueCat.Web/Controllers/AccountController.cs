using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using BlueCat.Web.Filters;
using BlueCat.Web.Models;
using BlueCat.Web.Common;
using BlueCat.Model;

namespace BlueCat.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public void UserLogin()
        {
            string username = Request["username"];
            string password = Request["password"];
            //todo get password

            UserModel usermodel=new UserModel();
            usermodel.UserName = username;
            SessionManager.User = usermodel;
        }
    }
}
