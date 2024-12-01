using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Data;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTests
{
    [TestClass]
    public class CouponHandlerTests
    {
        private Mock<ICouponProcessor> _mockCouponProcessor;
        private CouponDb _couponDb;
        private Mock<IShoppingCart> _mockShoppingCart;
        private List<Mock<ICouponStrategy>> _mockCouponStrategies;
        private CouponHandler _couponHandler;

        [TestInitialize]
        public void Setup()
        {
            _mockCouponProcessor = new Mock<ICouponProcessor>();
            _couponDb = new CouponDb();
            _mockShoppingCart = new Mock<IShoppingCart>();

            var mockStrategy1 = new Mock<ICouponStrategy>();
            var mockStrategy2 = new Mock<ICouponStrategy>();
            _mockCouponStrategies = new List<Mock<ICouponStrategy>> { mockStrategy1, mockStrategy2 };

            _couponHandler = new CouponHandler(
                _mockCouponProcessor.Object,
                _couponDb,
                _mockCouponStrategies.Select(s => s.Object)
            );
        }

        [TestMethod]
        public void HandleUserSelection_ShouldReturnTotalPrice_WhenUserDeclinesCoupon()
        {
            _mockShoppingCart.SetupGet(cart => cart.TotalPrice).Returns(100.0);
            SimulateConsoleInput("N");

            var result = _couponHandler.HandleUserSelection(_mockShoppingCart.Object);

            Assert.AreEqual(100.0, result);
        }

        [TestMethod]
        public void HandleUserSelection_ShouldApplyCoupon_WhenUserSelectsValidCoupon()
        {
            _mockShoppingCart.SetupProperty(cart => cart.coupon);

            _mockCouponStrategies[0].Setup(s => s.IsApplicable(It.IsAny<ICoupon>())).Returns(true);
            _mockCouponProcessor.Setup(processor => processor.ApplyCoupon(_mockShoppingCart.Object));

            SimulateConsoleInput("Y", "1");

            _couponHandler.HandleUserSelection(_mockShoppingCart.Object);

            Assert.IsNotNull(_mockShoppingCart.Object.coupon);
            _mockCouponProcessor.Verify(processor => processor.ApplyCoupon(_mockShoppingCart.Object), Times.Once);
        }

        [TestMethod]
        public void GetCouponDetails_ShouldThrowException_WhenCouponIdIsInvalid()
        {
            SimulateConsoleInput("Y", "999");

            Assert.ThrowsException<InvalidOperationException>(() =>
                _couponHandler.HandleUserSelection(_mockShoppingCart.Object));
        }

        private void SimulateConsoleInput(params string[] inputs)
        {
            var inputQueue = new Queue<string>(inputs);
            Console.SetIn(new System.IO.StringReader(string.Join(Environment.NewLine, inputQueue)));
        }
    }
}
