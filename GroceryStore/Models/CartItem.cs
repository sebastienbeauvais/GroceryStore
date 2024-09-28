
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Models
{
    public class CartItem : ICartItem
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
