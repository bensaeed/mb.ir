using mbensaeed.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using mbensaeed.ViewModels;
using mbensaeed.Helper;
using System.Threading.Tasks;
using mbensaeed.Attributes;
using mbensaeed.Repositories;
using HD.Commons;

namespace mbensaeed.Controllers
{
    [WebStatusAttribute]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly DatabaseOperation _dop = new DatabaseOperation();
        // GET: Blog
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Index(int? Page, string Tag, string Category)
        {
           
           // ViewBag.Title = "وبلاگ";
            string TitlePage = "آخرين مطالب";
            if (!(Tag == "" || Tag == null))
            {
                TitlePage = "مطالب وبلاگ مشابه به : " + Tag;
            }
            else if (!(Category == "" || Category == null))
            {
                TitlePage = "مطالب وبلاگ در دسته بندی : " + Category;
            }
            ViewBag.TitlePage = TitlePage;
               ViewBag.SeoData = HtmlPageSEO.GetHeadPageData(TitlePage, new robot[] { robot.noindex, robot.nofollow },
               new HtmlMetaTag[]
               {
                new HtmlMetaTag(){name = MetaName.author , content ="محمد بن سعيد"},
                new HtmlMetaTag(){name = MetaName.description , content ="مطالب پست شده در قالب وبلاگ وبسايت شخصی محمد بن سعيد - فناوری اطلاعات"}
               },
               null);

            PagingStatus.PageIndex = (Page ?? 1) - 1;
            var ListAllPost = await GetPost(PagingStatus.PageIndex, PagingStatus.ItemsPerPage/*, out int totalCount*/, Tag, Category);
            var result = new StaticPagedList<vm_AllPost>(ListAllPost, PagingStatus.PageIndex + 1, PagingStatus.ItemsPerPage, ListAllPost.Count());
            return View(result);
        }
        public Task<List<vm_AllPost>> GetPost(int page, int ItemsPerPage/*, out int totalCount*/, string Tag, string Category)
        {
            return Task.Run(() =>
            {
                var Result = new List<vm_AllPost>();
                Result = _dop.GetAllPost("all").ToList();
                if (!(Tag == "" || Tag == null))
                {
                    Result = Result.Where(x => x.Labels.Contains(Tag)).ToList();
                }
                else if (!(Category == "" || Category == null))
                {
                    Result = Result.Where(x => x.Category == Category).ToList();
                }

                Result = Result.Skip(page * ItemsPerPage)
                         .Take(ItemsPerPage).ToList();
                //totalCount = Result.Count();
                return Result;
            });
        }


