using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPartsStore__License_App_.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}