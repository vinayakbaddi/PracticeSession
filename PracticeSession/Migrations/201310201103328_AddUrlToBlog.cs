namespace PracticeSession.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlToBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Url");
        }
    }
}
