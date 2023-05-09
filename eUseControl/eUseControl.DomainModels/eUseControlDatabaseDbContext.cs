using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using eUseControl.DomainModels;

namespace eUseControl.DomainModels
{
    public class eUseControlDatabaseDbContext:DbContext
    {
        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedCupcake> OrderedCupcakes { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }

}