using mbensaeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.ViewModels
{
    public class vm_AllPost :Posts
    {
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public string ImageUrl { get; set; }

    }
}