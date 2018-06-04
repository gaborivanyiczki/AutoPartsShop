using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Models;
using CarPartsStore__License_App_.Dto;

namespace CarPartsStore__License_App_.Areas.admin.Controllers
{
    public class ManufacturesController : Controller
    {
        private StoreDB db = new StoreDB();
        // GET: admin/Manufactures
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacture manufacture)
        {
            if (ModelState.IsValid)
            {
                db.Manufactures.Add(manufacture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacture);
        }
    }
}