using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CarPartsStore__License_App_.Models;
using CarPartsStore__License_App_.ViewModels;

namespace CarPartsStore__License_App_.Controllers
{
    public class HomeController : Controller
    {
        private StoreDB db = new StoreDB();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetUniversalCategories()
        {
            var categories = db.Categories.Where(c => c.Category1.Name == "Universale").Take(8).ToList();
            return PartialView(@"~/Views/Shared/Partials/nav/_universal.cshtml", categories);
        }

        public ActionResult GetCartypes()
        {
            var cartypes = db.CarType.Include(c => c.CarType1).ToList();
            return PartialView(@"~/Views/Shared/Partials/nav/_cartypes.cshtml", cartypes);
        }


    }
}