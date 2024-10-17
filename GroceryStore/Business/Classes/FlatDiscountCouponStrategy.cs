using GroceryStore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class FlatDiscountCouponStrategy : ICouponStrategy
    {
        public double ApplyCoupon(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal, Coupon coupon)
        {
            Console.WriteLine("Applying flat discount coupon...");
            return shoppingCartTotal - (shoppingCartTotal * coupon.Discount);
        }
    }
}
