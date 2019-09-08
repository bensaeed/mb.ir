using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.Helper
{
    public class NetworkOperation
    {

        public string ClientIPaddress()
        {
            //var ip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(0).ToString();
            string ipAddress = "";
            ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ipAddress;
        }
        public string ClientDeviceType()
        {
            string DeviceType = "";
            DeviceType = HttpContext.Current.Request.UserAgent;
            if (string.IsNullOrEmpty(DeviceType))
            {
                DeviceType = "";
            }
            return DeviceType;
        }
        public string ClientBrowser()
        {
            string BrowserName = "";
            HttpRequest req = HttpContext.Current.Request;
            BrowserName = req.Browser.Browser;
            if (string.IsNullOrEmpty(BrowserName))
            {
                BrowserName = "";
            }
            return BrowserName;
        }
        public string ClientHostName()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            if (string.IsNullOrEmpty(strHostName))
            {
                strHostName = "";
            }
            return strHostName;
        }
    }
}