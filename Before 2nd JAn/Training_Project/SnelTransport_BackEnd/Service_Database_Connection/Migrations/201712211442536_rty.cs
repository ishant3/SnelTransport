namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Article", "articleType", c => c.String(nullable: false));
            AlterColumn("public.ConfigOptimalRoute", "Starting_Address", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("public.ConfigOptimalRoute");
            AddPrimaryKey("public.ConfigOptimalRoute", "Starting_Address");
            DropColumn("public.ConfigOptimalRoute", "Id");
        }
        
        public override void Down()
        {
            AddColumn("public.ConfigOptimalRoute", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("public.ConfigOptimalRoute");
            AddPrimaryKey("public.ConfigOptimalRoute", "Id");
            AlterColumn("public.ConfigOptimalRoute", "Starting_Address", c => c.String(nullable: false));
            AlterColumn("public.Article", "articleType", c => c.String());
        }
    }
}
