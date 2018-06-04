using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.Areas.admin.Controllers
{
    public class CategoriesController : Controller
    {
        private StoreDB db = new StoreDB();
        // GET: admin/Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.parent_ID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        { 
             if (ModelState.IsValid)
               {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
               }

               ViewBag.parent_ID = new SelectList(db.CarType, "ID", "Name", category.parent_ID);

               return View(category);

        }
    }
}