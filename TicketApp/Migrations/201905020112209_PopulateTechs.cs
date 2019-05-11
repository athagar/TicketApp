namespace TicketApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTechs : DbMigration
    {
        public override void Up()
        {
            
            Sql("INSERT INTO Teches ( Name) VALUES ('Bashful')");
            Sql("INSERT INTO Teches ( Name) VALUES ('Dopey')");
            Sql("INSERT INTO Teches ( Name) VALUES ('Grumpy')");
            Sql("INSERT INTO Teches ( Name) VALUES ('Happy')");
            Sql("INSERT INTO Teches ( Name) VALUES ('Sleepy')");
            Sql("INSERT INTO Teches ( Name) VALUES ('Sneezy')");
            Sql("INSERT INTO Teches ( Name) VALUES ('Doc')");
        }
        
        public override void Down()
        {
        }
    }
}
