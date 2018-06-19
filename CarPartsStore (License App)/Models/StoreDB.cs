namespace CarPartsStore__License_App_.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreDB : DbContext
    {
        public StoreDB()
            : base("name=StoreDB")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Attributes> Attributes { get; set; }
        public virtual DbSet<AttributeValue> AttributeValues { get; set; }
        public virtual DbSet<Body> Body { get; set; }
        public virtual DbSet<CarType> CarType { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attributes>()
                .HasMany(e => e.AttributeValue)
                .WithRequired(e => e.Attribute)
                .HasForeignKey(e => e.Attribute_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AttributeValue>()
                .HasMany(e => e.ProductAttributeValue)
                .WithOptional(e => e.AttributeValue)
                .HasForeignKey(e => e.AttributeValue_ID);

            modelBuilder.Entity<Body>()
                .HasMany(e => e.CarType)
                .WithOptional(e => e.Body)
                .HasForeignKey(e => e.body_id);

            modelBuilder.Entity<CarType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CarType>()
                .Property(e => e.Manufact_Year)
                .IsFixedLength();

            modelBuilder.Entity<CarType>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<CarType>()
                .HasMany(e => e.CarTypes)
                .WithOptional(e => e.CarType1)
                .HasForeignKey(e => e.parent_ID);

            modelBuilder.Entity<CarType>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.CarType)
                .HasForeignKey(e => e.CarType_ID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.parent_ID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manufacture>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Manufacture)
                .HasForeignKey(e => e.Manufact_ID);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price_Sale)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Units)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductAttributeValue)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_ID);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.Supplier_ID);
        }
    }
}
