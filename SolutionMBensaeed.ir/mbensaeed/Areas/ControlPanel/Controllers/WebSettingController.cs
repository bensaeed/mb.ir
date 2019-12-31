using mbensaeed.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace mbensaeed.Areas.ControlPanel.Controllers
{
    public class WebSettingController : Controller
    {
        // GET: ControlPanel/WebSetting
        public ActionResult Index()
        {
            return View();
        }
        #region setting
        public ActionResult WebsiteStatus()
        {
            return View();
        }
        /// <summary>
        /// Set Value To DownWebSite in WebConfige
        /// if True Website is Up else Is Down(Website in Updating)
        /// </summary>
        /// <param name="StateID"></param>
        /// <returns></returns>
        public JsonResult UpdateWebsiteStatus(string StateID)
        {
            try
            {
                if (StateID == null || StateID == "")
                {
                    return Json("Faild");
                }

                Configuration AppConfigSettings = WebConfigurationManager.OpenWebConfiguration("~");
               
                AppConfigSettings.AppSettings.Settings["ActiveWebSite"].Value = StateID;
                AppConfigSettings.Save();

                return Json("OK");
            }
            catch (Exception)
            {
                return Json("Faild"); 
            }
        }
        [AjaxOnly]
        public JsonResult GetWebsiteStatusInfo()
        {
            var State = ConfigurationManager.AppSettings["ActiveWebSite"];
            return Json(State);
        }
        #endregion
    }
}