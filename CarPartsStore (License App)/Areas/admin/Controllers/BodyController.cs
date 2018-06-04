using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Models;
namespace CarPartsStore__License_App_.Areas.admin.Controllers
{
    public class BodyController : Controller
    {
        private StoreDB db = new StoreDB();
        // GET: admin/Body
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Body body)
        {
            if (ModelState.IsValid)
            {
                db.Body.Add(body);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(body);

        }
    }
}