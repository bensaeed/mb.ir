using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mbensaeed.ViewModels
{
    public class IpInformation
    {
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "پرسش")]
        public string query { get; set; }
        [MaxLength(30, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "وضعيت")]
        public string status { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "كشور")]
        public string country { get; set; }
        [MaxLength(20, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "كد كشور")]
        public string countryCode { get; set; }
        [MaxLength(10, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "منطقه")]
        public string region { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "نام منطقه")]
        public string regionName { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "شهر")]
        public string city { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ناحیه")]
        public string district { get; set; }
        [MaxLength(80, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "zip")]
        public string zip { get; set; }
        //[ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد"]
        [Display(Name = "نقطه جغرافیایی")]
        public double lat { get; set; }
        [Display(Name = "lon")]
        public double lon { get; set; }
        [MaxLength(40, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "منطقه زماني")]
        public string timezone { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "ISP")]
        public string isp { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "Org")]
        public string org { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "as")]
        public string @as { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "برگشت خورده")]
        public string reverse { get; set; }
        [Display(Name = "موبايل")]
        public bool mobile { get; set; }
        [Display(Name = "پروکسی")]
        public bool proxy { get; set; }
    }
}