using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CarPartsStore__License_App_.Models;
using CarPartsStore__License_App_.ViewModels;

namespace CarPartsStore__License_App_.Controllers
{
    public class ShoppingCartController : Controller
    {
        private StoreDB db = new StoreDB();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        public void AddtoCart(int id)
        {
            var product = db.Products.Single(p => p.ID == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddtoCart(product);

        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            string ProductName = db.Carts.Single(r => r.RecordId == id).Product.Name;

            int itemCount = cart.RemoveFromCart(id);

            var result = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(ProductName) +
                          " a fost sters din cos",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            
            };

            return Json(result);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
 
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }


    }
}