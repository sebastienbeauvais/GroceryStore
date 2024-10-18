using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using GroceryStoreUnitTest.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class CashRegisterTests
    {
        private Mock<ICouponHandler> _mockCouponHandler;
        private CashRegister _cashRegister;
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            _mockCouponHandler = new Mock<ICouponHandler>();
            _testData = new TestData();

            // Inject the mock into the CashRegister
            _cashRegister = new CashRegister(_mockCouponHandler.Object);
        }
        [TestMethod]
        public void CheckoutAppliesCouponCorrectly()
        {
            var shoppingCart = _testData.CreateGeneralShoppingCartList();
            double shoppingCartTotal = 20.0;
            double expectedNewTotal = 15.0;

            _mockCouponHandler.Setup(handler => handler.HandleUserSelection(shoppingCart, shoppingCartTotal))
                              .Returns(expectedNewTotal);

            _cashRegister.Checkout(shoppingCart, shoppingCartTotal);

            _mockCouponHandler.Verify(handler => handler.HandleUserSelection(shoppingCart, shoppingCartTotal), Times.Once);
        }
    }
}
