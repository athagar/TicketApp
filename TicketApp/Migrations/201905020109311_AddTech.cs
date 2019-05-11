namespace TicketApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTech : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Messages", "TechId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "TechId");
            AddForeignKey("dbo.Messages", "TechId", "dbo.Teches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "TechId", "dbo.Teches");
            DropIndex("dbo.Messages", new[] { "TechId" });
            DropColumn("dbo.Messages", "TechId");
            DropTable("dbo.Teches");
        }
    }
}
