using System.Net;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture(Category = "ShoppingListApi")]
    public class ShoppingListServiceTests : BaseServiceTests
    {
        [Test]
        public void GetShoppingList()
        {
            var response = CheckoutClient.ShoppingListService.GetShoppingList();

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void CreateShoppingListItem()
        {
            var item = TestHelper.GetShoppingItem();
            var response = CheckoutClient.ShoppingListService.CreateShoppingListItem(item);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GetShoppingListItem()
        {
            var response = CheckoutClient.ShoppingListService.GetShoppingListItem(1);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void UpdateShoppingListItemQuantity()
        {
            var item = TestHelper.GetShoppingItem();
            var createdItem = CheckoutClient.ShoppingListService.CreateShoppingListItem(item).Model;
            createdItem.Quantity = TestHelper.NewQuantity(createdItem.Quantity);

            var response = CheckoutClient.ShoppingListService.UpdateShoppingListItem(createdItem.Id, createdItem);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var updated = CheckoutClient.ShoppingListService.GetShoppingListItem(createdItem.Id);

            updated.Should().NotBeNull();
            updated.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            updated.Model.Quantity.Should().NotBe(item.Quantity);
        }

        [Test]
        public void DeleteShoppingListItem()
        {
            var item = TestHelper.GetShoppingItem();
            var createdItem = CheckoutClient.ShoppingListService.CreateShoppingListItem(item).Model;

            var response = CheckoutClient.ShoppingListService.DeleteShoppingListItem(createdItem.Id);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
