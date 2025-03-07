﻿using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        // Define DbSets for your entities here
        public DbSet<Order> Orders { get; set; }
        public DbSet<orderdata> OrderData { get; set; }
    }
}
