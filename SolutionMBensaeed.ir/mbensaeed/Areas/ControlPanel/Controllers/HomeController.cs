using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Areas.ControlPanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: ControlPanel/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreatePost()
        {
            return View();
        }
    }
}