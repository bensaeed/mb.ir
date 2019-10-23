using mbensaeed.Helper;
using mbensaeed.Models;
using mbensaeed.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Areas.ControlPanel.Controllers
{
    public class BlogManageController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: ControlPanel/Blog
        public ActionResult CreatePost()
        {
            using (var _Context = new ApplicationDbContext())
            {
                var objEntityCategory = new RepositoryPattern<Category>(_Context);
                ViewBag.ListCategory  = objEntityCategory.SearchFor(x=>x.IsActive=="1").ToList();
                return View();
            }
        }


        [AjaxOnly]
        //public ContentResult UploadFile(HttpPostedFileBase hpf,List<vm_FileUploadInfo> vm_Info)
        public JsonResult PublishPost(string Title, int CategoryID, string Content, string IsActive, bool FlagHaveFile)
        {//, string Labels
            try
            {
                string NewImageID;
            //InfoUser AppUser = new InfoUser();
            var TodayDateShamsi = DateConvertor.DateToNumber(DateConvertor.TodayDate());
            //var NewNewsCode = HelpOperation.NewsCode(Convert.ToInt32(TodayDateShamsi));
                if (FlagHaveFile == true)
                {
                    HelpOperation.CreateArchiveFolderOnTheServer();
                    HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                    var FileSize = HelpOperation.ToFileSize(hpf.ContentLength);
                    var GuidID = HelpOperation.NewGuidID();
                    var FileNameOnServer = GuidID + Path.GetExtension(hpf.FileName);
                    var FilePath = @"~\MediaFiles\Image\" + FileNameOnServer;
                    var FilePathOnServer = Server.MapPath(FilePath);
                    var FileUrl = HelpOperation.MapToUrl(FilePath);
                    Request.Files[0].SaveAs(FilePathOnServer);
                    using (var _ContextImage = new ApplicationDbContext())
                    {
                        var _objEntityImage = new RepositoryPattern<Image>(_ContextImage);
                        var NewItemImage = new Image
                        {
                            ID = GuidID,
                            TitleUrl = Title,
                            FileName = FileNameOnServer,
                            FileSize = FileSize,
                            FileUrl = FileUrl,
                            FilePathOnServer = FilePath
                        };
                        NewImageID = GuidID;
                        _objEntityImage.Insert(NewItemImage);
                        _objEntityImage.Save();
                        _objEntityImage.Dispose();
                    }

                using (var _ContextPost = new ApplicationDbContext())
                {
                    var objEntityPost = new RepositoryPattern<Post>(_ContextPost);
                    var newItemPost = new Post
                    {

                        Title = Title,
                        ImageID = NewImageID,
                        CategoryID=CategoryID,
                        //Categories = new List<Category>() {  new Category() {ID = CategoryID, } },
                        Content = Content,
                        IsActive = IsActive == "true" ? "1" : "0",
                        Labels = "",
                        PostDate = DateConvertor.DateToNumber(DateConvertor.TodayDate()),
                        PostTime = DateConvertor.TimeNowShort()
                    };
                    objEntityPost.Insert(newItemPost);
                    objEntityPost.Save();
       
                    objEntityPost.Dispose();

                }

       
            }
            return Json("OK");
        }
            catch (Exception)
            {
                return Json("Faild");
    }
}

        //public void InsertManyToMany(int PostID,int CategoryID)
        //{
        //    using (var _db=new ApplicationDbContext())
        //    {
        //        Category cat = new Category { ID = CategoryID };
        //        _db.Category.Add(cat);
        //        _db.Category.Attach(cat);

        //        Post po = new Post { ID = PostID };
        //        _db.Posts.Add(po);
        //        _db.Posts.Attach(po);

        //        po.Categories.Add(cat);
        //        _db.SaveChanges();
        //    }
        //}
    }
}