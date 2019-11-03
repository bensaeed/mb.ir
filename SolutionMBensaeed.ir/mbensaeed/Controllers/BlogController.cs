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
            var ListAllPost = GetPost(PagingStatus.PageIndex, PagingStatus.ItemsPerPage, out int totalCount);
            var result = new StaticPagedList<vm_AllPost>(ListAllPost, PagingStatus.PageIndex + 1, PagingStatus.ItemsPerPage, totalCount);
            return View(result);
        }
        public IEnumerable<vm_AllPost> GetPost(int page, int ItemsPerPage, out int totalCount)
        {
            var Result = new List<vm_AllPost>();
            Result = _GetAllPost()
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
            var Result = new List<vm_AllPost>();
            Result = _GetAllPost().ToList();

            return View(Result);
        }
   
    public IEnumerable<vm_AllPost> _GetAllPost()
    {
        using (var _Context = new ApplicationDbContext())
        {
            var _objEntityPost = new RepositoryPattern<Post>(_Context);
            var _post = _objEntityPost.SearchFor(x => x.IsActive == "1").ToList();

            var _objEntityActivity = new RepositoryPattern<Activity>(_Context);
            var _activity = _objEntityActivity.GetAll();

            var _objEntityImage = new RepositoryPattern<Image>(_Context);
            var _image = _objEntityImage.GetAll();

            var Result = new List<vm_AllPost>();
            Result = (from pst in _post
                      join im in _image
                      on pst.ImageID equals im.ID
                      //join ac in _activity
                      //on pst.ID equals ac.Posts.ID into act
                      //from PstAc in act.DefaultIfEmpty()
                      select new vm_AllPost
                      {
                          PostID = pst.ID,
                          Content = pst.Content,
                          LikeCount = 1,//totalCount(ac.Posts.ID),
                          Category = "ورزش",//pst.Category.DescriptionFa,
                          Labels = pst.Labels,
                          PostDate = pst.PostDate,
                          PostTime = pst.PostTime,
                          Title = pst.Title,
                          ViewCount = 2,
                          ImageUrl = im.FileUrl.Substring(1),//_image.Single(x=>x.ID==pst.ImageID).FileUrl, //pst.Image.FileUrl,
                          IsActive = pst.IsActive
                      }
                        ).OrderByDescending(x => x.PostTime)
                        .ThenByDescending(x => x.PostDate)
                       .ToList();

            _objEntityPost.Dispose();
            _objEntityActivity.Dispose();
            _objEntityImage.Dispose();

            return Result;
        }
    }
}
}