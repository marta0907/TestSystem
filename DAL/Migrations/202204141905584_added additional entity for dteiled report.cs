namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedadditionalentityfordteiledreport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActualAnswer = c.String(),
                        ExpectedAnswer = c.String(),
                        ResultId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Results", t => t.ResultId, cascadeDelete: true)
                .Index(t => t.ResultId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "ResultId", "dbo.Results");
            DropIndex("dbo.Reports", new[] { "ResultId" });
            DropTable("dbo.Reports");
        }
    }
}
