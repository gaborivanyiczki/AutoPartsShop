using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Dto;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        private StoreDB db = new StoreDB();
        // GET: admin/Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.CarType_ID = new SelectList(db.CarType, "ID", "Name");
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "ID", "Name");
            ViewBag.Manufact_ID = new SelectList(db.Manufactures, "ID", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name", product.Category_ID);
            ViewBag.CarType_ID = new SelectList(db.CarType, "ID", "Name", product.CarType_ID);
            ViewBag.Supplier_ID = new SelectList(db.Suppliers, "ID", "Name", product.Supplier_ID);
            ViewBag.Manufact_ID = new SelectList(db.Manufactures, "ID", "Name", product.Manufact_ID);

            return View(product);

        }


    }
}