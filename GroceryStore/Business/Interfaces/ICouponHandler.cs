using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Business.Interfaces
{
    public interface ICouponHandler
    {
        public double HandleUserSelection(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal);
    }
}
