using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingList.Infrastructure.DbContext;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure.Repositories
{
    public class ConsumerRepository : IConsumerRepository
    {
        public ShoppingListDbContext _shoppingListDbContext;

        public ConsumerRepository(ShoppingListDbContext shoppingListDbContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public Consumer Get(string username)
        {
            return _shoppingListDbContext.Consumers.FirstOrDefault(x => x.Username == username);
        }

        public IEnumerable<Consumer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}