namespace DevAssign.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBMigrator : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Logs", "TestField");
        }
        
        public override void Down()
        {
        }
    }
}
