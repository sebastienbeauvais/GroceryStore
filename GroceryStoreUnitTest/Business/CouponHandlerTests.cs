using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using Moq;
using GroceryStoreUnitTest.HelperClasses;
using GroceryStoreUnitTest.Data;
using GroceryStore.Data.Interfaces;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class CouponHandlerTests
    {
        private Mock<ICouponProcessor> _mockCouponProcessor;
        private Mock<ICouponDb> _mockCouponDb;
        private Mock<ICouponHandlerHelper> _mockCouponHandlerHelper;
        private ICouponHandler _couponHandler;
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            _mockCouponProcessor = new Mock<ICouponProcessor>();
            _mockCouponDb = new Mock<ICouponDb>();
            _mockCouponHandlerHelper = new Mock<ICouponHandlerHelper>();
            _testData = new TestData();
            _couponHandler = new CouponHandler(_mockCouponProcessor.Object, _mockCouponDb.Object, _mockCouponHandlerHelper.Object);
        }

        [TestMethod]
        public void HandleUserSelection_ShouldApplyCoupon_WhenUserSelectsYes()
        {
            // Arrange
            var shoppingCart = _testData.CreateGeneralShoppingCart();
            double discountedTotal = 9.0;
            var shoppingCartDiscount = shoppingCart.TotalPrice * shoppingCart.coupon.Discount;

            _mockCouponProcessor.Setup(x => x.ApplyCoupon(shoppingCart))
                .Returns(shoppingCart.TotalPrice - shoppingCartDiscount);
            
            shoppingCart.TotalPrice = shoppingCart.TotalPrice - shoppingCartDiscount;

            using (var consoleInput = new ConsoleInput("Y", "1"))
            using (var consoleOutput = new ConsoleOutput())
            {
                var finalTotal = _couponHandler.HandleUserSelection(shoppingCart);

                Assert.AreEqual(discountedTotal, finalTotal);
                _mockCouponProcessor.Verify(x => x.ApplyCoupon(shoppingCart), Times.Once);
            }
        }
        /*
        [TestMethod]
        public void HandleUserSelection_ShouldNotApplyCoupon_WhenUserSelectsNo()
        {
            var shoppingCart = new List<CartItem>
            {
                new CartItem { Id = 1, Name = "Item1", Quantity = 2, Price = 20.0 }
            };
            double shoppingCartTotal = 40.0;

            using (var consoleInput = new ConsoleInput("N"))
            using (var consoleOutput = new ConsoleOutput())
            {
                var finalTotal = _couponHandler.HandleUserSelection(shoppingCart, shoppingCartTotal);

                Assert.AreEqual(shoppingCartTotal, finalTotal);
                _mockCouponProcessor.Verify(x => x.ShowAvailableCoupons(It.IsAny<IEnumerable<Coupon>>()), Times.Never);
                _mockCouponProcessor.Verify(x => x.ApplyCoupon(It.IsAny<int>(), shoppingCart, It.IsAny<IEnumerable<Coupon>>(), shoppingCartTotal), Times.Never);
            }
        }

        [TestMethod]
        public void HandleUserSelection_ShouldHandleInvalidInput()
        {
            var shoppingCart = new List<CartItem>
            {
                new CartItem { Id = 1, Name = "Item1", Quantity = 2, Price = 20.0 }
            };
            double shoppingCartTotal = 40.0;

            using (var consoleInput = new ConsoleInput("X", "N"))
            using (var consoleOutput = new ConsoleOutput())
            {
                var finalTotal = _couponHandler.HandleUserSelection(shoppingCart, shoppingCartTotal);

                Assert.AreEqual(shoppingCartTotal, finalTotal);
                StringAssert.Contains(consoleOutput.GetOutput(), "Sorry X is not a valid input. Please enter Y or N.");
            }
        }*/
    }
}
