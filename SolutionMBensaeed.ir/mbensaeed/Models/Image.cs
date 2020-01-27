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
        public string ID { get; set; }
        [MaxLength(60, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "نام فايل")]
        [Required]
        public string FileName { get; set; }
        [MaxLength(10, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "حجم فايل")]
        public string FileSize { get; set; }
        [MaxLength(50, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "عنوان لينك")]
        public string TitleUrl { get; set; }
        [MaxLength(1200, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "آدرس فايل")]
        [Required]
        public string FileUrl { get; set; }
        [MaxLength(1200, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = " آدرس فايل در سرور")]
        [Required]
        public string FilePathOnServer { get; set; }

    }
}