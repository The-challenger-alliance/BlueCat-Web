using BlueCat.Core;
using BlueCat.Model;
using BlueCat.Web.Common;
using System.Web.Mvc;

namespace BlueCat.Web.Controllers
{
    public class BaseController : Controller
    {
        public UserModel CurrentBlueCatUser
        {
            get
            {
                return SessionManager.User;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var noAuthorizeAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizeIgnoreAttribute), false);

            if (noAuthorizeAttributes.Length > 0) return;
            
            base.OnActionExecuting(filterContext);

            if (this.CurrentBlueCatUser == null)
            {
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.HttpContext.Response.StatusDescription = "needs login";
                return;
            }
        }
    }
}
