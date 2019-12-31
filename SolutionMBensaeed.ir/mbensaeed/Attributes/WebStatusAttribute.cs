using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mbensaeed.Attributes
{
    public class WebStatusAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
            var action = routeValues["action"].ToString().ToLower();
            var controller = routeValues["controller"].ToString().ToLower();
            if (controller != "home" || action != "updating")
            {
                var State = ConfigurationManager.AppSettings["ActiveWebSite"];
                if (State == "False" || State == "false")
                {
                    //if (controller == "account" && action == "ftmmanagement")
                    //{
                    //    base.OnActionExecuting(filterContext);
                    //}
                    //{
                    filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary(
                                           new
                                           {
                                               controller = "Home",
                                               action = "Updating"
                                           }));
                    // }

                }
            }
        }
    }
}