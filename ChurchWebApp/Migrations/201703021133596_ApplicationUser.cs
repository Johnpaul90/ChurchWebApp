namespace ChurchWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChurchClaims", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ChurchClaims", "ApplicationUser_Id");
            AddForeignKey("dbo.ChurchClaims", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChurchClaims", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ChurchClaims", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ChurchClaims", "ApplicationUser_Id");
        }
    }
}
