using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using GroceryStoreUnitTest.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class CouponHandlerTests
    {
        private Mock<ICouponProcessor> _mockCouponProcessor;
        private CouponHandler _couponHandler;
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            _mockCouponProcessor = new Mock<ICouponProcessor>();
            _couponHandler = new CouponHandler(_mockCouponProcessor.Object);
            _testData = new TestData();
        }

        [TestMethod]
        public void HandleUserSelection_AppliesCoupon_WhenUserInputsY()
        {
            var shoppingCart = _testData.CreateGeneralShoppingCartList();
            double shoppingCartTotal = 100.0;
            double expectedTotal = 90.0;

            using (var stringReader = new StringReader("Y"))
            {
                Console.SetIn(stringReader);

                _mockCouponProcessor.Setup(p => p.ApplyCoupon(It.IsAny<int>(), shoppingCart, It.IsAny<IEnumerable<Coupon>>(), shoppingCartTotal))
                                    .Returns(expectedTotal);

                var result = _couponHandler.HandleUserSelection(shoppingCart, shoppingCartTotal);

                Assert.AreEqual(expectedTotal, result);
                _mockCouponProcessor.Verify(p => p.ApplyCoupon(It.IsAny<int>(), shoppingCart, It.IsAny<IEnumerable<Coupon>>(), shoppingCartTotal), Times.Once);
            }
        }

        [TestMethod]
        public void HandleUserSelection_SkipsCoupon_WhenUserInputsN()
        {
            // Arrange
            var shoppingCart = _testData.CreateGeneralShoppingCartList();
            double shoppingCartTotal = 10.0;

            using (var stringReader = new StringReader("N"))
            {
                Console.SetIn(stringReader);

                _mockCouponProcessor.Setup(p => p.ApplyCoupon(It.IsAny<int>(), shoppingCart, It.IsAny<IEnumerable<Coupon>>(), shoppingCartTotal))
                                    .Returns(shoppingCartTotal);

                var result = _couponHandler.HandleUserSelection(shoppingCart, shoppingCartTotal);

                Assert.AreEqual(shoppingCartTotal, result);
                _mockCouponProcessor.Verify(p => p.ApplyCoupon(It.IsAny<int>(), shoppingCart, It.IsAny<IEnumerable<Coupon>>(), shoppingCartTotal), Times.Once);
            }
        }

        [TestMethod]
        public void HandleUserSelection_ShowsErrorForInvalidInputTheProcessesCouponWithValidInput()
        {
            // Arrange
            var shoppingCart = _testData.CreateGeneralShoppingCartList();
            double shoppingCartTotal = 100.0;
            string userInputs = "X\nY"; // First an invalid input 'X', then valid 'Y'
            double expectedTotal = 90.0;

            using (var stringReader = new StringReader(userInputs))
            using (var stringWriter = new StringWriter())
            {
                Console.SetIn(stringReader);
                Console.SetOut(stringWriter); // Capture Console output

                _mockCouponProcessor.Setup(p => p.ApplyCoupon(It.IsAny<int>(), shoppingCart, It.IsAny<IEnumerable<Coupon>>(), shoppingCartTotal))
                                    .Returns(expectedTotal);

                var result = _couponHandler.HandleUserSelection(shoppingCart, shoppingCartTotal);

                Assert.IsTrue(stringWriter.ToString().Contains("Sorry X is not a valid input. Please enter Y or N."));
                Assert.AreEqual(expectedTotal, result);
            }
        }
    }
}
