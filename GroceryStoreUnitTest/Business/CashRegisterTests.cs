using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;
using GroceryStoreUnitTest.Data;
using Moq;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class CashRegisterTests
    {
        private Mock<ICouponHandler> _mockCouponHandler;
        private Mock<IShoppingCartBuilder> _mockShoppingCartBuilder;
        private Mock<IShoppingCart> _mockShoppingCart;
        private CashRegister _cashRegister;
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            _mockCouponHandler = new Mock<ICouponHandler>();
            _mockShoppingCartBuilder = new Mock<IShoppingCartBuilder>();
            _cashRegister = new CashRegister(_mockCouponHandler.Object, _mockShoppingCartBuilder.Object);
            _testData = new TestData();
        }
        [TestMethod]
        public void CheckoutReturnsCartTotalInMessage()
        {
            var shoppingCart = _testData.CreateGenericShoppingCart_NoCoupon();

            _mockCouponHandler.Setup(handler => handler.HandleUserSelection(shoppingCart))
                              .Returns(shoppingCart.TotalPrice);
            _mockShoppingCartBuilder.Setup(cart => cart.BuildShoppingCart()).Returns(shoppingCart);

            _cashRegister.Checkout();

            _mockCouponHandler.Verify(handler => handler.HandleUserSelection(shoppingCart), Times.Once);
        }
    }
}
