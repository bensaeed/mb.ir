using mbensaeed.Helper;
using mbensaeed.Models;
using mbensaeed.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public ActionResult Contact_US(string Name, string Phone, string Email, string Message)
        {
            var _objEntityMessage = new RepositoryPattern<Comment>(new ApplicationDbContext());
            var NewItem = new Comment
            {
                FullName = Name,
                PhoneNumber = Phone,
                Email = Email,
                CommentUser = Message,
                SendDate = DateConvertor.DateToNumber(DateConvertor.TodayDate()),
                SendTime = DateConvertor.TimeNow()
            };
            _objEntityMessage.Insert(NewItem);
            _objEntityMessage.Save();
            _objEntityMessage.Dispose();
            return Json("OK");
            //return View();
        }
        public CaptchaImageResult ShowCaptchaImage()
        {
            return new CaptchaImageResult();
        }
        public ActionResult Updating()
        {
            var State = ConfigurationManager.AppSettings["ActiveWebSite"];
            if (State == "False")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}