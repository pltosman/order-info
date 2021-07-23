using System;
using Microsoft.EntityFrameworkCore;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.DataAccess.Concrete.EntityFramework.Contexts
{
    public class OrderInfoContext :DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sse.database.windows.net;Database=SSE_Test;Persist Security Info=False;User ID=mmt-sse-test;Password=database-user-01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }


        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
