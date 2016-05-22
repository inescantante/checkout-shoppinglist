using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShoppingList.Infrastructure.DbContext;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;

        public ShoppingListRepository(ShoppingListDbContext shoppingListDbContext)
        {
            this._shoppingListDbContext = shoppingListDbContext;
        }

        public IEnumerable<Item> GetAll()
        {
            return _shoppingListDbContext.Items;
        }

        public Item Get(int id)
        {
            return _shoppingListDbContext.Items.FirstOrDefault(x => x.Id == id);
        }

        public Item Create(Item item)
        {
            var result = _shoppingListDbContext.Items.Add(item);
            _shoppingListDbContext.SaveChanges();

            return result;
        }

        public void Delete(int id)
        {
            var entity = this.Get(id);
            _shoppingListDbContext.Entry(entity).State = EntityState.Deleted;
            _shoppingListDbContext.SaveChanges();
        }

        public void Update(Item item)
        {
            _shoppingListDbContext.Entry(item).State = EntityState.Modified;
            _shoppingListDbContext.SaveChanges();
        }
    }
}