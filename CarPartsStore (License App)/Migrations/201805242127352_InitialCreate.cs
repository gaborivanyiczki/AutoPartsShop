namespace CarPartsStore__License_App_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
             CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
                 CreateTable(
                "dbo.Attribute",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AttributeValue",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Attribute_ID = c.Int(nullable: false),
                        AttributeValueName = c.String(nullable: false, maxLength: 50),
                        AttributeValueDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Attribute", t => t.Attribute_ID)
                .Index(t => t.Attribute_ID);
            
            CreateTable(
                "dbo.ProductAttributeValue",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Product_ID = c.Int(),
                        AttributeValue_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .ForeignKey("dbo.AttributeValue", t => t.AttributeValue_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.AttributeValue_ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Manufact_Code = c.String(maxLength: 50),
                        Category_ID = c.Int(nullable: false),
                        CarType_ID = c.Int(),
                        Supplier_ID = c.Int(),
                        Manufact_ID = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 5, scale: 2),
                        Price_Sale = c.Decimal(precision: 5, scale: 2),
                        Image = c.String(maxLength: 50),
                        Description = c.String(),
                        Available = c.Boolean(nullable: false),
                        OnStock = c.Int(nullable: false),
                        Units = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarType", t => t.CarType_ID)
                .ForeignKey("dbo.Category", t => t.Category_ID)
                .ForeignKey("dbo.Manufacture", t => t.Manufact_ID)
                .ForeignKey("dbo.Supplier", t => t.Supplier_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.CarType_ID)
                .Index(t => t.Supplier_ID)
                .Index(t => t.Manufact_ID);
            
            CreateTable(
                "dbo.CarType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Image = c.String(maxLength: 50),
                        parent_ID = c.Int(),
                        Manufact_Year = c.String(maxLength: 10, fixedLength: true),
                        KW = c.Int(),
                        CMC = c.Int(),
                        Motor_Cod = c.String(maxLength: 50),
                        body_id = c.Int(),
                        slug = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Body", t => t.body_id)
                .ForeignKey("dbo.CarType", t => t.parent_ID)
                .Index(t => t.parent_ID)
                .Index(t => t.body_id);
            
            CreateTable(
                "dbo.Body",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Caroserie = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                        parent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.parent_ID)
                .Index(t => t.parent_ID);
            
            CreateTable(
                "dbo.Manufacture",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CUI = c.String(maxLength: 50),
                        Adress = c.String(nullable: false),
                        Telephone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.__RefactorLog",
                c => new
                    {
                        OperationKey = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OperationKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropForeignKey("dbo.AttributeValue", "Attribute_ID", "dbo.Attribute");
            DropForeignKey("dbo.ProductAttributeValue", "AttributeValue_ID", "dbo.AttributeValue");
            DropForeignKey("dbo.Product", "Supplier_ID", "dbo.Supplier");
            DropForeignKey("dbo.ProductAttributeValue", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.Product", "Manufact_ID", "dbo.Manufacture");
            DropForeignKey("dbo.Product", "Category_ID", "dbo.Category");
            DropForeignKey("dbo.Category", "parent_ID", "dbo.Category");
            DropForeignKey("dbo.Product", "CarType_ID", "dbo.CarType");
            DropForeignKey("dbo.CarType", "parent_ID", "dbo.CarType");
            DropForeignKey("dbo.CarType", "body_id", "dbo.Body");
            DropIndex("dbo.Category", new[] { "parent_ID" });
            DropIndex("dbo.CarType", new[] { "body_id" });
            DropIndex("dbo.CarType", new[] { "parent_ID" });
            DropIndex("dbo.Product", new[] { "Manufact_ID" });
            DropIndex("dbo.Product", new[] { "Supplier_ID" });
            DropIndex("dbo.Product", new[] { "CarType_ID" });
            DropIndex("dbo.Product", new[] { "Category_ID" });
            DropIndex("dbo.ProductAttributeValue", new[] { "AttributeValue_ID" });
            DropIndex("dbo.ProductAttributeValue", new[] { "Product_ID" });
            DropIndex("dbo.AttributeValue", new[] { "Attribute_ID" });
            DropTable("dbo.__RefactorLog");
            DropTable("dbo.Supplier");
            DropTable("dbo.Manufacture");
            DropTable("dbo.Category");
            DropTable("dbo.Body");
            DropTable("dbo.CarType");
            DropTable("dbo.Product");
            DropTable("dbo.ProductAttributeValue");
            DropTable("dbo.AttributeValue");
            DropTable("dbo.Attribute");
        }
    }
}
