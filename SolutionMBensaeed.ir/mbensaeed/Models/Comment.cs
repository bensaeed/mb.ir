using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CommentUser { get; set; }
        public string SendDate { get; set; }
        public string SendTime { get; set; }
        public string Is_Read { get; set; }
        public string ReadTime { get; set; }
        public string ReadDateMiladi { get; set; }
        public string ReadDateShamsi { get; set; }
    }
}
