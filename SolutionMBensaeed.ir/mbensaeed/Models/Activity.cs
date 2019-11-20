using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Posts { get; set; }
        public int? ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        public virtual ActivityType ActivityType { get; set; }
    }
}