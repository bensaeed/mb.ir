using mbensaeed.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class WebsiteVisit : IpInformation
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ ميلادي")]
        public string DateMiladi { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ شمسی")]
        public string DateShamsi { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ساعت بازديد")]
        public string VisitTime { get; set; }
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