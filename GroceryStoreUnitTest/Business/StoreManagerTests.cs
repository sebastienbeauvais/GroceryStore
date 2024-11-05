using GroceryStore.Business.Interfaces;
using GroceryStore.Business.Service;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;
using Moq;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class StoreManagerTests
    {
        private StoreManager storeManager;
        private Mock<ICashRegister> _mockCashRegister;
        private Mock<IShoppingCartHandler> _mockShoppingCart;
        private Mock<IStoreInventoryDb> _mockStoreDb;
        private List<IStoreItem> _storeInventory;

        [TestInitialize]
        public void Setup()
        {
            _mockCashRegister = new Mock<ICashRegister>();
            _mockShoppingCart = new Mock<IShoppingCartHandler>();
            _mockStoreDb = new Mock<IStoreInventoryDb>();

            _storeInventory = new List<IStoreItem>
            {
                new StoreItem { Id = 1, Name = "Apple", Price = 0.50 },
                new StoreItem { Id = 2, Name = "Banana", Price = 0.20 }
            };

            _mockStoreDb.Setup(x => x.Inventory).Returns(_storeInventory);

            storeManager = new StoreManager(_mockCashRegister.Object, _mockShoppingCart.Object, _mockStoreDb.Object);
        }
        
        [TestMethod]
        public void HandleUserInput_CallsShowsStoreInventoryToConsole()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                storeManager.HandleUserInput("1");

                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Apple"));
                Assert.IsTrue(output.Contains("Banana"));
            }
        }
        
        [TestMethod]
        public void HandleUserInput_CallsAddItemOnShoppingCart()
        {
            storeManager.HandleUserInput("2");

            _mockShoppingCart.Verify(cart => cart.AddItemToShoppingCart(), Times.Once);
        }
        
        [TestMethod]
        public void HandleUserInput_CallsShowItemsOnShoppingCart()
        {
            storeManager.HandleUserInput("3");

            _mockShoppingCart.Verify(cart => cart.ShowItemsInShoppingCart(), Times.Once);
        }
        
        [TestMethod]
        public void HandleUserInput_CallsCheckoutOnCashRegister()
        {
            storeManager.HandleUserInput("4");

            _mockCashRegister.Verify(register => register.Checkout(), Times.Once);
        }
    }
}
