using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class PostAction
    {
        public string Browser { get; set; }
        public string Device { get; set; }
        public string HostName { get; set; }
        public string IP_Address { get; set; }
        public int PostID { get; set; }
        public int ActionTypeID { get; set; }

        public string ActionTime { get; set; }
        public string DateMiladi { get; set; }
        public string DateShamsi { get; set; }
        public string MoreInfo { get; set; }
    }
}