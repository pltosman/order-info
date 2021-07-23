using System;
using Microsoft.EntityFrameworkCore;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.DataAccess.Concrete.EntityFramework.Contexts
{
    public class OrderInfoContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("--");
        }


        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
