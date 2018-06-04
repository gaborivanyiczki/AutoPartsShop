namespace CarPartsStore__License_App_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttributeValue")]
    public partial class AttributeValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AttributeValue()
        {
            ProductAttributeValue = new HashSet<ProductAttributeValue>();
        }

        public int ID { get; set; }

        public int Attribute_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string AttributeValueName { get; set; }

        [Required]
        public string AttributeValueDesc { get; set; }

        public virtual Attributes Attribute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAttributeValue> ProductAttributeValue { get; set; }
    }
}
