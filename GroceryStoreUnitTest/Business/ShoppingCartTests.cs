using GroceryStore.Business.Interfaces;
using GroceryStore.Business.Classes;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class ShoppingCartTests
    {
        private IShoppingCartHandler _shoppingCartHandler;
        private IStoreInventoryDb _storeInventory;

        [TestInitialize]
        public void Setup()
        {
            _shoppingCartHandler = new ShoppingCartHandler(_storeInventory);
            /*_storeInventory = new List<StoreItem>
            {
                new StoreItem { Id = 1, Name = "Apple", Price = 1.0 },
                new StoreItem { Id = 2, Name = "Banana", Price = 0.5 },
                new StoreItem { Id = 3, Name = "Orange", Price = 0.75 }
            };*/
        }

        /*[TestMethod]
        public void AddItemToShoppingCart_ItemExistsInInventory_AddsToCart()
        {
            Console.SetIn(new StringReader("1")); // Simulate user input for item ID

            _shoppingCart.AddItemToShoppingCart(_storeInventory);

            var cartItems = _shoppingCart.GetShoppingCartItems();
            Assert.AreEqual(1, cartItems.Count());
            Assert.AreEqual("Apple", cartItems.First().Name);
            Assert.AreEqual(1, cartItems.First().Quantity);
        }

        [TestMethod]
        public void AddItemToShoppingCart_ItemExistsInCart_IncrementsQuantity()
        {
            Console.SetIn(new StringReader("1"));
            _shoppingCart.AddItemToShoppingCart(_storeInventory);
            Console.SetIn(new StringReader("1"));

            _shoppingCart.AddItemToShoppingCart(_storeInventory);

            var cartItems = _shoppingCart.GetShoppingCartItems();
            Assert.AreEqual(1, cartItems.Count());
            Assert.AreEqual("Apple", cartItems.First().Name);
            Assert.AreEqual(2, cartItems.First().Quantity);
        }

        [TestMethod]
        public void AddItemToShoppingCart_ItemDoesNotExistInInventory_DoesNotAddToCart()
        {
            Console.SetIn(new StringReader("4"));

            _shoppingCart.AddItemToShoppingCart(_storeInventory);

            var cartItems = _shoppingCart.GetShoppingCartItems();
            Assert.AreEqual(0, cartItems.Count());
        }

        [TestMethod]
        public void GetCartTotal_ValidCartItems_ReturnsCorrectTotal()
        {
            var cartItems = new List<CartItem>
            {
                new CartItem { Name = "Apple", Quantity = 2 },
                new CartItem { Name = "Banana", Quantity = 3 }
            };
            foreach (var item in cartItems)
            {
                _shoppingCart.GetShoppingCartItems().ToList().Add(item);
            }

            var total = _shoppingCart.GetCartTotal(_storeInventory, cartItems);

            Assert.AreEqual(3.5, total);
        }

        [TestMethod]
        public void GetShoppingCartItems_ReturnsCorrectItems()
        {
            Console.SetIn(new StringReader("1"));
            _shoppingCart.AddItemToShoppingCart(_storeInventory);

            var result = _shoppingCart.GetShoppingCartItems();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Apple", result.First().Name);
            Assert.AreEqual(1, result.First().Quantity);
        }*/
    }
}
