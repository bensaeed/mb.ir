using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mbensaeed.Helper
{
    public class CaptchaImageResult : ActionResult
    {
        C_NumberToString numToString = new C_NumberToString();
        public string GetCaptchaString(int length)
        {
            int intZero = '0';
            int intNine = '9';
            int intA = 'A';
            int intZ = 'Z';
            int intCount = 0;
            int intRandomNumber = 0;
            string strCaptchaString = "";

            Random random = new Random(System.DateTime.Now.Millisecond);

            while (intCount < length)
            {
                intRandomNumber = random.Next(intZero, intZ);
                if (((intRandomNumber >= intZero) && (intRandomNumber <= intNine) || (intRandomNumber >= intA) && (intRandomNumber <= intZ)))
                {
                    strCaptchaString = strCaptchaString + (char)intRandomNumber;
                    intCount = intCount + 1;
                }
            }
            return strCaptchaString;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            Bitmap bmp = new Bitmap(70, 30);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Navy);
            string randomString = GetCaptchaString(4);
            context.HttpContext.Session["captchastring"] = randomString;
            g.DrawString(randomString, new Font("Courier", 16), new SolidBrush(Color.WhiteSmoke), 2, 2);
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "image/jpeg";
            bmp.Save(response.OutputStream, ImageFormat.Jpeg);
            bmp.Dispose();
        }
        public string GetCaptchaStringNumber()
        {
            Random rnd = new Random();
            int rndNumber = rnd.Next(1000, 9999);
            return numToString.GET_Number_To_PersianString(Convert.ToString(rndNumber));
        }
    }
}