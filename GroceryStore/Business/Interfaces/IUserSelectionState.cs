using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models;

namespace GroceryStore.Business.Interfaces
{
    public interface IUserSelectionState
    {
        double HandleUserSelection(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal);
    }
}
