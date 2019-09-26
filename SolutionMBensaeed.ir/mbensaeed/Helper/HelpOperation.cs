using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace mbensaeed.Helper
{
    public class HelpOperation
    {

        /// <summary>
        /// ایجاد آی دی بر اساس سال هیت برای مراسم 
        /// </summary>
        /// <returns></returns>
        //public static int NewRitualID(int Year)
        //{
        //    var _objEntity = new RepositoryPattern<TBL_Ritual>(new HeyatEntities());
        //    var lst = _objEntity.GetAll().Where(x => x.ArchiveYear == Year).ToList();
        //    if (lst.Count() > 0)
        //    {
        //        return lst.Select(x => x.ID).Max() + 1;
        //    }
        //    else
        //    {
        //        return Year * 1000 + 1;
        //    }
        //}
        /// <summary>
        /// ایجاد رشته گاید بدون خط تیره
        /// </summary>
        /// <returns></returns>
        public static string NewGuidID()
        {
            return Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// ایجاد رشته گاید برای نامگذاری فایل ها بر روی سرور 
        /// </summary>
        /// <returns></returns>
        public static string NewGuidName(string ID)
        {
            return "Fatemeyoon.ir_" + ID + Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// ایجاد رشته ترکیبی برای نامگذاری فایل ها بر روی سرور 
        /// </summary>
        /// <returns></returns>
        public static string NewFileName(string RitualID, string MediaID)
        {
            // MediaID.Substring(8)
            return "mBensaeed.ir_" + RitualID.ToString() + MediaID;
        }

        /// <summary>
        /// ایجاد رشته ترکیبی برای نامگذاری فایل های خاص (مثل صفحه زمینه) بر روی سرور 
        /// </summary>
        /// <returns></returns>
        public static string NewSpecificFileName(string MediaID)
        {
            // MediaID.Substring(8)
            return "Fatemeyoon.ir_" + MediaID;
        }
        /// <summary>
        /// ایجاد آی دی بر اخبار سایت 
        /// </summary>
        /// <returns></returns>
        //public static long NewsCode(int DateNumber)
        //{
        //    var _objEntity = new RepositoryPattern<TBL_News>(new HeyatEntities());
        //    var AllNews = _objEntity.SearchFor(x => x.NewsCode / 100 == DateNumber).ToList();

        //    if (AllNews.Count() > 0)
        //    {
        //        return AllNews.Select(x => x.NewsCode).Max() + 1;
        //    }
        //    else
        //    {
        //        return DateNumber * 100 + 1;
        //    }
        //}
        /// <summary>
        /// تبدیل رشته ای از اعداد به آرایه
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns> آرایه</returns>
        public int[] GetArray(string ListID)
        {
            string[] SelectedID = ListID.Split(',');
            int[] ListofID = new int[SelectedID.Length - 1];
            for (int i = 0; i < SelectedID.Length - 1; i++)
            {
                ListofID[i] = Convert.ToInt32(SelectedID[i]);
            }
            return ListofID;
        }

        /// <summary>
        /// ایجاد فولدر بر روی سرور برای ذخیره فایل بر اساس سال 
        /// </summary>
        /// <returns></returns>
        public static bool CreateArchiveFolderOnTheServer()
        {
            //var FolderOnServer = System.Web.HttpContext.Current.Server.MapPath("~/MediaFiles/" + Convert.ToString(Year));
            var FolderOnServer = System.Web.HttpContext.Current.Server.MapPath("~/MediaFiles/" );
            if (!Directory.Exists(FolderOnServer))
            {
                Directory.CreateDirectory(FolderOnServer);
                Directory.CreateDirectory(FolderOnServer + "/" + "Audio");
                Directory.CreateDirectory(FolderOnServer + "/" + "Movie");
                Directory.CreateDirectory(FolderOnServer + "/" + "Image");
                //Directory.CreateDirectory(FolderOnServer + "/" + "Image/Gallery");
                //Directory.CreateDirectory(FolderOnServer + "/" + "Image/Cover");
                //Directory.CreateDirectory(FolderOnServer + "/" + "Image/Cover/Movie");
                //Directory.CreateDirectory(FolderOnServer + "/" + "Image/Cover/Ritual");
            }
            return true;
        }
        /// <summary>
        /// تبدیل فایل به واحد بزرگتر 
        /// </summary>
        /// <returns></returns>
        /// 
        public static string ToFileSize(long source)
        {
            const int byteConversion = 1024;
            double bytes = Convert.ToDouble(source);

            if (bytes >= Math.Pow(byteConversion, 3)) //GB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 3), 2), " GB");
            }
            else if (bytes >= Math.Pow(byteConversion, 2)) //MB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 2), 2), " MB");
            }
            else if (bytes >= byteConversion) //KB Range
            {
                return string.Concat(Math.Round(bytes / byteConversion, 2), " KB");
            }
            else //Bytes
            {
                return string.Concat(bytes, " Bytes");
            }
        }

        /// <summary>
        /// تبدیل آدرس فایل به لینک جهت نمایش در وبسایت 
        /// </summary>
        /// <returns></returns>
        /// 
        public static string MapToUrl(string FilePath)
        {
            return FilePath.Replace(HttpContext.Current.Server.MapPath("~/"), "~/").Replace(@"\", "/");
        }
        public static string MapToUrl2(string FilePath)
        {
            //string pPath = @"q:\quotewerks\images\fuji\cp6-5 cal\mvc-012f(2).jpg";
            return FilePath.Replace(@"q:\quotewerks", "~").Replace(@"\", "/");
        }
        /// <summary>
        ///  برداشتن علامت مد~ از اول رشته برای تبدیل آدرس فایل به لینک جهت نمایش در وبسایت 
        /// </summary>
        /// <returns></returns>
        /// 
        public static string RemoveFirstCharacters(string FilePath)
        {
            return FilePath.Substring(1, FilePath.Length - 1);
        }
        /// <summary>
        /// پاک کردن فایل از روی سرور به کمک آدرس 
        /// </summary>
        /// <returns></returns>
        /// 
        public static bool RemoveMediaFromServer(string FilePathOnServer)
        {

            bool flag = false;
            var FilePath = System.Web.HttpContext.Current.Server.MapPath(FilePathOnServer);
            if (System.IO.File.Exists(FilePath))
            {
                System.IO.File.Delete(FilePath);
                flag = true;
            }
            return flag;
        }
        public static string[] SplitString(string str)
        {
            return str.Split(',');
        }
    }
}