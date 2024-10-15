using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Business.Classes
{
    public class BogoFreeCouponStrategy : ICouponStrategy
    {
        public double ApplyCoupon(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal, Coupon coupon)
        {
            double newCartTotal = 0;
            foreach (var item in shoppingCart)
            {
                if (item.Quantity % 2 == 0)
                {
                    var discountItemPrice = (((item.Price * item.Quantity) * coupon.Discount) * 0.5);
                    newCartTotal += discountItemPrice;
                }
                else if (item.Quantity > 2)
                {
                    var discountItemPrice = (item.Price * (item.Quantity / 2));
                    newCartTotal += (item.Price * item.Quantity) - discountItemPrice;
                }
                else
                {
                    newCartTotal += item.Price;
                }
            }
            return newCartTotal;
        }
    }
}
