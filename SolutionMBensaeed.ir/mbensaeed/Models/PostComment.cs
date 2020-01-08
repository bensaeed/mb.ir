using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class PostComment
    {
        [Key]
        public int ID { get; set; }

        public int PostID { get; set; }
        [ForeignKey("PostID")]
        public Post Post { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string SendDate { get; set; }
        public string SendTime { get; set; }
        public string Is_Active { get; set; }
        public string IP_Address { get; set; }
        public string Browser { get; set; }
        public string DeviceInfo { get; set; }
        public string HostName { get; set; }
        public string Country { get; set; }
        public string countryCode { get; set; }
        public string org { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string Status { get; set; }
        public string timezone { get; set; }
        public string mobile { get; set; }
    }
}