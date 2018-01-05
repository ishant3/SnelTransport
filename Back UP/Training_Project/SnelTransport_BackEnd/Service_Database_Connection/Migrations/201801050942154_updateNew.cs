namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Article", "warehouse_location", c => c.String(nullable: false));
            AddColumn("public.Distance_Table", "Truck_Number", c => c.Int(nullable: false));
            AddColumn("public.ConfigOptimalRoute", "Truck_Number", c => c.Int(nullable: false));
            AddColumn("public.Orders", "order_status", c => c.Boolean(nullable: false));
            DropColumn("public.Orders", "order_received");
            DropColumn("public.Orders", "order_delivered");
        }
        
        public override void Down()
        {
            AddColumn("public.Orders", "order_delivered", c => c.Boolean(nullable: false));
            AddColumn("public.Orders", "order_received", c => c.Boolean(nullable: false));
            DropColumn("public.Orders", "order_status");
            DropColumn("public.ConfigOptimalRoute", "Truck_Number");
            DropColumn("public.Distance_Table", "Truck_Number");
            DropColumn("public.Article", "warehouse_location");
        }
    }
}
