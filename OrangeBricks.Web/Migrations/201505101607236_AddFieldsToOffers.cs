namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToOffers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Offers", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Offers", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "UpdatedAt");
            DropColumn("dbo.Offers", "CreatedAt");
            DropColumn("dbo.Offers", "Status");
        }
    }
}
