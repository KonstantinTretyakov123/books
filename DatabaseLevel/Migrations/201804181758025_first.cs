namespace DatabaseLevel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Genre", c => c.String());
            AddColumn("dbo.Books", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Type");
            DropColumn("dbo.Books", "Genre");
        }
    }
}
