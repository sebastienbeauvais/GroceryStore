using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BusinessTests
{
    [TestClass]
    public class CashRegisterTests
    {
        private Mock<ICouponHandler> _mockCouponHandler;
        private Mock<IShoppingCartBuilder> _mockShoppingCartBuilder;
        private CashRegister _cashRegister;

        [TestInitialize]
        public void Setup()
        {
            _mockCouponHandler = new Mock<ICouponHandler>();
            _mockShoppingCartBuilder = new Mock<IShoppingCartBuilder>();
            _cashRegister = new CashRegister(_mockCouponHandler.Object, _mockShoppingCartBuilder.Object);
        }

        [TestMethod]
        public void Checkout_ShouldInvokeShoppingCartBuilderAndCouponHandler()
        {
            var shoppingCart = new ShoppingCart { TotalPrice = 100 };
            _mockShoppingCartBuilder
                .Setup(builder => builder.BuildShoppingCart())
                .Returns(shoppingCart);

            _cashRegister.Checkout();

            _mockShoppingCartBuilder.Verify(builder => builder.BuildShoppingCart(), Times.Once);
            _mockCouponHandler.Verify(handler => handler.HandleUserSelection(shoppingCart), Times.Once);
        }

        [TestMethod]
        public void Checkout_ShouldPrintTotalPrice()
        {
            var shoppingCart = new ShoppingCart { TotalPrice = 50.75 };
            _mockShoppingCartBuilder
                .Setup(builder => builder.BuildShoppingCart())
                .Returns(shoppingCart);

            using var consoleOutput = new ConsoleOutputCapture();

            _cashRegister.Checkout();

            var output = consoleOutput.GetOutput();
            Assert.IsTrue(output.Contains($"Thank you for shopping with us. Your total was ${shoppingCart.TotalPrice}"));
        }
    }

    public class ConsoleOutputCapture : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutput;

        public ConsoleOutputCapture()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOutput() => _stringWriter.ToString();

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }
}
