namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTruckNUmber_Config : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.ConfigOptimalRoute", "Truck_Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.ConfigOptimalRoute", "Truck_Number");
        }
    }
}
