using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Service_Database_Connection
{
    public class EntitiesContext:DbContext
    {

        public EntitiesContext() : base(nameOrConnectionString: "DefaultConnectionString") { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Distance_Table> Distances { get; set; }
        public virtual DbSet<ConfigOptimalRoute> OptimalRoute_Config { get; set; }
    }
}