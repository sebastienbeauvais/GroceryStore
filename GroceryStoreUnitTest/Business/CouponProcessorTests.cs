using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;
using Moq;

namespace BusinessTests
{
    [TestClass]
    public class CouponProcessorTests
    {
        private CouponProcessor _couponProcessor;
        private Mock<IShoppingCart> _mockShoppingCart;
        private Mock<ICoupon> _mockCoupon;
        private Mock<ICouponStrategy> _mockCouponStrategy;

        [TestInitialize]
        public void Setup()
        {
            _couponProcessor = new CouponProcessor();
            _mockShoppingCart = new Mock<IShoppingCart>();
            _mockCoupon = new Mock<ICoupon>();
            _mockCouponStrategy = new Mock<ICouponStrategy>();
        }

        [TestMethod]
        public void ApplyCoupon_ShouldNotChangeTotalPrice_WhenNoCouponIsApplied()
        {
            _mockShoppingCart.Setup(cart => cart.coupon).Returns((ICoupon)null);
            _mockShoppingCart.SetupProperty(cart => cart.TotalPrice, 100.0);

            var result = _couponProcessor.ApplyCoupon(_mockShoppingCart.Object);

            Assert.AreEqual(100.0, result);
            _mockShoppingCart.Verify(cart => cart.coupon, Times.Once);
        }

        [TestMethod]
        public void ApplyCoupon_ShouldNotChangeTotalPrice_WhenCouponHasNoStrategy()
        {
            _mockCoupon.Setup(coupon => coupon.CouponStrategy).Returns((ICouponStrategy)null);
            _mockShoppingCart.Setup(cart => cart.coupon).Returns(_mockCoupon.Object);
            _mockShoppingCart.SetupProperty(cart => cart.TotalPrice, 100.0);

            var result = _couponProcessor.ApplyCoupon(_mockShoppingCart.Object);

            Assert.AreEqual(100.0, result);
            _mockShoppingCart.Verify(cart => cart.coupon, Times.AtLeastOnce);
        }

        [TestMethod]
        public void ApplyCoupon_ShouldChangeTotalPrice_WhenValidCouponStrategyIsApplied()
        {
            _mockCouponStrategy
                .Setup(strategy => strategy.ApplyCoupon(It.IsAny<IShoppingCart>()))
                .Returns(50.0);

            _mockCoupon.Setup(coupon => coupon.CouponStrategy).Returns(_mockCouponStrategy.Object);
            _mockShoppingCart.Setup(cart => cart.coupon).Returns(_mockCoupon.Object);
            _mockShoppingCart.SetupProperty(cart => cart.TotalPrice, 100.0);

            var result = _couponProcessor.ApplyCoupon(_mockShoppingCart.Object);

            Assert.AreEqual(50.0, result);
            _mockShoppingCart.Verify(cart => cart.coupon, Times.AtLeastOnce);
            _mockCouponStrategy.Verify(strategy => strategy.ApplyCoupon(_mockShoppingCart.Object), Times.AtLeastOnce);
        }

        [TestMethod]
        public void ApplyCoupon_ShouldRetainOriginalTotalPrice_WhenStrategyDoesNotChangePrice()
        {
            _mockCouponStrategy
                .Setup(strategy => strategy.ApplyCoupon(It.IsAny<IShoppingCart>()))
                .Returns(100.0);

            _mockCoupon.Setup(coupon => coupon.CouponStrategy).Returns(_mockCouponStrategy.Object);
            _mockShoppingCart.Setup(cart => cart.coupon).Returns(_mockCoupon.Object);
            _mockShoppingCart.SetupProperty(cart => cart.TotalPrice, 100.0);

            var result = _couponProcessor.ApplyCoupon(_mockShoppingCart.Object);

            Assert.AreEqual(100.0, result);
            _mockShoppingCart.Verify(cart => cart.coupon, Times.AtLeastOnce);
            _mockCouponStrategy.Verify(strategy => strategy.ApplyCoupon(_mockShoppingCart.Object), Times.AtLeastOnce);
        }
    }
}
