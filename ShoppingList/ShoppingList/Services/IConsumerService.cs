using ShoppingList.Models;

namespace ShoppingList.Services
{
    public interface IConsumerService
    {
        Consumer Authenticate(string username, string token);
    }
}
