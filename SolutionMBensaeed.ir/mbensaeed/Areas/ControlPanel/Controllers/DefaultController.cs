using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Areas.ControlPanel.Controllers
{
    public class DefaultController : Controller
    {
        // GET: ControlPanel/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}