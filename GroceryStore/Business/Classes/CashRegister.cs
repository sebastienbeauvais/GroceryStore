﻿using GroceryStore.Business.Interfaces;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class CashRegister : ICashRegister
    {
        CouponHandler couponHandler = new CouponHandler();
        //private readonly CouponHandler _couponHandler;
        public CashRegister()
        {
            //_couponHandler = couponHandler;
        }

        public void Checkout(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal)
        {
            var newCartTotal = couponHandler.HandleUserSelection(shoppingCart, shoppingCartTotal);
            Console.WriteLine($"Thank you for shopping with us. Your total was ${newCartTotal}");
            Console.WriteLine($"And you saved: $VAR TO BE ADDED");
            Environment.Exit(0);
        }
    }
}
