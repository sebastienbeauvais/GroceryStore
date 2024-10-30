using GroceryStore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class TenOffDiscountCouponStrategy : ICouponStrategy
    {
        public double ApplyCoupon(IEnumerable<ICartItem> shoppingCart, double shoppingCartTotal, ICoupon coupon)
        {
            Console.WriteLine("Applying flat discount coupon...");
            return shoppingCartTotal - (shoppingCartTotal * coupon.Discount);
        }
    }
}
