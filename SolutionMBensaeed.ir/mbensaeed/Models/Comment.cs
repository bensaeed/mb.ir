using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
        [MaxLength(30, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تلفن")]
        [Required]
        public string PhoneNumber { get; set; }
        [MaxLength(120, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "پست الكترونيك")]
        public string Email { get; set; }
        [MaxLength(5000, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ديدگاه")]
        [Required]
        public string CommentUser { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ ارسال")]
        public string SendDate { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ساعت ارسال")]
        public string SendTime { get; set; }
        [MaxLength(1, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "خوانده شده توسط مدير سيستم")]
        public string Is_Read { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ساعت خوانده شده")]
        public string ReadTime { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ ميلادی خوانده شده")]
        public string ReadDateMiladi { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ شمسی خوانده شده")]
        public string ReadDateShamsi { get; set; }
    }
}
