using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPartsStore__License_App_.Dto
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manufact_Code { get; set; }
        public int Category_ID { get; set; }
        public virtual CategoriesDTO Category { get; set; }
        public int? CarType_ID { get; set; }
        public virtual CarTypeDTO CarType { get; set; }
        public int? Supplier_ID { get; set; }
        public virtual SuppliersDTO Supplier { get; set; }
        public int? Manufact_ID { get; set; }
        public virtual ManufactureDTO Manufacture { get; set; }
        public decimal Price { get; set; }
        public decimal? Price_Sale { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool? Available { get; set; }
        public int? OnStock { get; set; }
        public string Units { get; set; }

    }
}