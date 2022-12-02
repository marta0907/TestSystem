namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTestEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "testPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "testPath");
        }
    }
}
