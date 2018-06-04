using System.Web;
using System.Web.Optimization;

namespace CarPartsStore__License_App_
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/custom/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.12.1/jquery-ui.min.js",
                        "~/Scripts/custom/modernizr.custom.js",
                       // "~/Scripts/custom/rendro-easy-pie-chart/dist/jquery.easypiechart.min.js",
                       // "~/Scripts/custom/waypoints.min.js",
                        "~/Scripts/custom/jquery.easypiechart.min.js",
                        "~/Scripts/custom/classie.js",
                        "~/Scripts/bootstrap-4-navbar.js",
                        "~/Scripts/custom/jquery.smooth-scroll.js",
                        "~/Scripts/custom/wow.min.js",
                       // "~/Scripts/custom/switcher.js",
                        "~/Scripts/custom/owl-carousel/owl.carousel.min.js",
                        "~/Scripts/custom/bxslider/jquery.bxslider.js",
                        "~/Scripts/custom/bxslider/jquery.ui-slider.js",
                        "~/Scripts/custom/jquery.placeholder.min.js",
                        "~/Scripts/custom/theme.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/master.css",
                      "~/Scripts/jquery-ui-1.12.1/jquery-ui.css",
                      "~/Content/bootstrap-4-navbar.css",
                      "~/Content/assets/switcher/css/color2.css"));
        }
    }
}
