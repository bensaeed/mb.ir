using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mbensaeed.ViewModels
{
    public class vmComment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string CaptchaText { get; set; }
        [MaxLength(8, ErrorMessage = "اطلاعات {0} وارد شده نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "تاريخ خوانده شده شمسی")]
        public string IsRead { get; set; }
        public string Is_Active { get; set; }
    }
}