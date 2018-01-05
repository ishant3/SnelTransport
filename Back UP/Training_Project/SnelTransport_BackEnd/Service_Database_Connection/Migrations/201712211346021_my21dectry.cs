namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my21dectry : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Article", "articleType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("public.Article", "articleType");
        }
    }
}
