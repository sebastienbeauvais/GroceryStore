using GroceryStore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.DataAccess.Interfaces
{
    public interface ICartRepository
    {
        List<CartItem> InitializeStoreCart();
        IEnumerable<CartItem> GetItemsInCart();
        List<CartItem> PrePackagedCart();
    }
}
