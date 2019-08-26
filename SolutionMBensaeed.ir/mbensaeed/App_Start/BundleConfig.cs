using System.Web;
using System.Web.Optimization;

namespace mbensaeed
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/animate.min.css",
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/owl.theme.default.css",
                      "~/Content/css/responsive.css",
                      "~/Content/web-fonts-with-css/css/fontawesome-all.min.css",
                      "~/Content/style.css"));


                       bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/js/jquery-{version}.js",
                        "~/Scripts/js/jquery-3.3.1.min.js",
                        "~/Scripts/js/bootstrap.min.js",
                        "~/Scripts/js/counterup.min.js",
                        "~/Scripts/js/easing.min.js",
                        "~/Scripts/js/isotope.pkgd.min.js",
                        "~/Scripts/js/jquery.magnific-popup.min.js",
                        "~/Scripts/js/jquery.waypoints.min.js",
                        "~/Scripts/js/modernizr.js",
                        "~/Scripts/js/owl.carousel.min.js",
                        "~/Scripts/js/wow.min.js", 
                        "~/Scripts/persianumber.min.js",
                        "~/Scripts/js/main.js"
                        ));

        }
    }
}
