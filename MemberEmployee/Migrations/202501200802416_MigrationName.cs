namespace MemberEmployee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "MemberId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "MemberId");
        }
    }
}
