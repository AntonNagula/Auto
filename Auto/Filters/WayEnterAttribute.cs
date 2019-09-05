using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auto.Filters
{
    public class WayEnterAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // если пользователь не принадлежит роли admin, то он перенаправляется на Home/About
            bool auth = filterContext.HttpContext.User.IsInRole("user");
            if (auth)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                { "controller", "Buyer" }, { "action", "Index" }
                });
            }
            auth = filterContext.HttpContext.User.IsInRole("admin");
            if (auth)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                { "controller", "Admin" }, { "action", "Index" }
                });
            }           
            
        }
    }
}