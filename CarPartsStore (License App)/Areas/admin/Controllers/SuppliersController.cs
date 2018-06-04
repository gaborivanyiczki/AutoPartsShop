using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.Areas.admin.Controllers
{
    public class SuppliersController : Controller
    {
        private StoreDB db = new StoreDB();
        // GET: admin/Suppliers
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
        public ActionResult Create(Supplier supplier)
        {
            if(ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
    }
}