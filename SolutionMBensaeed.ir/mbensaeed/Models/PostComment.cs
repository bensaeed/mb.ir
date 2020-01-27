using mbensaeed.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class PostComment : IpInformation
    {
        [Key]
        public int ID { get; set; }

        public int PostID { get; set; }
        [ForeignKey("PostID")]
        public Post Post { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
        [MaxLength(120, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "پست الكترونيك")]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(5000, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ديدگاه")]
        [Required]
        public string Comment { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ ارسال")]
        public string SendDate { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ساعت ارسال")]
        public string SendTime { get; set; }
        [MaxLength(1, ErrorMessage = "اطلاعات {0} وارد شده نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "خوانده شده توسط مدير سيستم")]
        public string Is_Read { get; set; }
        [MaxLength(1, ErrorMessage = "اطلاعات {0} وارد شده نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "وضعيت نمايش")]
        public string Is_Active { get; set; }
        [MaxLength(30, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "آی پی آدرس")]
        public string IP_Address { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "مرورگر")]
        public string Browser { get; set; }
        [MaxLength(500, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "دستگاه")]
        public string DeviceInfo { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "هاست")]
        public string HostName { get; set; }
       

    }
}