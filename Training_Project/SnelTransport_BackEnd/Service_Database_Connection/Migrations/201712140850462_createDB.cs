namespace Service_Database_Connection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Article",
                c => new
                    {
                        article_id = c.Int(nullable: false, identity: true),
                        article_name = c.String(nullable: false),
                        article_color = c.Int(nullable: false),
                        article_price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.article_id);
            
            CreateTable(
                "public.Customer",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        customer_name = c.String(nullable: false),
                        customer_street = c.String(nullable: false),
                        customer_housenumber = c.String(nullable: false),
                        customer_postcode = c.String(nullable: false),
                        customer_city = c.String(nullable: false),
                        customer_tel_number = c.String(nullable: false),
                        customer_fax_number = c.String(),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "public.Distance_Table",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FROM = c.String(nullable: false),
                        TO = c.String(nullable: false),
                        DISTANCE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DURATION = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "public.Order_detail",
                c => new
                    {
                        order_detail_id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        order_order_id = c.Int(nullable: false),
                        article_article_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_detail_id)
                .ForeignKey("public.Article", t => t.article_article_id, cascadeDelete: true)
                .ForeignKey("public.Orders", t => t.order_order_id, cascadeDelete: true)
                .Index(t => t.article_article_id)
                .Index(t => t.order_order_id);
            
            CreateTable(
                "public.Orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        order_date_time = c.DateTime(nullable: false),
                        order_received = c.Boolean(nullable: false),
                        order_delivered = c.Boolean(nullable: false),
                        order_type = c.Int(nullable: false),
                        customer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("public.Customer", t => t.customer_id, cascadeDelete: true)
                .Index(t => t.customer_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Order_detail", "order_order_id", "public.Orders");
            DropForeignKey("public.Orders", "customer_id", "public.Customer");
            DropForeignKey("public.Order_detail", "article_article_id", "public.Article");
            DropIndex("public.Order_detail", new[] { "order_order_id" });
            DropIndex("public.Orders", new[] { "customer_id" });
            DropIndex("public.Order_detail", new[] { "article_article_id" });
            DropTable("public.Orders");
            DropTable("public.Order_detail");
            DropTable("public.Distance_Table");
            DropTable("public.Customer");
            DropTable("public.Article");
        }
    }
}