        [HttpPost]
        public ActionResult ContentDetail()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ContentDetail(int PostID)
        {
            try
            {
                ViewBag.BeforeLiked = _dop.CheckLastActionPost(PostID, Convert.ToInt32(EnumMethod.ActionType.Like));
            }
            catch (Exception)
            {
                ViewBag.BeforeLiked = false;
            }
            ViewAndLikeLog(PostID, Convert.ToInt32(EnumMethod.ActionType.View));
            var Result = new List<vm_AllPost>();
            Result = _dop.GetAllPost("all").Where(x => x.PostID == PostID).ToList();
            using (var _Context = new ApplicationDbContext())
            {
                var _objEntityPostComment = new RepositoryPattern<PostComment>(_Context);
                var _PostComment = _objEntityPostComment.SearchFor(x=>x.PostID==PostID && x.Is_Active=="1").ToList();
                ViewBag.listPostComment = _PostComment;
            }

            ViewBag.SeoData = HtmlPageSEO.GetHeadPageData(Result.FirstOrDefault().Title, new robot[] { robot.index, robot.follow },
             new HtmlMetaTag[]
             {
                new HtmlMetaTag(){name = MetaName.author , content ="محمد بن سعيد"},
                new HtmlMetaTag(){name = MetaName.keywords , content =Result.FirstOrDefault().Labels},
                new HtmlMetaTag(){name = MetaName.description , content =""}
             },
             null);

            return View(Result);
        }
        [AjaxOnly]
        public JsonResult ViewAndLikeLog(int PostID, int ActionTypeID)
        {
            try
            {
                DatabaseOperation objEventLogger = new DatabaseOperation();
                if (ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.View))
                {
                    objEventLogger.PostLog(PostID, Convert.ToInt32(EnumMethod.ActionType.View));
                }
                else if (ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.Like))
                {
                    objEventLogger.PostLog(PostID, Convert.ToInt32(EnumMethod.ActionType.Like));
                }
                else if (ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.DisLike))
                {
                    objEventLogger.PostLog(PostID, Convert.ToInt32(EnumMethod.ActionType.DisLike));
                }
                else if (ActionTypeID == Convert.ToInt32(EnumMethod.ActionType.Downlaod))
                {
                    objEventLogger.PostLog(PostID, Convert.ToInt32(EnumMethod.ActionType.Downlaod));
                }
            }
            catch (Exception)
            {
                return Json("OK");
            }
            return Json("OK");
        }
        [AjaxOnly]
        public async Task<ActionResult> AddComment(vmComment input)
        { 
            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState)
                {
                    var errors = item.Value.Errors.ToList();
                }
                return Json("null");
            }

            if (input.CaptchaText.ToLower() == HttpContext.Session["captchastring"].ToString().ToLower())
            {
                Session.Remove("captchastring");
                NetworkOperation objNetworkOperation = new NetworkOperation();
                VisitWebsiteLog visitWebsiteLog = new VisitWebsiteLog();
                string CurrentClientIP = null;
                CurrentClientIP = objNetworkOperation.ClientIPaddress();
                IpInformation IpInfo = visitWebsiteLog.GetLocationIPINFO(CurrentClientIP);
                var _objEntityMessage = new RepositoryPattern<PostComment>(new ApplicationDbContext());
                var NewItem = new PostComment
                {
                    PostID = input.PostID,
                    FullName = input.FullName,
                    Comment = input.Comment,
                    Email = input.Email,
                    SendDate = DateConvertor.DateToNumber(DateConvertor.TodayDate()),
                    SendTime = DateConvertor.TimeNow(),
                    Browser = objNetworkOperation.ClientBrowser(),
                    DeviceInfo = objNetworkOperation.ClientDeviceType(),
                    IP_Address = CurrentClientIP,
                    HostName = objNetworkOperation.ClientHostName(),
                    country = IpInfo.country,
                    city = IpInfo.city,
                    countryCode = IpInfo.countryCode,
                    org = IpInfo.org,
                    region = IpInfo.region,
                    regionName = IpInfo.regionName,
                    status = IpInfo.status,
                    timezone = IpInfo.timezone,
                    mobile = IpInfo.mobile == true ? true :false,
                    Is_Active = "1"
                };
                _objEntityMessage.Insert(NewItem);
                _objEntityMessage.Save();
                _objEntityMessage.Dispose();
                try
                {
                    var _objEntityPost = new RepositoryPattern<Post>(new ApplicationDbContext());
                    OpratingClasses.EmailService emailService = new OpratingClasses.EmailService();
                    var strSubject = " نام و نام خانوادگی : " + NewItem.FullName;
                    var strMessage =
                        " ديدگاه كاربر راجع به پست : " + _objEntityPost.GetByPredicate(X=>X.ID==NewItem.PostID).Title.Trim() +
                        " <br /> " + NewItem.Comment +
                        " <br /> " + " ایمیل : " + NewItem.Email +
                        " <br /> " + " ساير اطلاعات : " + NewItem.DeviceInfo + " - " + NewItem.country + NewItem.city +
                        " <br /> " + " تاریخ و ساعت ارسال : " + NewItem.SendDate + " - " + NewItem.SendTime ;

                //" <br /> <p styel=\"font-family:\"Tahoma;\"\">" + NewItem.Comment +

                await emailService.SendMail(strSubject, strMessage);
                }
                catch (Exception)
                {
                }
                return PartialView("_PartialPageComment", NewItem);
            }
            else
            {
                return Json("CaptchaTextMistake");
                //ViewBag.Message = "CAPTCHA verification failed!";
            }
        }

    }
}












/* I Memory Cashe*/
//var opt = new MemoryCacheOptions();

//var AllViews = new List<string>();

//IMemoryCache mc = new MemoryCache(opt);

//if (!mc.TryGetValue("views", out AllViews))
//{

//    var lst = new List<string> { "Ali", "Mohamad" };
//    mc.Set("views", lst);
//}
//else
//{
//    AllViews.Add("2");
//}

//// if () Timer > 5min
//// insert to db
//AllViews.Clear();