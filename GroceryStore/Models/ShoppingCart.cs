using GroceryStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class ShoppingCart : IShoppingCart
    {
        public IEnumerable<ICartItem> Items { get; set; }
        public double TotalPrice { get; set; }
        public ICoupon? coupon { get; set; }
    }
}
