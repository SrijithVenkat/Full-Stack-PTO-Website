namespace FirstWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Requests");
            AddPrimaryKey("dbo.Requests", "requestId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Requests");
            AddPrimaryKey("dbo.Requests", "userID");
        }
    }
}
