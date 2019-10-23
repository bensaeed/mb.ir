using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    //[Table("CatView")]
    public class Category
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ID { get; set; }
        public string DescriptionFa { get; set; }
        public string DescriptionEn { get; set; }
        public string IsActive { get; set; }
        //public virtual ICollection<Post> Posts { get; set; }
    }

    //class CategoryPosts
    //{
    //    public int CategoryId { get; set; }
    //    [ForeignKey("CategoryId")]
    //    public Category MyProperty { get; set; }

    //    public string Name { get; set; }
    //}
}