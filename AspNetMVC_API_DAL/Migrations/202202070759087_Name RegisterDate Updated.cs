namespace AspNetMVC_API_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameRegisterDateUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "RegisterDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Students", "Register");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Register", c => c.DateTime(nullable: false));
            DropColumn("dbo.Students", "RegisterDate");
        }
    }
}
