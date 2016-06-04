namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renamefield : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Attendances", name: "Gig_Id", newName: "GigId");
            RenameIndex(table: "dbo.Attendances", name: "IX_Gig_Id", newName: "IX_GigId");
            DropPrimaryKey("dbo.Attendances");
            AddPrimaryKey("dbo.Attendances", new[] { "GigId", "AttendeeId" });
            DropColumn("dbo.Attendances", "GiggId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "GiggId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Attendances");
            AddPrimaryKey("dbo.Attendances", new[] { "GiggId", "AttendeeId" });
            RenameIndex(table: "dbo.Attendances", name: "IX_GigId", newName: "IX_Gig_Id");
            RenameColumn(table: "dbo.Attendances", name: "GigId", newName: "Gig_Id");
        }
    }
}
