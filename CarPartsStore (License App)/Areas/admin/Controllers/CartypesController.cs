using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.Areas.admin.Controllers
{
    public class CartypesController : Controller
    {
        private StoreDB db = new StoreDB();

        // GET: admin/Cartypes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.parent_ID = new SelectList(db.CarType, "ID", "Name");
            ViewBag.body_id = new SelectList(db.Body, "ID", "Caroserie");

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Image,parent_ID,Manufact_Year,KW,CMC,Motor_Cod,slug")] CarType carType)
        {
            if (ModelState.IsValid)
            {
                db.CarType.Add(carType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.parent_ID = new SelectList(db.CarType, "ID", "Name", carType.parent_ID);
            return View(carType);
        }


        public ActionResult Details(int? id)
        {

            return View();

        }

      
    }
}