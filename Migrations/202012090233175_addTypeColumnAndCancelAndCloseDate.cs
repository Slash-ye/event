namespace Event.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTypeColumnAndCancelAndCloseDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "closedAt", c => c.DateTime());
            AddColumn("dbo.Events", "cancelAt", c => c.DateTime());
            AddColumn("dbo.UserParticipantsEvents", "type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserParticipantsEvents", "type");
            DropColumn("dbo.Events", "cancelAt");
            DropColumn("dbo.Events", "closedAt");
        }
    }
}
