using GroceryStore.Business.Service;
using GroceryStore.Business.Interfaces;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;
using GroceryStore.Models;

namespace BusinessTests
{
    [TestClass]
    public class StoreManagerTests
    {
        private Mock<ICashRegister> _mockCashRegister;
        private Mock<IShoppingCartHandler> _mockShoppingCartHandler;
        private Mock<IStoreInventoryDb> _mockStoreInventoryDb;
        private StoreManager _storeManager;
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

            _mockCashRegister = new Mock<ICashRegister>();
            _mockShoppingCartHandler = new Mock<IShoppingCartHandler>();
            _mockStoreInventoryDb = new Mock<IStoreInventoryDb>();

            _mockStoreInventoryDb.Setup(db => db.Inventory).Returns(_storeInventory);

            _storeManager = new StoreManager(
                _mockCashRegister.Object,
                _mockShoppingCartHandler.Object,
                _mockStoreInventoryDb.Object
            );
        }

        [TestMethod]
        public void ShowStoreMenu_ShouldDisplayCorrectMenuOptions()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _storeManager.ShowStoreMenu();

                var expectedOutput = @"
                    1. Show store inventory
2. Add item(s) to cart
3. Show items in your cart
4. Checkout
5. Leave store".Trim();

                var actualOutput = sw.ToString().Trim();

                // Normalize the line breaks by replacing \r\n with \n
                expectedOutput = expectedOutput.Replace("\r\n", "\n");
                actualOutput = actualOutput.Replace("\r\n", "\n");

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [TestMethod]
        public void HandleUserInput_ShouldDisplayInventory_WhenInputIs1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _storeManager.HandleUserInput("1");

                var output = sw.ToString().Trim();
                Assert.IsTrue(output.Contains("1. Apple - $1.00"));
                Assert.IsTrue(output.Contains("2. Banana - $0.50"));
                Assert.IsTrue(output.Contains("3. Carrot - $0.80"));
            }
        }

        [TestMethod]
        public void HandleUserInput_ShouldCallAddItemToShoppingCart_WhenInputIs2()
        {
            _storeManager.HandleUserInput("2");
            _mockShoppingCartHandler.Verify(handler => handler.AddItemToShoppingCart(), Times.Once);
        }

        [TestMethod]
        public void HandleUserInput_ShouldCallShowItemsInShoppingCart_WhenInputIs3()
        {
            _storeManager.HandleUserInput("3");
            _mockShoppingCartHandler.Verify(handler => handler.ShowItemsInShoppingCart(), Times.Once);
        }

        [TestMethod]
        public void HandleUserInput_ShouldCallCheckout_WhenInputIs4()
        {
            _storeManager.HandleUserInput("4");
            _mockCashRegister.Verify(register => register.Checkout(), Times.Once);
        }

        [TestMethod]
        public void HandleUserInput_ShouldDoNothing_WhenInputIsInvalid()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                _storeManager.HandleUserInput("invalid");

                var output = sw.ToString();
                Assert.AreEqual(string.Empty, output);
            }
        }
    }
}
