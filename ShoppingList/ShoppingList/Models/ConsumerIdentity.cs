using System.Security.Principal;

namespace ShoppingList.Models
{
    public class ConsumerIdentity : GenericIdentity
    {
        public string ApiSecret { get; set; }

        public string UserName { get; set; }

        public int Id { get; set; }

        public ConsumerIdentity(string userName, string apiSecret)
            : base(userName)
        {
            ApiSecret = apiSecret;
            UserName = userName;
        }
    }
}