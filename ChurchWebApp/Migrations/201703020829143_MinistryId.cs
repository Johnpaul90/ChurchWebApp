namespace ChurchWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinistryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pastors", "Ministry_ID", "dbo.Ministries");
            DropIndex("dbo.Pastors", new[] { "Ministry_ID" });
            RenameColumn(table: "dbo.Pastors", name: "Ministry_ID", newName: "MinistryId");
            AlterColumn("dbo.Pastors", "MinistryId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Pastors", "MinistryId");
            AddForeignKey("dbo.Pastors", "MinistryId", "dbo.Ministries", "ID", cascadeDelete: true);
            DropColumn("dbo.Pastors", "MinistyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pastors", "MinistyId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Pastors", "MinistryId", "dbo.Ministries");
            DropIndex("dbo.Pastors", new[] { "MinistryId" });
            AlterColumn("dbo.Pastors", "MinistryId", c => c.Guid());
            RenameColumn(table: "dbo.Pastors", name: "MinistryId", newName: "Ministry_ID");
            CreateIndex("dbo.Pastors", "Ministry_ID");
            AddForeignKey("dbo.Pastors", "Ministry_ID", "dbo.Ministries", "ID");
        }
    }
}
