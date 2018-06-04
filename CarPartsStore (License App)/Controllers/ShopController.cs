﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.Controllers
{
    public class ShopController : Controller
    {
        private StoreDB db = new StoreDB();
      
        public ActionResult Cartype(int? id)
        {
            if( id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cartype = db.CarType.Where(c => c.CarType1.ID == id).ToList();
            

            return View(cartype);
        }

        public ActionResult Categories(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TempData["Cartype"] = id;

            var categories = db.Categories.Where(c => c.ID != 1).ToList();

            return View(categories);
        }

        public ActionResult Products(int cartype, int category)
        {
            if (cartype == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var products = db.Products.Where(c => c.CarType_ID == cartype).Where(x => x.Category_ID == category).ToList();

            if (products == null)
                return HttpNotFound();

            return View(products);
        }

        public ActionResult Universal(int category)
        {
            var products = db.Products.Include(a => a.ProductAttributeValue).Where(c => c.Category_ID == category).ToList();

            if (products == null)
                return HttpNotFound();

            return View(products);
        }

    }
}