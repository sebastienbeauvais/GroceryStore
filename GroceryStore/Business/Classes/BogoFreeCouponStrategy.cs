using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Business.Classes
{
    public class BogoFreeCouponStrategy : ICouponStrategy
    {
        public double ApplyCoupon(IShoppingCart shoppingCart)
        {
            double newCartTotal = 0;
            foreach (var item in shoppingCart.Items)
            {
                if (item.Quantity % 2 == 0)
                {
                    var discountItemPrice = ((item.Price * item.Quantity) * shoppingCart.coupon.Discount);
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
        public bool IsApplicable(ICoupon coupon)
        {
            return coupon.Id == 2;
        }
    }
}
