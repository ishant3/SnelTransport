namespace Back_End.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trucknumber_DIstanceTable : DbMigration
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
