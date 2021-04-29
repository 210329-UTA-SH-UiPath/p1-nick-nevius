using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Entities
{
    public class PizzaBoxDbContext : DbContext
    {
        public PizzaBoxDbContext()
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public PizzaBoxDbContext(DbContextOptionsBuilder optionsBuilder)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=tcp:pizzaboxapp-nick.database.windows.net,1433;Initial Catalog=PizzaBoxDB-Nick;User ID=dev;Password=<sekrit password>");
        }

        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // unique columns
            modelBuilder.Entity<Topping>().HasIndex(t => t.ToppingType).IsUnique();
            modelBuilder.Entity<Crust>().HasIndex(c => c.CrustType).IsUnique();
            modelBuilder.Entity<Size>().HasIndex(s => s.SizeType).IsUnique();
            modelBuilder.Entity<Store>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Name).IsUnique();

            // has/with relationships

            //modelBuilder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping);
            //modelBuilder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza);

            // if we delete a topping, delete all PizzaToppings with that topping
            modelBuilder.Entity<PizzaTopping>().HasOne(pt => pt.Topping).WithMany(t => t.PizzaToppings).OnDelete(DeleteBehavior.Cascade);

            // if we delete a pizza, delete all PizzaToppings with that pizza
            modelBuilder.Entity<PizzaTopping>().HasOne(pt => pt.Pizza).WithMany(p => p.PizzaToppings).OnDelete(DeleteBehavior.Cascade);

            // when an order is deleted, delete all pizzas associated with it
            modelBuilder.Entity<Pizza>().HasOne(p => p.Order).WithMany(o => o.Pizzas).OnDelete(DeleteBehavior.Cascade);

            // testing
            modelBuilder.Entity<Order>().HasMany(o => o.Pizzas).WithOne(p => p.Order);


            // NOT SURE IF FOLLOWING 4 WORK PROPERLY
            // if we delete a customer, delete the Orders with it
            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).OnDelete(DeleteBehavior.Cascade);

            // if we delete a store, delete the orders with it
            modelBuilder.Entity<Order>().HasOne(o => o.Store).WithMany(s => s.Orders).OnDelete(DeleteBehavior.Cascade);

            // if we delete a crust, delete the pizzas with it
            modelBuilder.Entity<Pizza>().HasOne(p => p.Crust).WithMany(c => c.Pizzas).OnDelete(DeleteBehavior.Cascade);

            // if we delete a size, delete the pizzas with it
            modelBuilder.Entity<Pizza>().HasOne(p => p.Size).WithMany(s => s.Pizzas).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


    }
}
