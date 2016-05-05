namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSellerRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Properties", "Seller_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Properties", new[] { "Seller_Id" });
            AddColumn("dbo.Properties", "SellerUserId", c => c.String(nullable: false));
            DropColumn("dbo.Properties", "Seller_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "Seller_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Properties", "SellerUserId");
            CreateIndex("dbo.Properties", "Seller_Id");
            AddForeignKey("dbo.Properties", "Seller_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
