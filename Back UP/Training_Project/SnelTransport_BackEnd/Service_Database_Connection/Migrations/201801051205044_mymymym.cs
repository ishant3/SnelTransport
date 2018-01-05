namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymymym : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Distance_Table", "Truck_Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Distance_Table", "Truck_Number");
        }
    }
}
