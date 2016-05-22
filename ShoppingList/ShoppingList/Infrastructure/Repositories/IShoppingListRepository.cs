using System.Collections.Generic;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure.Repositories
{
    public interface IShoppingListRepository
    {
        IEnumerable<Item> GetAll();
        Item Get(int id);
        Item Create(Item item);
        void Delete(int id);
        void Update(Item item);
    }
}
