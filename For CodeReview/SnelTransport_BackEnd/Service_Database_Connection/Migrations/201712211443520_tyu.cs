namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tyu : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "public.ConfigOptimalRoute", name: "Starting_Address", newName: "Name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "public.ConfigOptimalRoute", name: "Name", newName: "Starting_Address");
        }
    }
}
