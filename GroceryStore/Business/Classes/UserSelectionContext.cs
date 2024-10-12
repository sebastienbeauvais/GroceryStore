using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Business.Classes
{
    public class UserSelectionContext
    {
        private IUserSelectionState currentState;

        public UserSelectionContext(IUserSelectionState initialState)
        {
            currentState = initialState;
        }

        public void SetState(IUserSelectionState newState)
        {
            currentState = newState;
        }

        public double HandleUserSelection(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal)
        {
            return currentState.HandleUserSelection(shoppingCart, shoppingCartTotal);
        }
    }
}
