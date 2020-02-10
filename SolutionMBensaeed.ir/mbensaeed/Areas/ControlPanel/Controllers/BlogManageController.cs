using mbensaeed.Helper;
using mbensaeed.Models;
using mbensaeed.Repositories;
using mbensaeed.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApp.Helpers;

namespace mbensaeed.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class BlogManageController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        // GET: ControlPanel/Blog
        public ActionResult CreatePost()
        {
            using (var _Context = new ApplicationDbContext())
            {
                var objEntityCategory = new RepositoryPattern<Category>(_Context);
                ViewBag.ListCategory = objEntityCategory.SearchFor(x => x.IsActive == "1").ToList();
                return View();
            }
        }

        [AjaxOnly]
        [ValidateInput(false)]
        //public ContentResult UploadFile(HttpPostedFileBase hpf,List<vm_FileUploadInfo> vm_Info)
        public JsonResult PublishPost(vmPublishPost input)//string Title, int CategoryID, string Content, string IsActive, bool FlagHaveFile,string Tagsinput)
        {//, string Labels
            try
            {
                string NewImageID;
                //InfoUser AppUser = new InfoUser();
                var TodayDateShamsi = DateConvertor.DateToNumber(DateConvertor.TodayDate());
                //var NewNewsCode = HelpOperation.NewsCode(Convert.ToInt32(TodayDateShamsi));
                if (input.FlagHaveFile == true)
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
                            TitleUrl = input.Title,
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
                            Title = input.Title,
                            ImageID = NewImageID,
                            CategoryID = input.CategoryID,
                            //Categories = new List<Category>() {  new Category() {ID = CategoryID, } },
                            Content = input.Content,
                            IsActive = input.IsActive == "true" ? "1" : "0",
                            Labels = input.Tagsinput,
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

        public  ActionResult CommnetDetails()
        {
            using (var _Context=new ApplicationDbContext())
            {
                var objPostCommnet = new RepositoryPattern<PostComment>(_Context);
                var AllCommnet = objPostCommnet.GetAll().OrderByDescending(x => x.SendTime).OrderByDescending(x => x.SendDate).OrderBy(x => x.Is_Read);
                return View(AllCommnet);
            }
          
        }
        [AjaxOnly]
        public JsonResult GetCommentsDetails(int id)
        {
            using (var _Context = new ApplicationDbContext())
            {
                var _objEntityComment = new RepositoryPattern<PostComment>(_Context);
                var result = _objEntityComment.GetByPredicate(x => x.ID == id);
                // _objEntityMedia.Dispose();
                return Json(Data.UnProxy(_Context, result));
            }
        }
        [AjaxOnly]
        public JsonResult ReadComment(int id)
        {
            try
            {
                using (var _Context = new ApplicationDbContext())
                {
                    var _objEntityComment = new RepositoryPattern<PostComment>(_Context);
                    var CurrentItem = _objEntityComment.GetByPredicate(x => x.ID == id);
                    if (CurrentItem != null)
                    {
                        CurrentItem.Is_Read = "1";
                        _objEntityComment.Update(CurrentItem);
                        _objEntityComment.Save();
                        _objEntityComment.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                return Json("OK");
            }
            return Json("OK");
        }
        [HttpGet]
        public ActionResult WebManagement()//(string returnUrl)
        {
            //var model = new ViewModels.LoginUser
            //{
            //    ReturnUrl = returnUrl
            //};

            //return View(model);
            return View();
        }
        [HttpPost]
        public ActionResult WebManagement(string UserName, string Password)
        {
            if (UserName == null || Password == null)
            {
                return View();
            }
            //using (var _Context = new ApplicationDbContext())
            //{
            //    HashClass _objHash = new HashClass();
            //    string strHashPassword = _objHash.CreateHash(Password);
            //    var _objEntityUser = new RepositoryPattern<TBL_Users>(_Context);
            //    var CurrUser = _objEntityUser.GetByPredicate(x => x.UserName == UserName && x.PassWord == strHashPassword && x.Is_Active == "1");
            //    if (CurrUser == null)
            //    {
            //        return View();
            //    }
            //    var ListOfUserRole = CurrUser.TBL_Roles.ToList();
            //    if (ListOfUserRole == null)
            //    {
            //        return View();
            //    }
            //    var RoleName = ListOfUserRole.FirstOrDefault(x => x.Title == "Admin" || x.Title == "SuperAdmin");// ToList();

            //    // Don't do this in production!
            //    if (CurrUser != null && RoleName != null)
            //    {
            //        var identity = new ClaimsIdentity(new[] {
            //        //new Claim(ClaimTypes.Name, "Ben"),
            //        new Claim("ID",Convert.ToString( CurrUser.ID)),
            //        new Claim("UserName", CurrUser.UserName),
            //        new Claim("FirstName", CurrUser.FirstName),
            //        new Claim("LastName",CurrUser.LastName),
            //        new Claim("HasAccess", "1")
            //        },
            //            "ApplicationCookie");

            //        var ctx = Request.GetOwinContext();
            //        var authManager = ctx.Authentication;

            //        authManager.SignIn(identity);

            //        return RedirectToAction("index", "homeadmin", new { area = "Administrator" });
            //        //return RedirectToAction(GetRedirectUrl("/"));
            //    }
            //}
            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
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