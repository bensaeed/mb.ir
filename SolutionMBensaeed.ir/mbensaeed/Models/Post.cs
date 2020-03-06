using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(300, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; } 
        [AllowHtml]
        [Display(Name = "محتوای پست")]
        [Required]
        public string Content { get; set; }
        [AllowHtml]
        [Display(Name = "شرح پست در سئو")]
        [Required]
        public string SeoMetaDescription { get; set; }
        [MaxLength(1, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "وضعيت")]
        public string IsActive { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ ارسال")]
        public string PostDate { get; set; }
        [MaxLength(10, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ساعت ارسال")]
        public string PostTime { get; set; }
        [MaxLength(1000, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "برچسب ها")]
        public string Labels { get; set; }

        public string ImageID { get; set; }
        [ForeignKey("ImageID")]
        public Image Image { get; set; }

        //public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

    }
}