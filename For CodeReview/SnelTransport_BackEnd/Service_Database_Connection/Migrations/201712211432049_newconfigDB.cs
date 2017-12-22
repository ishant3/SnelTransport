namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newconfigDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.ConfigOptimalRoute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Starting_Address = c.String(nullable: false),
                        Maximum_Hour = c.Int(nullable: false),
                        Unload_Time = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.ConfigOptimalRoute");
        }
    }
}
