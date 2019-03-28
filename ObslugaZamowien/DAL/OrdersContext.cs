using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObslugaZamowien.DAL
{
    public class OrdersContext : DbContext
    {
        public OrdersContext() : base("DBConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Order> Orders { get; set; }
    }
}
