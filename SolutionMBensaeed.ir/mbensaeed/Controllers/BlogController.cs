using mbensaeed.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mbensaeed.ViewModels;
using mbensaeed.Repositories;
using Microsoft.Extensions.Caching.Memory;
using mbensaeed.Helper;

namespace mbensaeed.Controllers
{
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
        public ActionResult Index(int? Page)
        {
            ViewBag.Title = "عنوان آخرين پست";
            PagingStatus.PageIndex = (Page ?? 1) - 1;
            var ListAllPost = GetPost(PagingStatus.PageIndex, PagingStatus.ItemsPerPage, out int totalCount);
            var result = new StaticPagedList<vm_AllPost>(ListAllPost, PagingStatus.PageIndex + 1, PagingStatus.ItemsPerPage, totalCount);
            return View(result);
        }
        public IEnumerable<vm_AllPost> GetPost(int page, int ItemsPerPage, out int totalCount)
        {
        




            var Result = new List<vm_AllPost>();
            Result = _dop.GetAllPost()
                     .Skip(page * ItemsPerPage)
                     .Take(ItemsPerPage).ToList();
            totalCount = Result.Count();
            return Result;
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
                // Like 2
                ViewBag.BeforeLiked = _dop.CheckLastActionPost(PostID,2);
            }
            catch (Exception)
            {

                ViewBag.BeforeLiked = false;
            }
            var Result = new List<vm_AllPost>();
            Result = _dop.GetAllPost().Where(x=>x.PostID==PostID).ToList();

            return View(Result);
        }
        [AjaxOnly]
        public JsonResult ViewAndLikeLog(string MediaID, int ActionTypeID)
        {
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


            try
            {
                DatabaseOperation objEventLogger = new DatabaseOperation();
                if (ActionTypeID == 1)
                {
                    objEventLogger.PostLog(MediaID, Convert.ToInt32(EnumMethod.ActionType.View));
                }
                else if (ActionTypeID == 2)
                {
                    objEventLogger.PostLog(MediaID, Convert.ToInt32(EnumMethod.ActionType.Like));
                }
                else if (ActionTypeID == 3)
                {
                    objEventLogger.PostLog(MediaID, Convert.ToInt32(EnumMethod.ActionType.Downlaod));
                }
                else if (ActionTypeID == 4)
                {
                    objEventLogger.PostLog(MediaID, Convert.ToInt32(EnumMethod.ActionType.DisLike));
                }
            }
            catch (Exception)
            {
                return Json("OK");
            }
            return Json("OK");
        }

    }
}