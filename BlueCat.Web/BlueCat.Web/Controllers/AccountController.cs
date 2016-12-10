using BlueCat.Model;
using BlueCat.Web.Common;
using System.Web.Mvc;

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
