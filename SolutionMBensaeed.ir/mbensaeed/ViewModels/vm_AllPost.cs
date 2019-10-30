using mbensaeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.ViewModels
{
    public class vm_AllPost 
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IsActive { get; set; }
        public string PostDate { get; set; }
        public string PostTime { get; set; }
        public string Labels { get; set; }
        public string Category { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public string ImageUrl { get; set; }

    }
}