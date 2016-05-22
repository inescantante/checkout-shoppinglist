using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}