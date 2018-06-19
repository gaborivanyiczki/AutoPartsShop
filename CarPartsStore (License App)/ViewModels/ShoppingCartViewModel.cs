using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}