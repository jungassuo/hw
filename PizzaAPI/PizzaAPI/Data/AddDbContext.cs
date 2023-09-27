using Microsoft.EntityFrameworkCore;
using PizzaAPI.Models;
using System;

namespace PizzaAPI.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

        }

        //Implement database tables used inside API
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Size>().HasData(new Size
            {
                SizeId = 1,
                SizeName = "Small",
                SizePrice = 8
            });

            modelBuilder.Entity<Size>().HasData(new Size
            {
                SizeId = 2,
                SizeName = "Medium",
                SizePrice = 10
            });

            modelBuilder.Entity<Size>().HasData(new Size
            {
                SizeId = 3,
                SizeName = "Large",
                SizePrice = 12
            });

            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 1,
                Name = "Tomatoes",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 2,
                Name = "Broccoli",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 3,
                Name = "Red Pepper",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 4,
                Name = "Pepperoni",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 5,
                Name = "Bacon",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 6,
                Name = "Basil",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 7,
                Name = "Mushroom",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 8,
                Name = "Onion",
            });
            modelBuilder.Entity<Topping>().HasData(new Topping
            {
                Id = 9,
                Name = "Extra Cheese",
            });
        }
    }
}
