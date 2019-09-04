using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Posts
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IsActive { get; set; }
        public string Category { get; set; }
        public string PostDate { get; set; }
        public string PostTime { get; set; }
        public string Labels { get; set; }
        public virtual Image Image { get; set; }
    }
}