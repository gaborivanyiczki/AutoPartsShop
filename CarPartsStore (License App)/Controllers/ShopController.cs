using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarPartsStore__License_App_.Models;
using CarPartsStore__License_App_.ViewModels;


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

        public ActionResult Cart()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return PartialView(@"~/Views/Shared/Partials/nav/_cart.cshtml",viewModel);
        }

        public ActionResult Product(int id)
        {
            var product = db.Products.SingleOrDefault(p => p.ID == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);

        }

    }
}