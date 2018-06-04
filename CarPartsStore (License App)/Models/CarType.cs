namespace CarPartsStore__License_App_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarType")]
    public partial class CarType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarType()
        {
            CarTypes = new HashSet<CarType>();
            Product = new HashSet<Product>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public int? parent_ID { get; set; }

        [StringLength(10)]
        public string Manufact_Year { get; set; }

        public int? KW { get; set; }

        public int? CMC { get; set; }

        [StringLength(50)]
        public string Motor_Cod { get; set; }

        public int? body_id { get; set; }

        [StringLength(50)]
        public string slug { get; set; }

        public virtual Body Body { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarType> CarTypes { get; set; }

        public virtual CarType CarType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
