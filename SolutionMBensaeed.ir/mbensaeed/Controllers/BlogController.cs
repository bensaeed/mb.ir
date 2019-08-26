using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            ViewBag.Title = "عنوان آخرين پست";

            return View();
        }
        public ActionResult ContentDetail()
        {
            return View();
        }
    }
}