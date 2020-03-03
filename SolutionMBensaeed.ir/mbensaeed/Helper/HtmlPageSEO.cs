using System;
using System.Collections.Generic;
using System.Text;

namespace HD.Commons
{
    public static class HtmlPageSEO
    {
        public static string GetHeadPageData(string title, robot[] robots, HtmlMetaTag[] metaTags, string canonical)
        {
            StringBuilder sb = new StringBuilder();

            if (!String.IsNullOrEmpty(title))
            {
                sb.Append("<title>" + title + "</title>\n");
            }


            if (robots != null)
            {
                if (robots.Length > 0)
                {
                    sb.Append("<meta name=\"robots\" content=\"");

                    for (int i = 0; i < robots.Length; i++)
                    {
                        sb.Append(robots[i]);

                        if (i < (robots.Length - 1))
                        {
                            sb.Append(",");
                        }
                    }

                    sb.Append("\"/>\n");
                }
            }


            if (metaTags != null)
            {
                if (metaTags.Length > 0)
                {
                    foreach (var item in metaTags)
                    {
                        sb.Append("<meta name=\"" + item.name + "\" content=\"" + item.content + "\">\n");
                    }
                }
            }


            if (!String.IsNullOrEmpty(canonical))
            {
                sb.Append("<link rel=\"canonical\" href=\"" + canonical + "\" />\n");
            }

            return sb.ToString();
        }
    }


    public class HtmlMetaTag
    {
        public MetaName name { get; set; }
        public string content { get; set; }
    }


    public enum MetaName
    {
        author,
        description,
        generator,
        keywords,
        copyright,
        viewport
    }

    public enum robot
    {
        index,
        noindex,
        follow,
        nofollow,
        noimageindex
    }
}
