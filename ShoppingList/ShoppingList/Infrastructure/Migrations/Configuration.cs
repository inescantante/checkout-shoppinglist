using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ShoppingList.Infrastructure.DbContext;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ShoppingListDbContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ShoppingListDbContext context)
        {
            //context.Items.Add(new Item { Id = 1, Name = "Pepsi", Quantity = 10});
            //context.Items.Add(new Item { Id = 2, Name = "Coke", Quantity = 10 });
            //context.Items.Add(new Item { Id = 3, Name = "Water", Quantity = 10 });
            //context.Items.Add(new Item { Id = 4, Name = "Beer", Quantity = 10 });
            //context.Items.Add(new Item { Id = 5, Name = "Cider", Quantity = 10 });
            //context.Items.Add(new Item { Id = 6, Name = "Orange Juice", Quantity = 10 });
            //context.Items.Add(new Item { Id = 7, Name = "Apple Juice", Quantity = 10 });

            //context.Consumers.Add(new Consumer {
            //    Id = 1,
            //    Name = "Checkout",
            //    Username = "checkoutConsumer",
            //    ApiKey = Guid.NewGuid().ToString(),
            //    ApiSecret = "sk_test_32b9cb39-1cd6-4f86-b750-7069a133667d" });

            //context.SaveChanges();
        }
    }
}