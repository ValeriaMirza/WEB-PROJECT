using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using eUseControl.DomainModels;
using System.Threading.Tasks;
using System.Text;

namespace eUseControl.DomainModels
{
    public class eUseControlDataDbContext:DbContext
    {
        
        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedCupcake> OrderedCupcakes { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public eUseControlDataDbContext() : base("name=CupcakesDatabase")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         
        }



    }

}