using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class CouponProcessor : ICouponProcessor
    {
        public CouponProcessor() { }
        public double ApplyCoupon(int couponId, IEnumerable<CartItem> shoppingCart, IEnumerable<Coupon> availableCoupons, double shoppingCartTotal)
        {
            //TODO
            var selectedCoupon = availableCoupons.FirstOrDefault(x => x.Id == couponId);
            if (selectedCoupon != null && selectedCoupon == availableCoupons.FirstOrDefault(x => x.Id == selectedCoupon.Id) && selectedCoupon.Id != 3)
            {
                Console.WriteLine("Applyin coupon...");
                var newCartTotal = shoppingCartTotal - (shoppingCartTotal * selectedCoupon.Discount);
                return newCartTotal;
                /*Console.WriteLine($"Your new total is: ${newCartTotal}");
                Console.WriteLine($"Thank you for coming. You saved: ${shoppingCartTotal - newCartTotal}");
                Environment.Exit(0);*/
            }
            else if (selectedCoupon.Id == 3)
            {
                double newCartTotal = 0;
                foreach (var item in shoppingCart)
                {
                    if (item.Quantity % 2 == 0)
                    {
                        var discountItemPrice = (((item.Price * item.Quantity) * selectedCoupon.Discount) * 0.5);
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
                /*Console.WriteLine($"Your new total is: ${newCartTotal}");
                Console.WriteLine($"Thank you for coming. Today you saved: ${shoppingCartTotal - newCartTotal}");
                Environment.Exit(0);*/
                return newCartTotal;
            }
            return 0;
            /*else
            {
                Console.WriteLine("Sorry, that is not a valid coupon code");
            }*/
        }
        public void ShowAvailableCoupons(IEnumerable<Coupon> availableCoupons)
        {
            foreach (var coupon in availableCoupons)
            {
                Console.WriteLine($"{coupon.Id} - {coupon.Name}, {coupon.Description}");
            }
        }
    }
}
