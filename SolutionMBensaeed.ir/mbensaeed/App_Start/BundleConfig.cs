using System.Web;
using System.Web.Optimization;

namespace mbensaeed
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //WebSite---------------------------- 
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/animate.min.css",
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/owl.theme.default.css",
                      "~/Content/css/responsive.css",
                      "~/Content/web-fonts-with-css/css/fontawesome-all.min.css",
                      "~/Content/css/toastr.min.css",
                      "~/Content/style.css",
                      "~/Content/Custom.css"));


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
                     "~/Scripts/js/toastr.min.js",
                     "~/Scripts/js/main.js"));
            //-------------------------------------
            //ControlPanel ------------------------
            bundles.Add(new StyleBundle("~/Content/cssCP").Include(
                    "~/Content/ControlPanel/css/colors/blue.css",
                    // "~/Content/ControlPanel/css/colors/red.css",
                    // "~/Content/ControlPanel/css/animate.css",
                    //"~/Content/ControlPanel/css/spinners.css",
                    // "~/Content/ControlPanel/scss/icons/flag-icon-css/flag-icon.min.css",
                    "~/Content/ControlPanel/scss/icons/font-awesome/css/font-awesome.min.css",
                    //"~/Content/ControlPanel/scss/icons/weather-icons/css/weather-icons.min.css",
                    //"~/Content/ControlPanel/scss/icons/linea-icons/linea.css",
                    //"~/Content/ControlPanel/scss/icons/themify-icons/themify-icons.css",
                    //"~/Content/ControlPanel/scss/icons/material-design-iconic-font/css/materialdesignicons.min.css",
                    //"~/Content/ControlPanel/scss/icons/simple-line-icons/css/simple-line-icons.css",
                    "~/Content/ControlPanel/assets/plugins/bootstrap/css/bootstrap.min.css",
                    "~/Content/ControlPanel/assets/plugins/bootstrap-select/bootstrap-select.min.css",
                    "~/Content/ControlPanel/assets/plugins/bootstrap-tagsinput/dist/bootstrap-tagsinput.css",
                    "~/Content/ControlPanel/assets/plugins/morrisjs/morris.css",
                      "~/Content/css/toastr.min.css",
                    "~/Content/ControlPanel/css/style.css",
                     "~/Content/ControlPanel/assets/plugins/summernote/dist/summernote.css"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/jsCP").Include(
                "~/Scripts/ControlPanel/assets/plugins/jquery/jquery.min.js",
                "~/Scripts/ControlPanel/assets/plugins/bootstrap/js/popper.min.js",
                "~/Scripts/ControlPanel/assets/plugins/bootstrap/js/bootstrap.min.js",
                "~/Scripts/ControlPanel/js/jquery.slimscroll.js",
                "~/Scripts/ControlPanel/js/waves.js",
                "~/Scripts/ControlPanel/js/sidebarmenu.js",
                "~/Scripts/ControlPanel/assets/plugins/sticky-kit-master/dist/sticky-kit.min.js",
                "~/Scripts/ControlPanel/js/custom.min.js",
                "~/Scripts/ControlPanel/assets/plugins/sparkline/jquery.sparkline.min.js",
                "~/Scripts/ControlPanel/assets/plugins/raphael/raphael-min.js",
                "~/Scripts/ControlPanel/assets/plugins/morrisjs/morris.min.js",
                "~/Scripts/ControlPanel/assets/plugins/summernote/dist/summernote.min.js",
                "~/Scripts/ControlPanel/js/dashboard1.js",
                "~/Scripts/CustomOperation.js",
                "~/Scripts/js/toastr.min.js", 
                "~/Scripts/bootbox.min.js",
                "~/Scripts/ControlPanel/assets/plugins/bootstrap-select/bootstrap-select.min.js",
                "~/Scripts/ControlPanel/assets/plugins/bootstrap-tagsinput/dist/bootstrap-tagsinput.min.js",
                "~/Scripts/ControlPanel/assets/plugins/styleswitcher/jQuery.style.switcher.js"));

            // "~/Scripts/ControlPanel/js/dashboard-{version}.js",
            // "~/Scripts/ControlPanel/js/chat.js",
            // "~/Scripts/ControlPanel/js/flot-data.js",
            // "~/Scripts/ControlPanel/js/footable-init.js",
            // "~/Scripts/ControlPanel/js/jasny-bootstrap.js",
            // "~/Scripts/ControlPanel/js/jquery.PrintArea.js",
            // "~/Scripts/ControlPanel/js/jsgrid-init.js",
            // "~/Scripts/ControlPanel/js/mask.js",
            // "~/Scripts/ControlPanel/js/morris-data.js",
            // "~/Scripts/ControlPanel/js/toastr.js",
            // "~/Scripts/ControlPanel/js/validation.js",
            // "~/Scripts/ControlPanel/js/widget-data.js",
            //-------------------------------
            bundles.GetHashCode();
        }
    }
}
