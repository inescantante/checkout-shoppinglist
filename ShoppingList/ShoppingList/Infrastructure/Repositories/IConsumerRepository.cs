using System.Collections.Generic;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure.Repositories
{
    public interface IConsumerRepository
    {
        IEnumerable<Consumer> GetAll();
        Consumer Get(string username);
    }
}
