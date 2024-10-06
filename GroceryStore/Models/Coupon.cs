using GroceryStore.Models.Interfaces;

namespace GroceryStore.Models
{
    public class Coupon : ICoupon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
    }
}
