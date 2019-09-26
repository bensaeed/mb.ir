using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string DescriptionFa { get; set; }
        public string DescriptionEn { get; set; }
        public string IsActive { get; set; }
    }
}