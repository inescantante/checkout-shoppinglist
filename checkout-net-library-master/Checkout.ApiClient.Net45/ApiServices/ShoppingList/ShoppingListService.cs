using System;
using System.Net;
using System.Text;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;

namespace Checkout.ApiServices.ShoppingList
{
    public class ShoppingListService
    {
        private const string authHeader = "{0} {1}";

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        protected string AuthenticationHeader =>
            string.Format(authHeader, AuthenticationSchemes.Basic.ToString(), 
                Base64Encode(AppSettings.ConsumerName + ":" + AppSettings.SecretKey));

        public HttpResponse<ItemList> GetShoppingList()
        {
            return new ApiHttpClient().GetRequest<ItemList>(ApiUrls.ShoppingList, AuthenticationHeader);
        }

        public HttpResponse<Item> GetShoppingListItem(int id)
        {
            var shoppingListItemUri = string.Format(ApiUrls.ShoppingListItem, id);
            return new ApiHttpClient().GetRequest<Item>(shoppingListItemUri, AuthenticationHeader);
        }

        public HttpResponse<Item> CreateShoppingListItem(Item item)
        {
            return new ApiHttpClient().PostRequest<Item>(ApiUrls.ShoppingList, AuthenticationHeader, item);
        }

        public HttpResponse<ResponseOk> UpdateShoppingListItem(int id, Item item)
        {
            var shoppingListItemUri = string.Format(ApiUrls.ShoppingListItem, id);
            return new ApiHttpClient().PutRequest<ResponseOk>(shoppingListItemUri, AuthenticationHeader, item);
        }

        public HttpResponse<ResponseOk> DeleteShoppingListItem(int id)
        {
            var shoppingListItemUri = string.Format(ApiUrls.ShoppingListItem, id);
            return new ApiHttpClient().DeleteRequest<ResponseOk>(shoppingListItemUri, AuthenticationHeader);
        }
    }
}
