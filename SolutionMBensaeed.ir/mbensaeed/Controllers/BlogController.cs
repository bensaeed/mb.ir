using mbensaeed.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mbensaeed.ViewModels;



namespace mbensaeed.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
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
            var ListAllPost = GetAllPost(PagingStatus.PageIndex, PagingStatus.ItemsPerPage, out int totalCount);
            var result = new StaticPagedList<vm_AllPost>(ListAllPost, PagingStatus.PageIndex + 1, PagingStatus.ItemsPerPage, totalCount);
            return View();
        }
        public IEnumerable<vm_AllPost> GetAllPost(int page, int ItemsPerPage, out int totalCount)
        {

            List<Post> AllPost = _db.Posts.ToList();//.Where(x => x.IsActive == "1").ToList();

            var Result = new List<vm_AllPost>();
            //Result = (from ap in AllPost
            //          join ac in _db.Activity
            //          on ap.ImageId equals ac.
            //          join im in _db.Image
            //          on ap.Image.ID equals im.ImageId
            //          select new vm_AllPost
            //          {
            //              ImageId = ap.ID,
            //              Content = ap.Content,
            //              LikeCount = 1,
            //              Labels = ap.Labels,
            //              PostDate = ap.PostDate,
            //              PostTime = ap.PostTime,
            //              Title = ap.Title,
            //              ViewCount = 2,
            //              ImageUrl=im.FileUrl,
            //              IsActive=ap.IsActive
            //          }
            //            ).OrderByDescending(x => x.PostTime)
            //            .ThenByDescending(x => x.PostDate)
            //            .Skip(page * ItemsPerPage)
            //            .Take(ItemsPerPage).ToList();

            //_objEntityRitualInfo.Dispose();
            // _objEntityMediaCountInRitual.Dispose();
            totalCount = Result.Count();
            return Result;
                        
        }
        public ActionResult ContentDetail()
        {
            return View();
        }
    }
}