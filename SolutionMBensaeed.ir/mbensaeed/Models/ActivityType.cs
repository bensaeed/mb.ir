using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class ActivityType
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; }
        [MaxLength(100, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "توضيحات")]
        public string Description { get; set; }
    }
}