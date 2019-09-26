using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Image
    {
        [Key]
        //[ForeignKey("Post")]
        public string ID { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string TitleUrl { get; set; }
        public string FileUrl { get; set; }
        public string FilePathOnServer { get; set; }

        //[ForeignKey("PostId")]
        //public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}