using GroceryStore.Business.Interfaces;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class CashRegister : ICashRegister
    {
        public CashRegister() { }
        private List<Coupon> availableCoupons = new List<Coupon>()
        {
            new Coupon { Id = 1, Name = "10% Off Total", Description = "Applied 10% off your total cart", Discount = 0.1 },
            new Coupon { Id = 2, Name = "25% Off Total", Description = "Applied 25% off your total cart", Discount = 0.25 },
            new Coupon { Id = 3, Name = "BOGOFree", Description = "Buy one item get one free", Discount = 1.0 },
        };
        public void Checkout(IEnumerable<CartItem> shoppingCart)
        {
            string userIn = string.Empty;
            while (userIn != "Y" || userIn != "N")
            {
                Console.WriteLine("\nApply a coupon? (Y/N)");
                userIn = Console.ReadLine().ToUpper();
                if (userIn == "Y")
                {
                    //TODO
                    ShowAvailableCoupons(availableCoupons);
                    Console.WriteLine("Which coupon would you like to apply (enter the ID): ");
                    var couponId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Applyin coupon...");
                    ApplyCoupon(couponId, shoppingCart, availableCoupons);

                }
                else if (userIn == "N")
                {
                    //TODO
                    Console.WriteLine("No coupon applied...");
                }
                else
                {
                    Console.WriteLine($"Sorry {userIn} is not a valid input. Please enter Y or N.");
                }
            }
        }
        private void ShowAvailableCoupons(IEnumerable<Coupon> availableCoupons)
        {
            foreach(var coupon in availableCoupons)
            {
                Console.WriteLine($"{coupon.Id}, {coupon.Name}, {coupon.Description}");
            }
        }
        private void ApplyCoupon(int couponId, IEnumerable<CartItem> shoppingCart, IEnumerable<Coupon> availableCoupons)
        {
            //TODO
        }
    }
}
