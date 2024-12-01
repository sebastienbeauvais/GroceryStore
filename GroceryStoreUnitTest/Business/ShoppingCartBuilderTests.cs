using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTests
{
    [TestClass]
    public class ShoppingCartBuilderTests
    {
        private Mock<IStoreInventoryDb> _mockStoreInventoryDb;
        private Mock<IShoppingCartHandler> _mockShoppingCartHandler;
        private ShoppingCartBuilder _shoppingCartBuilder;
        private List<IStoreItem> _storeInventory;
        private List<ICartItem> _cartItems;

        [TestInitialize]
        public void Setup()
        {
            _storeInventory = new List<IStoreItem>
            {
                new StoreItem { Id = 1, Name = "Apple", Price = 1.0 },
                new StoreItem { Id = 2, Name = "Banana", Price = 0.5 },
                new StoreItem { Id = 3, Name = "Carrot", Price = 0.8 }
            };

            _cartItems = new List<ICartItem>
            {
                new CartItem { Name = "Apple", Quantity = 2 },
                new CartItem { Name = "Banana", Quantity = 3 }
            };

            _mockStoreInventoryDb = new Mock<IStoreInventoryDb>();
            _mockShoppingCartHandler = new Mock<IShoppingCartHandler>();

            _mockStoreInventoryDb.Setup(db => db.Inventory).Returns(_storeInventory);
            _mockShoppingCartHandler.Setup(handler => handler.GetShoppingCartItems()).Returns(_cartItems);

            _shoppingCartBuilder = new ShoppingCartBuilder(_mockStoreInventoryDb.Object, _mockShoppingCartHandler.Object);
        }

        [TestMethod]
        public void BuildShoppingCart_ShouldReturnShoppingCartWithCorrectItemsAndTotalPrice()
        {
            var shoppingCart = _shoppingCartBuilder.BuildShoppingCart();

            Assert.AreEqual(2, shoppingCart.Items.Count());
            Assert.AreEqual("Apple", shoppingCart.Items.First().Name);
            Assert.AreEqual(2, shoppingCart.Items.First().Quantity);
            Assert.AreEqual("Banana", shoppingCart.Items.Last().Name);
            Assert.AreEqual(3, shoppingCart.Items.Last().Quantity);

            double expectedTotalPrice = (1.0 * 2) + (0.5 * 3);
            Assert.AreEqual(expectedTotalPrice, shoppingCart.TotalPrice);
        }

        [TestMethod]
        public void BuildShoppingCart_ShouldHandleEmptyCartItems()
        {
            _mockShoppingCartHandler.Setup(handler => handler.GetShoppingCartItems()).Returns(new List<ICartItem>());

            var shoppingCart = _shoppingCartBuilder.BuildShoppingCart();

            Assert.AreEqual(0, shoppingCart.Items.Count());
            Assert.AreEqual(0, shoppingCart.TotalPrice);
        }

        [TestMethod]
        public void BuildShoppingCart_ShouldIgnoreCartItemsNotInStoreInventory()
        {
            _cartItems.Add(new CartItem { Name = "NonExistentItem", Quantity = 5 });
            _mockShoppingCartHandler.Setup(handler => handler.GetShoppingCartItems()).Returns(_cartItems);

            var shoppingCart = _shoppingCartBuilder.BuildShoppingCart();

            Assert.AreEqual(3, shoppingCart.Items.Count());
            double expectedTotalPrice = (1.0 * 2) + (0.5 * 3);
            Assert.AreEqual(expectedTotalPrice, shoppingCart.TotalPrice);
        }

        [TestMethod]
        public void BuildShoppingCart_ShouldCalculateTotalPriceCorrectlyForMultipleQuantities()
        {
            _cartItems.Add(new CartItem { Name = "Carrot", Quantity = 4 });
            _mockShoppingCartHandler.Setup(handler => handler.GetShoppingCartItems()).Returns(_cartItems);

            var shoppingCart = _shoppingCartBuilder.BuildShoppingCart();

            Assert.AreEqual(3, shoppingCart.Items.Count());
            double expectedTotalPrice = (1.0 * 2) + (0.5 * 3) + (0.8 * 4);
            Assert.AreEqual(expectedTotalPrice, shoppingCart.TotalPrice);
        }
    }
}
