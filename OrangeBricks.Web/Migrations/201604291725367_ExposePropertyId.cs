namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExposePropertyId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "Property_Id", "dbo.Properties");
            DropIndex("dbo.Offers", new[] { "Property_Id" });
            RenameColumn(table: "dbo.Offers", name: "Property_Id", newName: "PropertyId");
            AlterColumn("dbo.Offers", "PropertyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Offers", "PropertyId");
            AddForeignKey("dbo.Offers", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Offers", new[] { "PropertyId" });
            AlterColumn("dbo.Offers", "PropertyId", c => c.Int());
            RenameColumn(table: "dbo.Offers", name: "PropertyId", newName: "Property_Id");
            CreateIndex("dbo.Offers", "Property_Id");
            AddForeignKey("dbo.Offers", "Property_Id", "dbo.Properties", "Id");
        }
    }
}
