using System.Web.Mvc;
using System.Web.Routing;

namespace OrangeBricks.Web.Attributes
{
    public class OrangeBricksAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Account", action = "UnAuthorized" }));
            }
        }
    }
}