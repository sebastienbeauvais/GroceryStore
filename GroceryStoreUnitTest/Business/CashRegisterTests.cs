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
            _cashRegister = new CashRegister(_mockCouponHandler.Object);
        }
        [TestMethod]
        public void CheckoutAppliesCouponCorrectly()
        {
            var shoppingCart = _testData.CreateGenericShoppingCart_OneItem_SingleQuantity();

            _mockCouponHandler.Setup(handler => handler.HandleUserSelection(shoppingCart))
                              .Returns(shoppingCart.TotalPrice);

            _cashRegister.Checkout(shoppingCart);

            _mockCouponHandler.Verify(handler => handler.HandleUserSelection(shoppingCart), Times.Once);
        }
    }
}
