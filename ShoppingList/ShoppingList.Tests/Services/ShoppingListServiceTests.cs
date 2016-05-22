using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using NUnit.Framework;
using ShoppingList.Infrastructure.DbContext;
using ShoppingList.Infrastructure.Repositories;
using ShoppingList.Models;
using ShoppingList.Services;
using ShoppingList.Tests.TestHelpers;

namespace ShoppingList.Tests.Services
{
    [TestFixture]
    public class ShoppingListServiceTests
    {
        private IShoppingListService _shoppingListService;
        private IShoppingListRepository _shoppingListRepository;
        private List<Item> _shoppingListItems;

        [SetUp]
        public void Setup()
        {
            _shoppingListItems = TestHelper.GetAllItems();
            var data = _shoppingListItems.AsQueryable();
            var mockSet = new Mock<DbSet<Item>>();
            mockSet.Setup(m => m.AddRange(data));
            mockSet.As<IQueryable<Item>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Item>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShoppingListDbContext>();
            mockContext.Setup(c => c.Items).Returns(mockSet.Object);
            _shoppingListRepository = new ShoppingListRepository(mockContext.Object);
            _shoppingListService = new ShoppingListService(_shoppingListRepository);
        }
        
        [Test]
        public void GetAllItems()
        {
            var items = _shoppingListService.GetList();

            Assert.IsNotNull(items);
            Assert.AreEqual(5, items.Count());
        }

        [Test]
        public void GetItemById()
        {
            var id = _shoppingListItems.First().Id;
            var item = _shoppingListService.GetItem(id);

            Assert.IsNotNull(item);
            Assert.AreEqual(_shoppingListItems.First().Name, item.Name);
            Assert.AreEqual(_shoppingListItems.First().Quantity, item.Quantity);
        }

        [TearDown]
        public void DisposeAllObjects()
        {
            _shoppingListItems = null;
            _shoppingListService = null;
            _shoppingListRepository = null;
        }
    }

}
