using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class WebsiteVisit
    {
        public int ID { get; set; }
        public string DateShamsi { get; set; }
        public string DateMiladi { get; set; }
        public string VisitTime { get; set; }
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
        public string proxy { get; set; }
        public string isp { get; set; }
        public string lon { get; set; }
    }
}