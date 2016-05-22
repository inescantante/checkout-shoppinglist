using System.Collections.Generic;
using ShoppingList.Infrastructure.Repositories;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingListService(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public IEnumerable<Item> GetList()
        {
            return _shoppingListRepository.GetAll();
        }

        public Item GetItem(int id)
        {
            return _shoppingListRepository.Get(id);
        }

        public Item CreateItem(Item item)
        {
            return _shoppingListRepository.Create(item);
        }

        public ResponseOk UpdateItem(int id, Item item)
        {
            var itemToUpdate = _shoppingListRepository.Get(id);
            itemToUpdate.Name = item.Name;
            itemToUpdate.Quantity = item.Quantity;
            _shoppingListRepository.Update(itemToUpdate);

            return new ResponseOk { Message = "Item updated" };
        }

        public ResponseOk DeleteItem(int id)
        {
            _shoppingListRepository.Delete(id);
            return new ResponseOk { Message = "Item deleted" };
        }
    }
}