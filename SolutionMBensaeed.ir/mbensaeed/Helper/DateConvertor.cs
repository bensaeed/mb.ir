using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mbensaeed.Helper
{
    public class DateConvertor
    {

        public List<int> Years()
        {
            int[] Year = new int[21];
            int cnt = 0;
            for (int i = 1390; i <= 1410; i++)
            {
                Year[cnt] = i;
                cnt++;
            }
            return Year.ToList();
        }
        public List<string> Months()
        {
            string[] Month = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            return Month.ToList();
        }
        public List<int> Days()
        {
            int[] Day = new int[31];

            for (int i = 1; i <= 31; i++)
            {
                Day[i - 1] = i;
            }
            return Day.ToList();
        }
        public static string TodayDate()
        {
            var persianDateTimeNow = PersianDateTime.Now;
            //persianDateTimeNow.EnglishNumber = true;
            return persianDateTimeNow.ToString("yyyy/MM/dd");
        }
        public static string nDaysAgo(double n)
        {
            if (n != 0)
            {
                var persianDateTimeNow = PersianDateTime.Now.AddDays(n);
                return persianDateTimeNow.ToString("yyyy/MM/dd");
            }
            else
            {
                var persianDateTimeNow = PersianDateTime.Now;
                //persianDateTimeNow.EnglishNumber = true;
                return persianDateTimeNow.ToString("yyyy/MM/dd");
            }
        }
        public static string TodayDateMiladi()
        {
            var persianDateTimeNow = DateTime.Now;
            //persianDateTimeNow.EnglishNumber = true;
            return persianDateTimeNow.ToString("yyyy/MM/dd");
        }
        public static DateTime TimeNowFull()
        {
            return DateTime.Now;
        }
        public static string TimeNow()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        public static string TimeNowShort()
        {
            return DateTime.Now.ToString("HH:mm");
        }
        public static string TimeNowLong()
        {
            return DateTime.Now.ToLongTimeString();
        }
        public static DateTime AddMinutsTimeNowShort()
        {
            return DateTime.Now.AddMinutes(2);
        }
        public static string ConcatDateToNumber(string y, string m, string d)
        {
            if (m.Length == 1) { m = "0" + m; }
            if (d.Length == 1) { d = "0" + d; }
            return y + m + d;
        }
        public static string DateToNumber(string strDate)
        {
            strDate = strDate.Trim();
            if ((strDate == "" && strDate == null) || (strDate.Length != 10))
                return "";
            return strDate.Replace("/", "");
        }
        public static string NumberToDate(string strDate)
        {

            string strResultPart1 = "", strResultPart2 = "", strResultPart3 = "";
            if ((strDate == "") || (strDate == null) || (strDate.Length != 8))
            {
                return "";
            }
            else
            {
                strDate = strDate.Trim();
                strResultPart1 = strDate.Substring(0, 4) + "/";
                strResultPart2 = strDate.Substring(4, 2) + "/";
                strResultPart3 = strDate.Substring(6, 2);
                return strResultPart1 + strResultPart2 + strResultPart3;
            }
        }
        /// <summary>
        /// یک استرینگ تاریخ شمسی را به معادل میلادی تبدیل میکند
        /// </summary>
        /// <param name="persianDate">تاریخ شمسی</param>
        /// <returns>تاریخ میلادی</returns>
        public static DateTime ToGeorgianDateTime(string persianDate)
        {
            int year = Convert.ToInt32(persianDate.Substring(0, 4));
            int month = Convert.ToInt32(persianDate.Substring(5, 2));
            int day = Convert.ToInt32(persianDate.Substring(8, 2));
            DateTime georgianDateTime = new DateTime(year, month, day, new System.Globalization.PersianCalendar());
            return georgianDateTime;
        }
        public static DateTime NumberToGeorgianDateTime(string year, string month, string day)
        {
            DateTime georgianDateTime = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), new System.Globalization.PersianCalendar());
            return georgianDateTime;
        }
        public static string NumberToGeorgianDateTimeJustDate(string year, string month, string day)
        {
            DateTime georgianDateTime = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day), new System.Globalization.PersianCalendar());
            return ConcatDateToNumber(georgianDateTime.Year.ToString(), georgianDateTime.Month.ToString(), georgianDateTime.Day.ToString());
        }
        /// <summary>
        /// یک تاریخ میلادی را به معادل فارسی آن تبدیل میکند
        /// </summary>
        /// <param name="georgianDate">تاریخ میلادی</param>
        /// <returns>تاریخ شمسی</returns>
        public static string ToPersianDateString(DateTime georgianDate)
        {
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

            string year = persianCalendar.GetYear(georgianDate).ToString();
            string month = persianCalendar.GetMonth(georgianDate).ToString().PadLeft(2, '0');
            string day = persianCalendar.GetDayOfMonth(georgianDate).ToString().PadLeft(2, '0');
            string persianDateString = string.Format("{0}/{1}/{2}", year, month, day);
            return persianDateString;
        }

        ///// <summary>
        ///// یک تعداد روز را از یک تاریخ شمسی کم میکند یا به آن آضافه میکند
        ///// </summary>
        ///// <param name="georgianDate">تاریخ شمسی اول</param>
        ///// <param name="days">تعداد روزی که میخواهیم اضافه یا کم کنیم</param>
        ///// <returns>تاریخ شمسی به اضافه تعداد روز</returns>
        //public static string AddDaysToShamsiDate(this string persianDate, int days)
        //{
        //    DateTime dt = persianDate.ToGeorgianDateTime();
        //    dt = dt.AddDays(days);
        //    return dt.ToPersianDateString();
        //}
    }
}