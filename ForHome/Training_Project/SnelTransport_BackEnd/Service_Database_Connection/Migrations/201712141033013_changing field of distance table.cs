namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingfieldofdistancetable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Distance_Table", "DISTANCE", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.Distance_Table", "DISTANCE", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
