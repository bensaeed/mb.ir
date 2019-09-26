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
            return View();
        }
        [AjaxOnly]
        //public ContentResult UploadFile(HttpPostedFileBase hpf,List<vm_FileUploadInfo> vm_Info)
        public JsonResult PublishPost(string Title, int CategoryID, string Content, string IsActive, bool FlagHaveFile)
        {//, string Labels
         //try
         //{
            string NewsImageID;
            //InfoUser AppUser = new InfoUser();
            var TodayDateShamsi = DateConvertor.DateToNumber(DateConvertor.TodayDate());
            //var NewNewsCode = HelpOperation.NewsCode(Convert.ToInt32(TodayDateShamsi));
            using (var _Context = new ApplicationDbContext())
            {
                var _objEntityPost = new RepositoryPattern<Post>(_Context);
                var NewItem = new Post
                {
                    Title = Title,Image
                    //Category = CategoryID,
                    //Image = NewsImageID,
                    Content = Content,
                    IsActive = IsActive == "true" ? "1" : "0",
                    Labels = "",
                    PostDate = DateConvertor.DateToNumber(DateConvertor.TodayDate()),
                    PostTime = DateConvertor.TimeNowShort()
                    //ID_User_Reg = AppUser.ID,
                };
                _objEntityPost.Insert(NewItem);
                _objEntityPost.Save();
                _objEntityPost.Dispose();

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
                    using (var _Context = new ApplicationDbContext())
                    {
                        var _objEntityImage = new RepositoryPattern<Image>(_Context);
                        var NewItem = new Image
                        {
                            ID = GuidID,
                            TitleUrl = Title,
                            FileName = FileNameOnServer,
                            FileSize = FileSize,
                            FileUrl = FileUrl,
                            FilePathOnServer = FilePath
                        };
                        NewsImageID = GuidID;
                        _objEntityImage.Insert(NewItem);
                        _objEntityImage.Save();
                        _objEntityImage.Dispose();
                    }

                }


            }
            return Json("OK");
            //}
            //catch (Exception)
            //{
            //    return Json("Faild");
            //}
        }
    }
}