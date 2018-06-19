using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarPartsStore__License_App_.Models
{
    public partial class ShoppingCart
    {
        StoreDB db = new StoreDB();
        private string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        //Helper to simplify cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        //Helper to add item to cart
        public void AddtoCart(Product product)
        {
            var cartItem = db.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == product.ID);

            if (cartItem == null)
            {
                cartItem = new Cart{
                    ProductId = product.ID,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                    };
                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = db.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.RecordId == id);
            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }

                db.SaveChanges();
            }

            return itemCount;
        }


        public void EmptyCart()
        {
            var cartItems = db.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }

            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(c => c.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in db.Carts
                where cartItems.CartId == ShoppingCartId
                select (int?) cartItems.Count).Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.Carts
                where cartItems.CartId == ShoppingCartId
                select (int?)cartItems.Count *
                       cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };
                orderTotal += (item.Count * item.Product.Price);

                db.OrderDetails.Add(orderDetail);
            }

            order.Total = orderTotal;

            db.SaveChanges();

            EmptyCart();

            return order.OrderId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }

            db.SaveChanges();
        }

    }
}