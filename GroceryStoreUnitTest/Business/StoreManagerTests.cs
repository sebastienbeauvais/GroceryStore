using GroceryStore.Business.Interfaces;
using GroceryStore.Business.Service;
using GroceryStore.Models;
using Moq;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class StoreManagerTests
    {
        private StoreManager _storeManager;
        private Mock<ICashRegister> _mockCashRegister;
        private Mock<IShoppingCartHelper> _mockShoppingCart;
        private List<StoreItem> _storeInventory;

        /*[TestInitialize]
        public void Setup()
        {
            _mockCashRegister = new Mock<ICashRegister>();
            _mockShoppingCart = new Mock<IShoppingCartHelper>();
            _storeManager = new StoreManager(_mockCashRegister.Object, _mockShoppingCart.Object);

            _storeInventory = new List<StoreItem>
            {
                new StoreItem { Id = 1, Name = "Apple", Price = 0.50 },
                new StoreItem { Id = 2, Name = "Banana", Price = 0.20 }
            };
        }

        [TestMethod]
        public void HandleUserInput_ShowInventory_DisplaysInventory()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                _storeManager.HandleUserInput("1");

                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Apple"));
                Assert.IsTrue(output.Contains("Banana"));
            }
        }

        [TestMethod]
        public void HandleUserInput_AddItemToCart_CallsAddItemOnShoppingCart()
        {
            _storeManager.HandleUserInput("2");

            _mockShoppingCart.Verify(cart => cart.AddItemToShoppingCart(It.IsAny<IEnumerable<StoreItem>>()), Times.Once);
        }

        [TestMethod]
        public void HandleUserInput_ShowCartItems_CallsShowItemsOnShoppingCart()
        {
            _storeManager.HandleUserInput("3");

            _mockShoppingCart.Verify(cart => cart.ShowItemsInShoppingCart(It.IsAny<IEnumerable<StoreItem>>()), Times.Once);
        }

        [TestMethod]
        public void HandleUserInput_Checkout_CallsCheckoutOnCashRegister()
        {
            var cartItems = new List<CartItem>
            {
                new CartItem { Name = "Apple", Quantity = 2, Price = 0.50 }
            };

            _mockShoppingCart.Setup(cart => cart.GetShoppingCartItems()).Returns(cartItems);
            _mockShoppingCart.Setup(cart => cart.GetCartTotal(It.IsAny<IEnumerable<StoreItem>>(), cartItems)).Returns(1.0);

            _storeManager.HandleUserInput("4");

            _mockCashRegister.Verify(register => register.Checkout(cartItems, 1.0), Times.Once);
        }*/
    }
}
