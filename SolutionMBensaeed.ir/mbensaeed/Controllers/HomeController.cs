using mbensaeed.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact_US()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact_US(string Name, string Phone, string Email, string Messag)
        {
            return View();
        }
        public CaptchaImageResult ShowCaptchaImage()
        {
            return new CaptchaImageResult();
        }
    }
}