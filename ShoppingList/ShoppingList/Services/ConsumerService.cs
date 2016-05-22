using ShoppingList.Infrastructure.Repositories;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IConsumerRepository _consumerRepository;

        public ConsumerService(IConsumerRepository consumerRepository)
        {
            _consumerRepository = consumerRepository;
        }

        public Consumer Authenticate(string username, string token)
        {
            var consumer = _consumerRepository.Get(username);
            if (consumer != null && consumer.ApiSecret.Equals(token))
            {
                return consumer;
            }
            return null;
        }
    }
}