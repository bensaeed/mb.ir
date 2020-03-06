using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.ViewModels
{
    public class vmPublishPost
    {
        public int PostID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string IsActive { get; set; }
        public bool FlagHaveFile { get; set; }
        public string Tagsinput { get; set; }
        public string SeoMetaDescription { get; set; }
    }
}