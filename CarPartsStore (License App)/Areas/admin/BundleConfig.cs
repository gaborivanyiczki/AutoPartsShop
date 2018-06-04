using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CarPartsStore__License_App_.Areas.admin
{
    internal static class BundleConfig
    {
        internal static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap/dist/css/css").Include(
                "~/Content/bootstrap/dist/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/admin/dist/css").Include(
                    "~/Content/admin/dist/toastr.css"));

            bundles.Add(new StyleBundle("~/Content/admin/font-awesome/css/css").Include(
                "~/Content/admin/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/admin/DT/css/css").Include(
                "~/Content/admin/DT/css/dataTables.bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/admin/Ionicons/css/css").Include(
                "~/Content/admin/Ionicons/css/ionicons.min.css"));

            bundles.Add(new StyleBundle("~/Content/admin/dist/css/css").Include(
                "~/Content/admin/dist/css/AdminLTE.min.css"));

            bundles.Add(new StyleBundle("~/Content/admin/dist/css/skins/css").Include(
                "~/Content/admin/dist/css/skins/skin-blue.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.js",
                "~/Scripts/customs/Admin/dist/js/adminlte.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/toastr.js",
                "~/Scripts/bootbox.js"));
        }
    }
}