using mbensaeed.Attributes;
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
  

    [WebStatusAttribute]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //throw new System.Exception("hhhh");
            return View();
        }
        [HttpPost]
        public ActionResult Index(string SectionID)
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
        public ActionResult Contact_US(string Name, string Phone, string Email, string Message, string CaptchaText)
        {
            if (CaptchaText.ToLower() == HttpContext.Session["captchastring"].ToString().ToLower())
            {
                var _objEntityMessage = new RepositoryPattern<Comment>(new ApplicationDbContext());
                var NewItem = new Comment
                {
                    FullName = Name,
                    PhoneNumber = Phone,
                    Email = Email, 
                    CommentUser = Message,
                    SendDate = DateConvertor.DateToNumber(DateConvertor.TodayDate()),
                    SendTime = DateConvertor.TimeNow(),
                    Is_Read = "0"
                };
                _objEntityMessage.Insert(NewItem);
                _objEntityMessage.Save();
                _objEntityMessage.Dispose();
                return Json("OK");
            }
            else
            {
                return Json("CaptchaTextMistake");
                //ViewBag.Message = "CAPTCHA verification failed!";
            }


        }
        public CaptchaImageResult ShowCaptchaImage()
        {
            return new CaptchaImageResult();
        }
        public ActionResult Updating()
        {
            var State = ConfigurationManager.AppSettings["ActiveWebSite"];
            if (State == "False" || State == "false")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult Nothing()
        {
            return View();
        }
  
    }
}