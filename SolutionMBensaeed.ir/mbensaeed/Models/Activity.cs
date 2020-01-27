using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Activity
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(8,ErrorMessage ="اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ شمسی")]
        public string DateShamsi { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ ميلادي")]
        public string DateMiladi { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ساعت فعاليت")]
        public string ActionTime { get; set; }
        [MaxLength(30, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "آی پی آدرس")]
        public string IP_Address { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "مرورگر")]
        public string Browser { get; set; }
        [MaxLength(500, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "دستگاه")]
        public string Device { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "هاست")]
        public string HostName { get; set; }
        [MaxLength(500, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "اطلاعات بيشتر")]
        public string MoreInfo { get; set; }
        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Posts { get; set; }
        public int? ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
    }
}