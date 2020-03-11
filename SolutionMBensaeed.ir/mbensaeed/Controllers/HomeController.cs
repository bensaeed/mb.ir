using HD.Commons;
using mbensaeed.Attributes;
using mbensaeed.Helper;
using mbensaeed.Models;
using mbensaeed.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
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

            
            ViewBag.SeoData = HtmlPageSEO.GetHeadPageData("وبسايت شخصی محمد بن سعيد", new robot[] { robot.index, robot.follow },
               new HtmlMetaTag[]
               {
                new HtmlMetaTag(){name = MetaName.author , content ="محمد بن سعيد"},
                new HtmlMetaTag(){name = MetaName.description , content ="وبسايت شخصی محمد بن سعيد - فناوری اطلاعات"}
               },
               null);
               //PublicDigiNotesInfo.ServerAddress + "/AboutUs");

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
            ViewBag.SeoData = HtmlPageSEO.GetHeadPageData("ارتباط با مديريت وبسايت", new robot[] { robot.noindex, robot.nofollow },
               new HtmlMetaTag[]
               {
                new HtmlMetaTag(){name = MetaName.author , content ="محمد بن سعيد"}
               },
               null);
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Contact_US(string Name, string Phone, string Email, string Message, string CaptchaText)
        {
            if (CaptchaText.ToLower() == HttpContext.Session["captchastring"].ToString().ToLower())
            {
                Session.Remove("captchastring");
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

                try
                {
                    OpratingClasses.EmailService emailService = new OpratingClasses.EmailService();
                    var strSubject = " نام و نام خانوادگی : " + NewItem.FullName;
                    var strMessage =
                        " ارتباط با مديريت وب سايت" +
                        "  <br />  " + NewItem.CommentUser +
                        "  <br />  " + " ایمیل : " + NewItem.Email +
                        "  <br />  " + " شماره همراه : " + NewItem.PhoneNumber +
                        "  <br />  " + " تاریخ و ساعت ارسال : " + NewItem.SendDate + " - " + NewItem.SendTime;

                    await emailService.SendMail(strSubject, strMessage);
                }
                catch (Exception)
                {
                }

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
        public ActionResult GetPartialPageHeroArea()
        {
            return PartialView("~/Views/PartialView/_PartialPageHeroArea.cshtml");
        }

    }
}