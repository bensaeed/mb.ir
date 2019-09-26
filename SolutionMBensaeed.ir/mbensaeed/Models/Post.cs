using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Post
    {
        // [ForeignKey("Image")]
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IsActive { get; set; }
        public string PostDate { get; set; }
        public string PostTime { get; set; }
        public string Labels { get; set; }

        //[ForeignKey("ImageId")]
        //public string ImageId { get; set; }
        public virtual Image Image { get; set; }

        public virtual Category Category { get; set; }
    }
}