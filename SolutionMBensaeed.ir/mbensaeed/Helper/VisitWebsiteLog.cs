using mbensaeed.Models;
using mbensaeed.Repositories;
using mbensaeed.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace mbensaeed.Helper
{
    public class VisitWebsiteLog
    {

        public void StartOperation(string CurrentClientIP)
        {
            NetworkOperation objNetworkOperation = new NetworkOperation();
            //string CurrentClientIP = ClientIPaddress();
            IpInformation IpInfo= GetLocationIPINFO(CurrentClientIP);

            var _objEntityWebsiteVisit = new RepositoryPattern<WebsiteVisit>(new ApplicationDbContext());

            var newItem = new WebsiteVisit
            {
                VisitTime = TimeNow(),
                DateShamsi = DateConvertor.DateToNumber(DateConvertor.TodayDate()),
                DateMiladi = DateConvertor.DateToNumber(DateConvertor.TodayDateMiladi()),
                Browser = objNetworkOperation.ClientBrowser(),
                DeviceInfo = objNetworkOperation.ClientDeviceType(),
                IP_Address = CurrentClientIP,
                HostName = objNetworkOperation.ClientHostName(),
                Country = IpInfo.country,
                //asn = IpInfo.@as,
                city = IpInfo.city,
                countryCode = IpInfo.countryCode,
                isp = IpInfo.isp,
                //lat = Convert.ToString(IpInfo.lat),
                lon = Convert.ToString(IpInfo.lon),
                org = IpInfo.org,
                //query = IpInfo.query,
                region = IpInfo.region,
                regionName = IpInfo.regionName,
                Status = IpInfo.status,
                timezone = IpInfo.timezone,
                //zip = IpInfo.zip,
                //district = IpInfo.district,
                mobile = IpInfo.mobile == true ? "1" : "0",
                proxy = IpInfo.proxy == true ? "1" : "0"
                //reverse = IpInfo.reverse
            };
            _objEntityWebsiteVisit.Insert(newItem);
            _objEntityWebsiteVisit.Save();
            var cou = newItem.ID;
            _objEntityWebsiteVisit.Dispose();

        }
        public static string TimeNow()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        //public static string TodayDate()
        //{
        //    var persianDateTimeNow = DateTime.Now;
        //    return persianDateTimeNow.ToString("yyyy/MM/dd");
        //}

        public IpInformation GetLocationIPINFO(string ipaddress)
        {
            //IpInformation IpInfo = new IpInformation();
            try
            {
                string url = "http://ip-api.com/json/" + ipaddress + "?fields=status,message,country,countryCode,region,regionName,city,district,zip,lat,lon,timezone,isp,org,as,reverse,mobile,proxy,query";
                string strResponse = new WebClient().DownloadString(url);
                return JsonConvert.DeserializeObject<IpInformation>(strResponse);
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}