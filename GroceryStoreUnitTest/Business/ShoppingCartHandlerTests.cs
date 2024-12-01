using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace BusinessTests
{
    [TestClass]
    public class ShoppingCartHandlerTests
    {
        private ShoppingCartHandler _shoppingCartHandler;
        private Mock<IStoreInventoryDb> _mockStoreInventoryDb;
        private List<IStoreItem> _storeInventory;

        [TestInitialize]
        public void Setup()
        {
            _storeInventory = new List<IStoreItem>
            {
                new StoreItem { Id = 1, Name = "Apple", Price = 1.0 },
                new StoreItem { Id = 2, Name = "Banana", Price = 0.5 },
                new StoreItem { Id = 3, Name = "Carrot", Price = 0.8 }
            };

            _mockStoreInventoryDb = new Mock<IStoreInventoryDb>();
            _mockStoreInventoryDb.Setup(db => db.Inventory).Returns(_storeInventory);

            _shoppingCartHandler = new ShoppingCartHandler(_mockStoreInventoryDb.Object);
        }

        [TestMethod]
        public void AddItemToShoppingCart_ShouldAddNewItem_WhenItemIsNotAlreadyInCart()
        {
            var input = "1"; // ID of "Apple"
            using (var sw = new StringWriter())
            using (var sr = new StringReader(input))
            {
                Console.SetOut(sw);
                Console.SetIn(sr);

                _shoppingCartHandler.AddItemToShoppingCart();

                var cartItems = _shoppingCartHandler.GetShoppingCartItems();
                Assert.AreEqual(1, cartItems.Count);
                Assert.AreEqual("Apple", cartItems[0].Name);
                Assert.AreEqual(1, cartItems[0].Quantity);
            }
        }

        [TestMethod]
        public void AddItemToShoppingCart_ShouldIncreaseQuantity_WhenItemIsAlreadyInCart()
        {
            var input = "1"; // ID of "Apple"
            using (var sw = new StringWriter())
            using (var sr = new StringReader($"{input}\n{input}")) // Add "Apple" twice
            {
                Console.SetOut(sw);
                Console.SetIn(sr);

                _shoppingCartHandler.AddItemToShoppingCart();
                _shoppingCartHandler.AddItemToShoppingCart();

                // Assert
                var cartItems = _shoppingCartHandler.GetShoppingCartItems();
                Assert.AreEqual(1, cartItems.Count);
                Assert.AreEqual("Apple", cartItems[0].Name);
                Assert.AreEqual(2, cartItems[0].Quantity);
            }
        }

        [TestMethod]
        public void AddItemToShoppingCart_ShouldNotAddItem_WhenItemIdDoesNotExistInInventory()
        {
            var input = "99"; // Invalid ID
            using (var sw = new StringWriter())
            using (var sr = new StringReader(input))
            {
                Console.SetOut(sw);
                Console.SetIn(sr);

                _shoppingCartHandler.AddItemToShoppingCart();

                var cartItems = _shoppingCartHandler.GetShoppingCartItems();
                Assert.AreEqual(0, cartItems.Count);
            }
        }

        [TestMethod]
        public void ShowItemsInShoppingCart_ShouldDisplayCartContents_WhenItemsAreInCart()
        {
            var input = "1"; // ID of "Apple"
            using (var sw = new StringWriter())
            using (var sr = new StringReader(input))
            {
                Console.SetOut(sw);
                Console.SetIn(sr);

                _shoppingCartHandler.AddItemToShoppingCart();

                _shoppingCartHandler.ShowItemsInShoppingCart();

                var output = sw.ToString();
                Assert.IsTrue(output.Contains("-------- YOUR SHOPPING CART ---------"));
                Assert.IsTrue(output.Contains("Apple - Quantity: 1"));
                Assert.IsTrue(output.Contains("-------------------------------------"));
            }
        }

        [TestMethod]
        public void ShowItemsInShoppingCart_ShouldDisplayEmptyCartMessage_WhenCartIsEmpty()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                _shoppingCartHandler.ShowItemsInShoppingCart();

                var output = sw.ToString();
                Assert.IsTrue(output.Contains("-------- YOUR SHOPPING CART ---------"));
                Assert.IsFalse(output.Contains(" - Quantity: "));
                Assert.IsTrue(output.Contains("-------------------------------------"));
            }
        }
    }
}
