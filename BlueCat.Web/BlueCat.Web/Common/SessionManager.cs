using BlueCat.Core;
using BlueCat.Model;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace BlueCat.Web.Common
{
    public class SessionManager
    {
        public static UserModel User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated == false) return null;
                var userData = ((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData;
                return string.IsNullOrWhiteSpace(userData) ? null : JsonConvert.DeserializeObject<UserModel>(userData);
            }
            set
            {
                System.Web.Security.FormsAuthentication.SignOut();
                SetCookie(value);
            }
        }

        private static void SetCookie(UserModel user)
        {
            var userDataStr = JsonConvert.SerializeObject(user);

            int hour = Convert.ToInt32(AppSetting.FormTicket);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1, user.UserName, DateTime.Now, DateTime.Now.AddHours(hour),
            false, userDataStr);

            string authTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie coo = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);
            HttpContext.Current.Response.Cookies.Add(coo);
        }
    }
}