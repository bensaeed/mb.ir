using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(200, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "توضيحات فارسی")]
        [Required]
        public string DescriptionFa { get; set; }
        [MaxLength(200, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "توضيحات لاتين")]
        public string DescriptionEn { get; set; }
        [MaxLength(1, ErrorMessage = "اطلاعات وارد شده {0} نبايد كمتر از {1} كاركتر باشد")]
        [Display(Name = "وضعيت")]
        public string IsActive { get; set; }
        //public virtual ICollection<Post> Posts { get; set; }
    }
}