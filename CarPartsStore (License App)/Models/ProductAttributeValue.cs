namespace CarPartsStore__License_App_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductAttributeValue")]
    public partial class ProductAttributeValue
    {
        public int ID { get; set; }

        public int? Product_ID { get; set; }

        public int? AttributeValue_ID { get; set; }

        public virtual AttributeValue AttributeValue { get; set; }

        public virtual Product Product { get; set; }
    }
}
