namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uiu : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Distance_Table", "Truck_Number");
        }
        
        public override void Down()
        {
            AddColumn("public.Distance_Table", "Truck_Number", c => c.Int(nullable: false));
        }
    }
}
