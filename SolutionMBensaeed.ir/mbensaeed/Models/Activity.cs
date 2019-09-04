using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Activity
    {
        public int ID { get; set; }
        public string DateShamsi { get; set; }
        public string DateMiladi { get; set; }
        public string ActionTime { get; set; }
        public string IP_Address { get; set; }
        public string Browser { get; set; }
        public string Device { get; set; }
        public string HostName { get; set; }
        public string MoreInfo { get; set; }
        public virtual Posts Posts { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public virtual Person Person { get; set; }

    }
}