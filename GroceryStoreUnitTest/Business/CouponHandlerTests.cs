using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using Moq;
using GroceryStoreUnitTest.HelperClasses;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class CouponHandlerTests
    {
        private Mock<ICouponProcessor> _mockCouponProcessor;
        private CouponHandler _couponHandler;

        [TestInitialize]
        public void Setup()
        {
            _mockCouponProcessor = new Mock<ICouponProcessor>();
            //_couponHandler = new CouponHandler(_mockCouponProcessor.Object);
        }

        /*[TestMethod]
        public void HandleUserSelection_ShouldApplyCoupon_WhenUserSelectsYes()
        {
            // Arrange
            var shoppingCart = new List<CartItem>
            {
                new CartItem { Id = 1, Name = "Item1", Quantity = 2, Price = 20.0 }
            };
            double shoppingCartTotal = 40.0;
            double discountedTotal = 30.0;

            _mockCouponProcessor.Setup(x => x.ApplyCoupon(It.IsAny<int>(), shoppingCart, It.IsAny<IEnumerable<Coupon>>(), shoppingCartTotal))
                .Returns(discountedTotal);

            using (var consoleInput = new ConsoleInput("Y", "1"))
            using (var consoleOutput = new ConsoleOutput())
            {
                var finalTotal = _couponHandler.HandleUserSelection(shoppingCart, shoppingCartTotal);

                Assert.AreEqual(discountedTotal, finalTotal);
                _mockCouponProcessor.Verify(x => x.ShowAvailableCoupons(It.IsAny<IEnumerable<Coupon>>()), Times.Once);
                _mockCouponProcessor.Verify(x => x.ApplyCoupon(It.IsAny<int>(), shoppingCart, It.IsAny<IEnumerable<Coupon>>(), shoppingCartTotal), Times.Once);
            }
        }

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
