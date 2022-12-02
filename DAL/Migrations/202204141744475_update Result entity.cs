namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateResultentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "Date");
        }
    }
}
