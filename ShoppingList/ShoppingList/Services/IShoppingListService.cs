using System.Collections.Generic;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public interface IShoppingListService
    {
        IEnumerable<Item> GetList();
        Item GetItem(int id);
        Item CreateItem(Item item);
        ResponseOk UpdateItem(int id, Item item);
        ResponseOk DeleteItem(int id);
    }
}
