using mbensaeed.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace mbensaeed
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        /// برای ثبت بازدید وبسایت
        /// </summary>

        protected void Session_Start()
        {
            NetworkOperation objNetworkOperation = new NetworkOperation();
            VisitWebsiteLog objVisitWebsiteLog = new VisitWebsiteLog();
            string CurrentClientIP = objNetworkOperation.ClientIPaddress();

            try
            {
                objVisitWebsiteLog.StartOperation(CurrentClientIP);
            }
            catch (Exception)
            {

            }
            //}
        }
    }
}
