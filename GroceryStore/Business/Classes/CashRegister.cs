using GroceryStore.Business.Interfaces;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class CashRegister : ICashRegister
    {
        public CashRegister() { }
        private List<Coupon> availableCoupons = new List<Coupon>()
        {
            new Coupon { Id = 1, Name = "10OFF", Description = "Applied 10% off your total cart", Discount = 0.1 },
            new Coupon { Id = 2, Name = "25OFF", Description = "Applied 25% off your total cart", Discount = 0.25 },
            new Coupon { Id = 3, Name = "BOGOFree", Description = "Buy one item get one free", Discount = 1.0 },
        };
        public void Checkout(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal)
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
                    ApplyCoupon(couponId, shoppingCart, availableCoupons, shoppingCartTotal);

                }
                else if (userIn == "N")
                {
                    //TODO
                    Console.WriteLine("No coupon applied...");
                    Console.WriteLine($"Thank you for coming. Your total is: ${shoppingCartTotal}");
                    Environment.Exit(0);
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
                Console.WriteLine($"{coupon.Id} - {coupon.Name}, {coupon.Description}");
            }
        }
        private void ApplyCoupon(int couponId, IEnumerable<CartItem> shoppingCart, IEnumerable<Coupon> availableCoupons, double shoppingCartTotal)
        {
            //TODO
            var selectedCoupon = availableCoupons.FirstOrDefault(x => x.Id == couponId);
            if (selectedCoupon != null && selectedCoupon == availableCoupons.FirstOrDefault(x => x.Id == selectedCoupon.Id) && selectedCoupon.Id != 3) 
            {
                Console.WriteLine("Applyin coupon...");
                var newCartTotal = shoppingCartTotal - (shoppingCartTotal * selectedCoupon.Discount);
                Console.WriteLine($"Your new total is: ${newCartTotal}");
                Console.WriteLine($"Thank you for coming. You saved: ${shoppingCartTotal - newCartTotal}");
                Environment.Exit(0);
            } 
            else if (selectedCoupon.Id == 3)
            {
                double newCartTotal = 0;
                foreach (var item in shoppingCart)
                {
                    if (item.Quantity % 2 == 0)
                    {
                        var discountItemPrice = (((item.Price * item.Quantity) * selectedCoupon.Discount)*0.5);
                        newCartTotal += discountItemPrice;
                    }
                    else if (item.Quantity > 2) 
                    {
                        var discountItemPrice = (item.Price * (item.Quantity/2));
                        newCartTotal += (item.Price * item.Quantity) - discountItemPrice;
                    }
                    else
                    {
                        newCartTotal += item.Price;
                    }
                }
                Console.WriteLine($"Your new total is: ${newCartTotal}");
                Console.WriteLine($"Thank you for coming. Today you saved: ${shoppingCartTotal - newCartTotal}");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Sorry, that is not a valid coupon code");
            }
        }
    }
}
