namespace TicketApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubjectAndDatePostedToMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Subject", c => c.String(nullable: false));
            AddColumn("dbo.Messages", "DatePosted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DatePosted");
            DropColumn("dbo.Messages", "Subject");
        }
    }
}
