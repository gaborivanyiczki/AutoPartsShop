using System.Web.Mvc;
using System.Web.Optimization;

namespace CarPartsStore__License_App_.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }
        private void RegisterBundles()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            RegisterBundles();

            context.MapRoute(
                "Admin",
                "admin",
                new { controller = "Admin", action = "Index" }
                );
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

          
        }
    }
}