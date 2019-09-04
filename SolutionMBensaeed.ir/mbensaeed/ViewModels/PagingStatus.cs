using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.ViewModels
{
    public class PagingStatus
    {
        public static int PageIndex { get; set; }
        public static int ItemsPerPage
        {
            get
            {
                return 12;
            }
        }
        public static int TotalCount { get; set; }
    }
}