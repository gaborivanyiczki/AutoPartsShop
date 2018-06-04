using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPartsStore__License_App_.Dto
{
    public class ProductAttributeDTO
    {
        public int ID { get; set; }

        public int Product_ID { get; set; }
        public virtual ProductDTO Product { get; set; }
    
        public int AttributeValue_ID { get; set; }
        public virtual AttributeValueDTO AttributeValue { get; set; }

    }
}