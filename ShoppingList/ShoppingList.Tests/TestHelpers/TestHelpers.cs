using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.Models;

namespace ShoppingList.Tests.TestHelpers
{
    public class TestHelper
    {
        public static List<Item> GetAllItems()
        {
            var items = new List<Item>
            {
                new Item() {Id = 1, Name = "Pepsi", Quantity = 10},
                new Item() {Id = 2, Name = "Coke", Quantity = 10},
                new Item() {Id = 3, Name = "Water", Quantity = 10},
                new Item() {Id = 4, Name = "Beer", Quantity = 10},
                new Item() {Id = 5, Name = "Cider", Quantity = 10}
            };

            return items;
        }

        public static Item GetNewItem()
        {
            return new Item()
            {
                Id = 6,
                Name = "Juice",
                Quantity = 10
            };
        }
    }
}
