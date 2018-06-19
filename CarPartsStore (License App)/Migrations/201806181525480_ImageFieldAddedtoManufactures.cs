namespace CarPartsStore__License_App_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageFieldAddedtoManufactures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacture", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manufacture", "Image");
        }
    }
}
