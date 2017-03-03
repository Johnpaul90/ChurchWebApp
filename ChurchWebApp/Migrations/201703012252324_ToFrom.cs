namespace ChurchWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToFrom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MinistrySizes", "from", c => c.Int(nullable: false));
            AddColumn("dbo.MinistrySizes", "to", c => c.Int(nullable: false));
            DropColumn("dbo.MinistrySizes", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MinistrySizes", "Size", c => c.Int(nullable: false));
            DropColumn("dbo.MinistrySizes", "to");
            DropColumn("dbo.MinistrySizes", "from");
        }
    }
}
