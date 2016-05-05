namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "PropertyType", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "StreetName", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Properties", "NumberOfBedrooms", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "Seller_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Properties", "Seller_Id");
            AddForeignKey("dbo.Properties", "Seller_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "Seller_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Properties", new[] { "Seller_Id" });
            DropColumn("dbo.Properties", "Seller_Id");
            DropColumn("dbo.Properties", "NumberOfBedrooms");
            DropColumn("dbo.Properties", "Description");
            DropColumn("dbo.Properties", "StreetName");
            DropColumn("dbo.Properties", "PropertyType");
        }
    }
}
