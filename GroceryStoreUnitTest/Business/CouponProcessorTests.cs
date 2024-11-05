using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using Moq;
using GroceryStoreUnitTest.Data;
using System.Reflection;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class CouponProcessorTests
    {
        private CouponProcessor _couponProcessor;
        private Mock<ICouponStrategy> _tenOffDiscountStrategy;
        private Mock<ICouponStrategy> _bogoFreeStrategy;
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            var tenOffDiscountStrategy = new TenOffDiscountCouponStrategy();
            var bogoFreeStrategy = new BogoFreeCouponStrategy();

            var strategies = new List<ICouponStrategy> { tenOffDiscountStrategy, bogoFreeStrategy };
            _couponProcessor = new CouponProcessor();
            _testData = new TestData();
        }

        /*[TestMethod]
        public void ApplyCoupon_WithTenOffDiscountCoupon_AppliesDiscountCorrectly()
        {
            double cartTotal = 10.0;
            int couponId = 1;
            IEnumerable<Coupon> _availableCoupons = _testData.CreateTwoCouponList();
            List<CartItem> _shoppingCart = _testData.CreateGeneralShoppingCartList();

            var result = _couponProcessor.ApplyCoupon(couponId, _shoppingCart, _availableCoupons, cartTotal);

            Assert.AreEqual(9.0, result);
        }

        [TestMethod]
        public void ApplyCoupon_WithBogoFreeCoupon_AppliesDiscountCorrectly()
        {
            double cartTotal = 20.0;
            int couponId = 2;
            IEnumerable<Coupon> _availableCoupons = _testData.CreateTwoCouponList();
            List<CartItem> _shoppingCart = _testData.CreateCartForBogoDiscountEvenQuantity();

            var result = _couponProcessor.ApplyCoupon(couponId, _shoppingCart, _availableCoupons, cartTotal);

            Assert.AreEqual(10.0, result);
        }

        [TestMethod]
        public void ApplyCoupon_WithInvalidCouponId_ReturnsOriginalTotal()
        {
            double cartTotal = 100.0;
            int invalidCouponId = 99;
            IEnumerable<Coupon> _availableCoupons = _testData.CreateCouponList();
            List<CartItem> _shoppingCart = _testData.CreateGeneralShoppingCartList();

            var result = _couponProcessor.ApplyCoupon(invalidCouponId, _shoppingCart, _availableCoupons, cartTotal);

            Assert.AreEqual(cartTotal, result);
        }

        [TestMethod]
        public void ShowAvailableCoupons_DisplaysCorrectInformation()
        {
            IEnumerable<Coupon> _availableCoupons = _testData.CreateTwoCouponList();
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            _couponProcessor.ShowAvailableCoupons(_availableCoupons);

            var output = consoleOutput.ToString();
            Assert.IsTrue(output.Contains("1 - 10OFF, 10 off total cart"));
            Assert.IsTrue(output.Contains("2 - BOGOFREE, Buy one get one free"));
        }

        [TestMethod]
        public void GetCouponIdForStrategy_WithUnknownStrategy_ThrowsException()
        {
            var unknownStrategy = new Mock<ICouponStrategy>().Object;

            var result = typeof(CouponProcessor)
                .GetMethod("GetCouponIdForStrategy", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            try
            {
                result.Invoke(_couponProcessor, new object[] { unknownStrategy });
                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (TargetInvocationException ex)
            {
                Assert.AreEqual("Unknown coupon strategy.", ex.InnerException.Message);
            }
        }*/
    }
}
