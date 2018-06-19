namespace CarPartsStore__License_App_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductAttributeValue = new HashSet<ProductAttributeValue>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        public string Manufact_Code { get; set; }

        public int Category_ID { get; set; }

        public int? CarType_ID { get; set; }

        public int? Supplier_ID { get; set; }

        public int? Manufact_ID { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        public decimal? Price_Sale { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public int OnStock { get; set; }

        [Required]
        [StringLength(50)]
        public string Units { get; set; }

        public virtual CarType CarType { get; set; }

        public virtual Category Category { get; set; }

        public virtual Manufacture Manufacture { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAttributeValue> ProductAttributeValue { get; set; }
    }
}
