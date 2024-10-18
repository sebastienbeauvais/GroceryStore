using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CouponHandler : ICouponHandler
    {
        private ICouponProcessor _couponProcessor;
        public CouponHandler(ICouponProcessor couponProcessor) 
        {
            _couponProcessor = couponProcessor;
        }

        private List<Coupon> availableCoupons = new List<Coupon>()
        {
            new Coupon { Id = 0, Name = "NoCouponApplied", Description = "No coupon will be applied to your cart", Discount = 0.0 },
            new Coupon { Id = 1, Name = "10OFF", Description = "Applied 10% off your total cart", Discount = 0.1 },
            new Coupon { Id = 2, Name = "25OFF", Description = "Applied 25% off your total cart", Discount = 0.25 },
            new Coupon { Id = 3, Name = "BOGOFree", Description = "Buy one item get one free", Discount = 1.0 },
        };
        
        public double HandleUserSelection(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal)
        {
            string userIn = string.Empty;
            UserSelectionContext context;

            while (userIn != "Y" || userIn != "N")
            {
                Console.WriteLine("\nApply a coupon? (Y/N)");
                userIn = Console.ReadLine().ToUpper();
                if (userIn == "Y")
                {
                    context = new UserSelectionContext(new ApplyCouponState(_couponProcessor, availableCoupons));
                    return context.HandleUserSelection(shoppingCart, shoppingCartTotal);
                }
                else if (userIn == "N")
                {
                    context = new UserSelectionContext(new ApplyCouponState(_couponProcessor, availableCoupons));
                    return context.HandleUserSelectionForNoCoupon(shoppingCart, shoppingCartTotal);
                }
                else
                {
                    Console.WriteLine($"Sorry {userIn} is not a valid input. Please enter Y or N.");
                }
            }
            return shoppingCartTotal;

        }
    }
}
